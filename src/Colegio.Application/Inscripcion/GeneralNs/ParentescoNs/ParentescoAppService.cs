using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Colegio.Incripcion.ParentescoNs;
using Colegio.Models.Inscripcion.GeneralNs.ParentescoNs;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Colegio.Incripcion.General.ParentescoNs
{
    public class ParentescoAppService : AsyncCrudAppService<Parentesco, ParentescoDto, int, PagedAndSortedResultRequestDto, ParentescoDto, ParentescoDto>, IParentescoAppService
    {
        public ParentescoAppService(IRepository<Parentesco> repository)
            : base(repository)
        {
        }

        public Task<PagedResultDto<ParentescoDto>> GetAllFiltered(PagedAndSortedResultRequestDto input, string filter)
        {
            var provinciaList = new List<Parentesco>();
            var query = Repository.GetAll();

            query = ApplySorting(query, input);


            if (filter != null && filter != string.Empty)
            {
                provinciaList = query
                    .Where(x => x.Descripcion.StartsWith(filter))
                    .Skip(input.SkipCount)
                    .Take(input.MaxResultCount).ToList();

                var result = new PagedResultDto<ParentescoDto>(query.Count(), ObjectMapper.Map<List<ParentescoDto>>(provinciaList));
                return Task.FromResult(result);
            }
            else
            {
                provinciaList = query
                    .Skip(input.SkipCount)
                    .Take(input.MaxResultCount).ToList()
                    .ToList();

                var result = new PagedResultDto<ParentescoDto>(query.Count(), ObjectMapper.Map<List<ParentescoDto>>(provinciaList));
                return Task.FromResult(result);
            }
        }

        protected override IQueryable<Parentesco> ApplySorting(IQueryable<Parentesco> query, PagedAndSortedResultRequestDto input)
        {
            if (input.Sorting.IsNullOrEmpty())
            {
                input.Sorting = "Identificador asc";
            }
            return base.ApplySorting(query, input);
        }

        public List<ParentescoDto> GetAllForSelect()
        {
            var paisList = new List<Parentesco>();

            var query = Repository.GetAll();
            paisList = query.ToList();

            return new List<ParentescoDto>(ObjectMapper.Map<List<ParentescoDto>>(paisList));
        }
    }
}
