using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.EntityFrameworkCore.Repositories;
using Abp.Extensions;
using Colegio.Generales.EstadoIdenciaNs;
using Colegio.Generales.TipoIncidenciaNs;
using Colegio.Models.Generales.EstadoIncidenciaNs;
using Colegio.Models.Generales.TipoIncidenciaNs;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Colegio.TipoIncidenciaNs
{
    public class TipoIncidenciaAppService : AsyncCrudAppService<TipoIncidencia, TipoIncidenciaDto, int, PagedAndSortedResultRequestDto, TipoIncidenciaDto, TipoIncidenciaDto>, ITipoIncidenciaAppService
    {

        IRepository<EstadoIncidencia> _estadoIncidenciaRepository;
        public TipoIncidenciaAppService(IRepository<TipoIncidencia> repository,
                                        IRepository<EstadoIncidencia> estadoIncidenciaRepository)
            : base(repository)
        {
            _estadoIncidenciaRepository = estadoIncidenciaRepository;
        }

        public override Task<TipoIncidenciaDto> Create(TipoIncidenciaDto input)
        {
            var result = Repository.InsertOrUpdate(ObjectMapper.Map<TipoIncidencia>(input));
            if (input.Id > 0)
            {
                TipoIncidencia tipoIncidencia = Repository.Get(input.Id);
                ModificarEstadoIncidencia(ObjectMapper.Map<List<EstadoIncidencia>>(input.ListaEstadoIncidencia), tipoIncidencia.Id);
                CurrentUnitOfWork.SaveChanges();
            }
            return Task.FromResult(ObjectMapper.Map<TipoIncidenciaDto>(result));
        }

        public Task<PagedResultDto<TipoIncidenciaDto>> GetAllFiltered(PagedAndSortedResultRequestDto input, string filter)
        {
            var tipoTelefonoList = new List<TipoIncidencia>();
            var query = Repository.GetAll();

            query = ApplySorting(query, input);


            if (filter != null && filter != string.Empty)
            {
                tipoTelefonoList = query
                    .Where(x => x.Descripcion.StartsWith(filter))
                    .Skip(input.SkipCount)
                    .Take(input.MaxResultCount).ToList();

                var result = new PagedResultDto<TipoIncidenciaDto>(query.Count(), ObjectMapper.Map<List<TipoIncidenciaDto>>(tipoTelefonoList));
                return Task.FromResult(result);
            }
            else
            {
                tipoTelefonoList = query
                    .Skip(input.SkipCount)
                    .Take(input.MaxResultCount).ToList()
                    .ToList();

                var result = new PagedResultDto<TipoIncidenciaDto>(query.Count(), ObjectMapper.Map<List<TipoIncidenciaDto>>(tipoTelefonoList));
                return Task.FromResult(result);
            }
        }

        protected override IQueryable<TipoIncidencia> ApplySorting(IQueryable<TipoIncidencia> query, PagedAndSortedResultRequestDto input)
        {
            if (input.Sorting.IsNullOrEmpty())
            {
                input.Sorting = "Descripcion asc";
            }
            return base.ApplySorting(query, input);
        }
        public List<EstadoIncidenciaDto> GetEstadosIncidencia(int tipoIncidenciaId)
        {
            var result = new List<EstadoIncidencia>();

            var query = _estadoIncidenciaRepository.GetAll().Where(x => x.TipoIncidenciaId == tipoIncidenciaId);

            result = query.ToList();

            return new List<EstadoIncidenciaDto>(ObjectMapper.Map<List<EstadoIncidenciaDto>>(result));
        }
        public List<TipoIncidenciaDto> GetAllForSelect()
        {
            var tipoTelefonoList = new List<TipoIncidencia>();

            var query = Repository.GetAll();
            tipoTelefonoList = query.ToList();

            return new List<TipoIncidenciaDto>(ObjectMapper.Map<List<TipoIncidenciaDto>>(tipoTelefonoList));
        }

        public void ModificarEstadoIncidencia(List<EstadoIncidencia> estadoIncidencia, int tipoIncidenciaId)
        {
            estadoIncidencia.ToList().ForEach(x => x.TipoIncidenciaId = tipoIncidenciaId);
            _estadoIncidenciaRepository.GetDbContext().RemoveRange(_estadoIncidenciaRepository
                                                      .GetAll().Where(x => x.TipoIncidenciaId == tipoIncidenciaId));

            _estadoIncidenciaRepository.GetDbContext().AddRange(estadoIncidencia.Where(x => x.Id > 0));
        }

        public Task<TipoIncidenciaDto> GetIncluding(int tipoIncidenciaId)
        {
            var tipoIncidencia = new List<TipoIncidencia>();

            tipoIncidencia = Repository.GetAll()
                    .Include(x => x.ListaEstadoIncidencia)

            .Where(x => x.Id == tipoIncidenciaId)
            .ToList();

            var res = new List<TipoIncidenciaDto>(ObjectMapper.Map<List<TipoIncidenciaDto>>(tipoIncidencia))
                       .FirstOrDefault();

            return Task.FromResult(res);
        }
    }
}
