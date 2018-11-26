using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Colegio.Generales.TipoIncidenciaNs;
using Colegio.Models.Generales.TipoIncidenciaNs;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Colegio.TipoIncidenciaNs
{
    public class TipoIncidenciaAppService : AsyncCrudAppService<TipoIncidencia, TipoIncidenciaDto, int, PagedAndSortedResultRequestDto, TipoIncidenciaDto, TipoIncidenciaDto>, ITipoIncidenciaAppService
    {
        public TipoIncidenciaAppService(IRepository<TipoIncidencia> repository)
            : base(repository)
        {
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
                input.Sorting = "Identificador asc";
            }
            return base.ApplySorting(query, input);
        }

        public List<TipoIncidenciaDto> GetAllForSelect()
        {
            var tipoTelefonoList = new List<TipoIncidencia>();

            var query = Repository.GetAll();
            tipoTelefonoList = query.ToList();

            return new List<TipoIncidenciaDto>(ObjectMapper.Map<List<TipoIncidenciaDto>>(tipoTelefonoList));
        }
    }
}
