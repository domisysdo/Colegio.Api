using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Colegio.Generales.MetodoEvaluacionNs;
using Colegio.Models.Notas.MetodoEvaluacionNs;
using Colegio.Notas.MetodoEvaluacionNs;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Colegio.MetodoEvaluacionNs
{
    public class MetodoEvaluacionAppService : AsyncCrudAppService<MetodoEvaluacion, MetodoEvaluacionDto, int, PagedAndSortedResultRequestDto, MetodoEvaluacionDto, MetodoEvaluacionDto>, IMetodoEvaluacionAppService
    {
        public MetodoEvaluacionAppService(IRepository<MetodoEvaluacion> repository)
            :base(repository)
        {
        }
        
        public Task<PagedResultDto<MetodoEvaluacionDto>> GetAllFiltered(PagedAndSortedResultRequestDto input, string filter)
        {
            var MetodoEvaluacionList = new List<MetodoEvaluacion>();
            var query = Repository.GetAll();

            query = ApplySorting(query, input);


            if (filter != null && filter != string.Empty)
            {
                MetodoEvaluacionList = query
                    .Where(x => x.Descripcion.StartsWith(filter))
                    .Skip(input.SkipCount)
                    .Take(input.MaxResultCount).ToList();

                var result = new PagedResultDto<MetodoEvaluacionDto>(query.Count(), ObjectMapper.Map<List<MetodoEvaluacionDto>>(MetodoEvaluacionList));
                return Task.FromResult(result);
            }
            else
            {

                MetodoEvaluacionList = query
                    .Skip(input.SkipCount)
                    .Take(input.MaxResultCount).ToList()
                    .ToList();

                var result = new PagedResultDto<MetodoEvaluacionDto>(query.Count(), ObjectMapper.Map<List<MetodoEvaluacionDto>>(MetodoEvaluacionList));
                return Task.FromResult(result);
            }
        }

        protected override IQueryable<MetodoEvaluacion> ApplySorting(IQueryable<MetodoEvaluacion> query, PagedAndSortedResultRequestDto input)
        {
            if (input.Sorting.IsNullOrEmpty())
            {
                input.Sorting = "Descripcion asc";
            }
            return base.ApplySorting(query, input);
        }
        public List<MetodoEvaluacionDto> GetAllForSelect()
        {
            var MetodoEvaluacionList = new List<MetodoEvaluacion>();

            var query = Repository.GetAll();
            MetodoEvaluacionList = query.ToList();

            return new List<MetodoEvaluacionDto>(ObjectMapper.Map<List<MetodoEvaluacionDto>>(MetodoEvaluacionList));
        }
    }
}
