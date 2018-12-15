using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.EntityFrameworkCore.Repositories;
using Abp.Extensions;
using Colegio.Models.Nomina.ProfesorGrupoNs;
using Colegio.Models.Nomina.ProfesorNs;
using Colegio.Nomina.ProfesorNs;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Colegio.ProfesorNs
{
    public class ProfesorAppService : AsyncCrudAppService<Profesor, ProfesorDto, int, PagedAndSortedResultRequestDto, ProfesorDto, ProfesorDto>, IProfesorAppService
    {
        IRepository<ProfesorGrupo> _profesorMateriaRepository;
        public ProfesorAppService(IRepository<Profesor> repository,
                                  IRepository<ProfesorGrupo> profesorMateriaRepository)
            : base(repository)
        {
            _profesorMateriaRepository = profesorMateriaRepository;
        }

        public override Task<ProfesorDto> Create(ProfesorDto input)
        {
            var result = Repository.InsertOrUpdate(ObjectMapper.Map<Profesor>(input));
            if (input.Id > 0)
            {
                Profesor profesor = Repository.Get(input.Id);
                ModificaMaterias(ObjectMapper.Map<List<ProfesorGrupo>>(input.ListaGrupos), profesor.Id);
                CurrentUnitOfWork.SaveChanges();
            }
            return Task.FromResult(ObjectMapper.Map<ProfesorDto>(result));
        }

        public Task<PagedResultDto<ProfesorDto>> GetAllFiltered(PagedAndSortedResultRequestDto input, string filter)
        {
            var profesorList = new List<Profesor>();
            var query = Repository.GetAll();

            query = ApplySorting(query, input);


            if (filter != null && filter != string.Empty)
            {
                profesorList = query
                    .Where(x => x.Identificador.StartsWith(filter) || x.Nombres.StartsWith(filter) || x.PrimerApellido.StartsWith(filter) || x.SegundoApellido.StartsWith(filter))
                    .Skip(input.SkipCount)
                    .Take(input.MaxResultCount).ToList();

                var result = new PagedResultDto<ProfesorDto>(query.Count(), ObjectMapper.Map<List<ProfesorDto>>(profesorList));
                return Task.FromResult(result);
            }
            else
            {
                profesorList = query
                    .Skip(input.SkipCount)
                    .Take(input.MaxResultCount).ToList()
                    .ToList();

                var result = new PagedResultDto<ProfesorDto>(query.Count(), ObjectMapper.Map<List<ProfesorDto>>(profesorList));
                return Task.FromResult(result);
            }
        }


        protected override IQueryable<Profesor> ApplySorting(IQueryable<Profesor> query, PagedAndSortedResultRequestDto input)
        {
            if (input.Sorting.IsNullOrEmpty())
            {
                input.Sorting = "Identificador asc";
            }
            return base.ApplySorting(query, input);
        }

        public List<ProfesorDto> GetAllForSelect()
        {
            var profesorList = new List<Profesor>();

            var query = Repository.GetAll();
            profesorList = query.ToList();

            return new List<ProfesorDto>(ObjectMapper.Map<List<ProfesorDto>>(profesorList));

        }

        public Task<ProfesorDto> GetIncluding(int profesorId)
        {
            var profesor = new List<Profesor>();

            profesor = Repository.GetAll()
                    .Include(x => x.ListaGrupos)
                        .ThenInclude(x => x.Profesor)
                    .Include(x => x.ListaGrupos)
                        .ThenInclude(x => x.Grupo)

            .Where(x => x.Id == profesorId)
            .ToList();


            var res = new List<ProfesorDto>(ObjectMapper.Map<List<ProfesorDto>>(profesor))
                       .FirstOrDefault();

            return Task.FromResult(res);
        }

        public void ModificaMaterias(List<ProfesorGrupo> profesorMateria, int profesorId)
        {
            profesorMateria.ToList().ForEach(x => x.ProfesorId = profesorId);
            _profesorMateriaRepository.GetDbContext().RemoveRange(_profesorMateriaRepository
                                                     .GetAll().Where(x => x.ProfesorId == profesorId));

            _profesorMateriaRepository.GetDbContext().AddRange(profesorMateria.Where(x => x.Id > 0));
        }
    }
}
