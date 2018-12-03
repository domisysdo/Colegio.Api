using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Colegio.Generales.AulaNs;
using Colegio.Models.Generales.AulaNs;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Colegio.AulaNs
{
    public class AulaAppService : AsyncCrudAppService<Aula, AulaDto, int, PagedAndSortedResultRequestDto, AulaDto, AulaDto>, IAulaAppService
    {
        public AulaAppService(IRepository<Aula> repository)
            : base(repository)
        {
        }

        public Task<PagedResultDto<AulaDto>> GetAllFiltered(PagedAndSortedResultRequestDto input, string filter)
        {
            var provinciaList = new List<Aula>();
            var query = Repository.GetAll();

            query = ApplySorting(query, input);


            if (filter != null && filter != string.Empty)
            {
                provinciaList = query
                    .Where(x => x.Identificador.StartsWith(filter) || x.Descripcion.StartsWith(filter))
                    .Skip(input.SkipCount)
                    .Take(input.MaxResultCount).ToList();

                var result = new PagedResultDto<AulaDto>(query.Count(), ObjectMapper.Map<List<AulaDto>>(provinciaList));
                return Task.FromResult(result);
            }
            else
            {
                provinciaList = query
                    .Skip(input.SkipCount)
                    .Take(input.MaxResultCount).ToList()
                    .ToList();

                var result = new PagedResultDto<AulaDto>(query.Count(), ObjectMapper.Map<List<AulaDto>>(provinciaList));
                return Task.FromResult(result);
            }
        }

        protected override IQueryable<Aula> ApplySorting(IQueryable<Aula> query, PagedAndSortedResultRequestDto input)
        {
            if (input.Sorting.IsNullOrEmpty())
            {
                input.Sorting = "Identificador asc";
            }
            return base.ApplySorting(query, input);
        }

        public List<AulaDto> GetAllForSelect()
        {
            var paisList = new List<Aula>();

            var query = Repository.GetAll();
            paisList = query.ToList();

            return new List<AulaDto>(ObjectMapper.Map<List<AulaDto>>(paisList));
        }
    }
}
