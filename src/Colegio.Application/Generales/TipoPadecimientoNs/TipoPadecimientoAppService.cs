using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Colegio.Generales.TipoPadecimientoNs;
using Colegio.Models.Generales.TipoPadecimientoNs;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Colegio.TipoIncidenciaNs
{
    public class TipoPadecimientoAppService : AsyncCrudAppService<TipoPadecimiento, TipoPadecimientoDto, int, PagedAndSortedResultRequestDto, TipoPadecimientoDto, TipoPadecimientoDto>, ITipoPadecimientoAppService
    {
        public TipoPadecimientoAppService(IRepository<TipoPadecimiento> repository)
            : base(repository)
        {
        }

        public Task<PagedResultDto<TipoPadecimientoDto>> GetAllFiltered(PagedAndSortedResultRequestDto input, string filter)
        {
            var tipoPadecimientoList = new List<TipoPadecimiento>();
            var query = Repository.GetAll();

            query = ApplySorting(query, input);


            if (filter != null && filter != string.Empty)
            {
                tipoPadecimientoList = query
                    .Where(x => x.Descripcion.StartsWith(filter))
                    .Skip(input.SkipCount)
                    .Take(input.MaxResultCount).ToList();

                var result = new PagedResultDto<TipoPadecimientoDto>(query.Count(), ObjectMapper.Map<List<TipoPadecimientoDto>>(tipoPadecimientoList));
                return Task.FromResult(result);
            }
            else
            {
                tipoPadecimientoList = query
                    .Skip(input.SkipCount)
                    .Take(input.MaxResultCount).ToList()
                    .ToList();

                var result = new PagedResultDto<TipoPadecimientoDto>(query.Count(), ObjectMapper.Map<List<TipoPadecimientoDto>>(tipoPadecimientoList));
                return Task.FromResult(result);
            }
        }

        protected override IQueryable<TipoPadecimiento> ApplySorting(IQueryable<TipoPadecimiento> query, PagedAndSortedResultRequestDto input)
        {
            if (input.Sorting.IsNullOrEmpty())
            {
                input.Sorting = "Descripcion asc";
            }
            return base.ApplySorting(query, input);
        }

        public List<TipoPadecimientoDto> GetAllForSelect()
        {
            var tipoPadecimientoList = new List<TipoPadecimiento>();

            var query = Repository.GetAll();
            tipoPadecimientoList = query.ToList();

            return new List<TipoPadecimientoDto>(ObjectMapper.Map<List<TipoPadecimientoDto>>(tipoPadecimientoList));
        }
    }
}
