using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Colegio.Generales.LugarTrabajoNs;
using Colegio.Models.Generales.LugarTrabajoNs;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Colegio.LugarTrabajoNs
{
    public class LugarTrabajoAppService : AsyncCrudAppService<LugarTrabajo, LugarTrabajoDto, int, PagedAndSortedResultRequestDto, LugarTrabajoDto, LugarTrabajoDto>, ILugarTrabajoAppService
    {
        public LugarTrabajoAppService(IRepository<LugarTrabajo> repository)
            : base(repository)
        {
        }

        public Task<PagedResultDto<LugarTrabajoDto>> GetAllFiltered(PagedAndSortedResultRequestDto input, string filter)
        {
            var provinciaList = new List<LugarTrabajo>();
            var query = Repository.GetAll();

            query = ApplySorting(query, input);


            if (filter != null && filter != string.Empty)
            {
                provinciaList = query
                    .Where(x => x.Descripcion.StartsWith(filter))
                    .Skip(input.SkipCount)
                    .Take(input.MaxResultCount).ToList();

                var result = new PagedResultDto<LugarTrabajoDto>(query.Count(), ObjectMapper.Map<List<LugarTrabajoDto>>(provinciaList));
                return Task.FromResult(result);
            }
            else
            {
                provinciaList = query
                    .Skip(input.SkipCount)
                    .Take(input.MaxResultCount).ToList()
                    .ToList();

                var result = new PagedResultDto<LugarTrabajoDto>(query.Count(), ObjectMapper.Map<List<LugarTrabajoDto>>(provinciaList));
                return Task.FromResult(result);
            }
        }

        protected override IQueryable<LugarTrabajo> ApplySorting(IQueryable<LugarTrabajo> query, PagedAndSortedResultRequestDto input)
        {
            if (input.Sorting.IsNullOrEmpty())
            {
                input.Sorting = "Identificador asc";
            }
            return base.ApplySorting(query, input);
        }

        public List<LugarTrabajoDto> GetAllForSelect()
        {
            var paisList = new List<LugarTrabajo>();

            var query = Repository.GetAll();
            paisList = query.ToList();

            return new List<LugarTrabajoDto>(ObjectMapper.Map<List<LugarTrabajoDto>>(paisList));
        }
    }
}
