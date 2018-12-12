using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.EntityFrameworkCore.Repositories;
using Abp.Extensions;
using Colegio.Models.Generales.DireccionEstudianteNs;
using Colegio.Models.Generales.EmailEstudianteNs;
using Colegio.Models.Generales.TelefonoEstudianteNs;
using Colegio.Models.Inscripcion.EstudianteNs;
using Colegio.Models.Inscripcion.GeneralNs.FamiliarEstudianteNs;
using Colegio.Models.Inscripcion.GeneralNs.PadecimientoNs;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Colegio.Inscripcion.EstudianteNs
{
    public class EstudianteAppService : AsyncCrudAppService<Estudiante, EstudianteDto, int, PagedAndSortedResultRequestDto, EstudianteDto, EstudianteDto>, IEstudianteAppService
    {
        IRepository<EmailEstudiante> _emailRepository;
        IRepository<TelefonoEstudiante> _telefonoRepository;
        IRepository<DireccionEstudiante> _direccionRepository;
        IRepository<FamiliarEstudiante> _familiarRepository;
        IRepository<Padecimiento> _padecimientoRepository;
        IEstudianteManager _estudianteManager;

        public EstudianteAppService(IRepository<Estudiante> repository,
                                    IRepository<EmailEstudiante> emailRepository,
                                    IRepository<TelefonoEstudiante> telefonoRepository,
                                    IRepository<DireccionEstudiante> direccionRepository,
                                    IRepository<FamiliarEstudiante> familiarRepository,
                                    IRepository<Padecimiento> padecimientoRepository,
                                    IEstudianteManager estudianteManager)
            : base(repository)
        {
            _emailRepository = emailRepository;
            _telefonoRepository = telefonoRepository;
            _direccionRepository = direccionRepository;
            _familiarRepository = familiarRepository;
            _padecimientoRepository = padecimientoRepository;
            _estudianteManager = estudianteManager;
        }

        public override Task<EstudianteDto> Create(EstudianteDto input)
        {
            var result = Repository.InsertOrUpdate(ObjectMapper.Map<Estudiante>(input));
            if (input.Id > 0)
            {
                Estudiante estudiante = Repository.Get(input.Id);
                ModificaEmails(ObjectMapper.Map<List<EmailEstudiante>>(input.ListaEmail), estudiante.Id);
                ModificarDirecciones(ObjectMapper.Map<List<DireccionEstudiante>>(input.ListaDireccionEstudiante), estudiante.Id);
                ModificarFamiliares(ObjectMapper.Map<List<FamiliarEstudiante>>(input.ListaFamiliarEstudiante), estudiante.Id);
                ModificarTelefonos(ObjectMapper.Map<List<TelefonoEstudiante>>(input.ListaTelefonos), estudiante.Id);
                ModificarPadecimientos(ObjectMapper.Map<List<Padecimiento>>(input.ListaPadecimientos), estudiante.Id);
                CurrentUnitOfWork.SaveChanges();
            }
            return Task.FromResult(ObjectMapper.Map<EstudianteDto>(result));
        }

        public Task<PagedResultDto<EstudianteDto>> GetAllFiltered(PagedAndSortedResultRequestDto input, string filter)
        {
            var provinciaList = new List<Estudiante>();
            var query = Repository.GetAll();

            query = ApplySorting(query, input);


            if (filter != null && filter != string.Empty)
            {
                provinciaList = query
                    .Where(x => x.Nombres.StartsWith(filter) || x.PrimerApellido.StartsWith(filter)
                                                             || x.SegundoApellido.StartsWith(filter)
                                                             || x.Identificador.StartsWith(filter))
                    .Skip(input.SkipCount)
                    .Take(input.MaxResultCount).ToList();

                var result = new PagedResultDto<EstudianteDto>(query.Count(), ObjectMapper.Map<List<EstudianteDto>>(provinciaList));
                return Task.FromResult(result);
            }
            else
            {
                provinciaList = query
                    .Skip(input.SkipCount)
                    .Take(input.MaxResultCount).ToList()
                    .ToList();

                var result = new PagedResultDto<EstudianteDto>(query.Count(), ObjectMapper.Map<List<EstudianteDto>>(provinciaList));
                return Task.FromResult(result);
            }
        }

        protected override IQueryable<Estudiante> ApplySorting(IQueryable<Estudiante> query, PagedAndSortedResultRequestDto input)
        {
            if (input.Sorting.IsNullOrEmpty())
            {
                input.Sorting = "Identificador asc";
            }
            return base.ApplySorting(query, input);
        }

        public List<EstudianteDto> GetAllForSelect()
        {
            var paisList = new List<Estudiante>();

            var query = Repository.GetAll();
            paisList = query.ToList();

            return new List<EstudianteDto>(ObjectMapper.Map<List<EstudianteDto>>(paisList));
        }

        public Task<EstudianteDto> GetIncluding(int estudianteId)
        {
            var estudiante = new List<Estudiante>();

            estudiante = Repository.GetAll()
                    .Include(x => x.ListaDireccionEstudiante)
                        .ThenInclude(x=>x.TipoDireccion)
                    .Include(x => x.ListaDireccionEstudiante)
                        .ThenInclude(x => x.Sector)
                    .Include(x => x.ListaTelefonos)
                        .ThenInclude(x => x.TipoTelefono)
                    .Include(x => x.ListaFamiliarEstudiante)
                        .ThenInclude(x => x.Parentesco)                       
                    .Include(x => x.ListaEmail)
                        .ThenInclude(x => x.TipoEmail)
                    .Include(x => x.ListaPadecimientos) 
                        .ThenInclude(x => x.TipoPadecimiento)

            .Where(x => x.Id == estudianteId)
            .ToList();


            var res = new List<EstudianteDto>(ObjectMapper.Map<List<EstudianteDto>>(estudiante))
                       .FirstOrDefault();

            return Task.FromResult(res);
        }

        public void ModificaEmails(List<EmailEstudiante> emailEstudiantes, int estudianteId)
        {
            emailEstudiantes.ToList().ForEach(x => x.EstudianteId = estudianteId);
            _emailRepository.GetDbContext().RemoveRange(_emailRepository
                                                        .GetAll().Where(x=>x.EstudianteId == estudianteId)                                                        
                                                        );

            _emailRepository.GetDbContext().AddRange(emailEstudiantes.Where(x => x.Id > 0));
        }

        public void ModificarTelefonos(List<TelefonoEstudiante> telefonoEstudiante, int estudianteId)
        {
            telefonoEstudiante.ToList().ForEach(x => x.EstudianteId = estudianteId);
            _telefonoRepository.GetDbContext().RemoveRange(_telefonoRepository
                                                            .GetAll().Where(x => x.EstudianteId == estudianteId)
                                                            );

            _telefonoRepository.GetDbContext().AddRange(telefonoEstudiante.Where(x => x.Id > 0));
        }

        public void ModificarDirecciones(List<DireccionEstudiante> direccionEstudiante, int estudianteId)
        {
            direccionEstudiante.ToList().ForEach(x => x.EstudianteId = estudianteId);
            _direccionRepository.GetDbContext().RemoveRange(_direccionRepository
                                                            .GetAll().Where(x => x.EstudianteId == estudianteId)
                                                            );

            _direccionRepository.GetDbContext().AddRange(direccionEstudiante.Where(x => x.Id > 0));
        }

        public void ModificarFamiliares(List<FamiliarEstudiante> familiarEstudiante, int estudianteId)
        {
            familiarEstudiante.ToList().ForEach(x => x.EstudianteId = estudianteId);
            _familiarRepository.GetDbContext().RemoveRange(_familiarRepository
                                                            .GetAll().Where(x => x.EstudianteId == estudianteId)
                                                            );

            _familiarRepository.GetDbContext().AddRange(familiarEstudiante.Where(x => x.Id > 0));
        }

        public void ModificarPadecimientos(List<Padecimiento> padecimiento, int estudianteId)
        {
            padecimiento.ToList().ForEach(x => x.EstudianteId = estudianteId);
            _padecimientoRepository.GetDbContext().RemoveRange(_padecimientoRepository
                                                                .GetAll().Where(x => x.EstudianteId == estudianteId)
                                                                );
            
            _padecimientoRepository.GetDbContext().AddRange(padecimiento.Where(x => x.Id > 0));
        }

        public string GetSiguienteIdentificador()
        {
            return _estudianteManager.GetSiguienteIdentificador();
        }
    }
}
