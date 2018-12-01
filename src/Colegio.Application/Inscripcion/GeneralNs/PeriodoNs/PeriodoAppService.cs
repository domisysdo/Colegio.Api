using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Colegio.Models.Inscripcion.GeneralNs.PeriodoNs;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Colegio.Incripcion.PeriodoNs
{
    public class PeriodoAppService : AsyncCrudAppService<Periodo, PeriodoDto, int, PagedAndSortedResultRequestDto, PeriodoDto, PeriodoDto>, IPeriodoAppService
    {
        public PeriodoAppService(IRepository<Periodo> repository)
            : base(repository)
        {
        }

        public Task<PagedResultDto<PeriodoDto>> GetAllFiltered(PagedAndSortedResultRequestDto input, string filter)
        {
            var provinciaList = new List<Periodo>();
            var query = Repository.GetAll();

            query = ApplySorting(query, input);


            if (filter != null && filter != string.Empty)
            {
                provinciaList = query
                    .Where(x => x.Identificador.StartsWith(filter))
                    .Skip(input.SkipCount)
                    .Take(input.MaxResultCount).ToList();

                var result = new PagedResultDto<PeriodoDto>(query.Count(), ObjectMapper.Map<List<PeriodoDto>>(provinciaList));
                return Task.FromResult(result);
            }
            else
            {
                provinciaList = query
                    .Skip(input.SkipCount)
                    .Take(input.MaxResultCount).ToList()
                    .ToList();

                var result = new PagedResultDto<PeriodoDto>(query.Count(), ObjectMapper.Map<List<PeriodoDto>>(provinciaList));
                return Task.FromResult(result);
            }
        }

        protected override IQueryable<Periodo> ApplySorting(IQueryable<Periodo> query, PagedAndSortedResultRequestDto input)
        {
            if (input.Sorting.IsNullOrEmpty())
            {
                input.Sorting = "Identificador asc";
            }
            return base.ApplySorting(query, input);
        }

        public List<PeriodoDto> GetAllForSelect()
        {
            var paisList = new List<Periodo>();

            var query = Repository.GetAll();
            paisList = query.ToList();

            return new List<PeriodoDto>(ObjectMapper.Map<List<PeriodoDto>>(paisList));
        }
    }
}
