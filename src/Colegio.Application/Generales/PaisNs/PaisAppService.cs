using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Colegio.Generales.PaisNs;
using Colegio.Models.Generales.PaisNs;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Colegio.PaisNs
{
    public class PaisAppService : AsyncCrudAppService<Pais, PaisDto, int, PagedAndSortedResultRequestDto, PaisDto, PaisDto>, IPaisAppService
    {
        public PaisAppService(IRepository<Pais> repository)
            :base(repository)
        {
        }
        
        public Task<PagedResultDto<PaisDto>> GetAllFiltered(PagedAndSortedResultRequestDto input, string filter)
        {
            var paisList = new List<Pais>();
            var query = Repository.GetAll();

            query = ApplySorting(query, input);


            if (filter != null && filter != string.Empty)
            {
                paisList = query
                    .Where(x => x.Identificador.StartsWith(filter) || x.Nombre.StartsWith(filter))
                    .Skip(input.SkipCount)
                    .Take(input.MaxResultCount).ToList();

                var result = new PagedResultDto<PaisDto>(query.Count(), ObjectMapper.Map<List<PaisDto>>(paisList));
                return Task.FromResult(result);
            }
            else
            {

                paisList = query
                    .Skip(input.SkipCount)
                    .Take(input.MaxResultCount).ToList()
                    .ToList();

                var result = new PagedResultDto<PaisDto>(query.Count(), ObjectMapper.Map<List<PaisDto>>(paisList));
                return Task.FromResult(result);
            }
        }

        protected override IQueryable<Pais> ApplySorting(IQueryable<Pais> query, PagedAndSortedResultRequestDto input)
        {
            if (input.Sorting.IsNullOrEmpty())
            {
                input.Sorting = "Identificador asc";
            }
            return base.ApplySorting(query, input);
        }
        public List<PaisDto> GetAllForSelect()
        {
            var paisList = new List<Pais>();

            var query = Repository.GetAll();
            paisList = query.ToList();

            return new List<PaisDto>(ObjectMapper.Map<List<PaisDto>>(paisList));
        }
    }
}
