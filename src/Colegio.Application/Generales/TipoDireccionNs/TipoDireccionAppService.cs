using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Colegio.Generales.TipoDireccionNs;
using Colegio.Models.Generales.TipoDireccionNs;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Colegio.TipoDireccionNs
{
    public class TipoDireccionAppService : AsyncCrudAppService<TipoDireccion, TipoDireccionDto, int, PagedAndSortedResultRequestDto, TipoDireccionDto, TipoDireccionDto>, ITipoDireccionAppService
    {
        public TipoDireccionAppService(IRepository<TipoDireccion> repository)
            : base(repository)
        {
        }

        public Task<PagedResultDto<TipoDireccionDto>> GetAllFiltered(PagedAndSortedResultRequestDto input, string filter)
        {
            var tipoDireccionList = new List<TipoDireccion>();
            var query = Repository.GetAll();

            query = ApplySorting(query, input);


            if (filter != null && filter != string.Empty)
            {
                tipoDireccionList = query
                    .Where(x => x.Descripcion.StartsWith(filter))
                    .Skip(input.SkipCount)
                    .Take(input.MaxResultCount).ToList();

                var result = new PagedResultDto<TipoDireccionDto>(query.Count(), ObjectMapper.Map<List<TipoDireccionDto>>(tipoDireccionList));
                return Task.FromResult(result);
            }
            else
            {
                tipoDireccionList = query
                    .Skip(input.SkipCount)
                    .Take(input.MaxResultCount).ToList()
                    .ToList();

                var result = new PagedResultDto<TipoDireccionDto>(query.Count(), ObjectMapper.Map<List<TipoDireccionDto>>(tipoDireccionList));
                return Task.FromResult(result);
            }
        }

        protected override IQueryable<TipoDireccion> ApplySorting(IQueryable<TipoDireccion> query, PagedAndSortedResultRequestDto input)
        {
            if (input.Sorting.IsNullOrEmpty())
            {
                input.Sorting = "Identificador asc";
            }
            return base.ApplySorting(query, input);
        }

        public List<TipoDireccionDto> GetAllForSelect()
        {
            var tipoDireccionList = new List<TipoDireccion>();

            var query = Repository.GetAll();
            tipoDireccionList = query.ToList();

            return new List<TipoDireccionDto>(ObjectMapper.Map<List<TipoDireccionDto>>(tipoDireccionList));
        }
    }
}
