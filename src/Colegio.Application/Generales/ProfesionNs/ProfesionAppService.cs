using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Colegio.Generales.ProfesionNs;
using Colegio.Models.Generales.ProfesionNs;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Colegio.ProfesionNs
{
    public class ProfesionAppService : AsyncCrudAppService<Profesion, ProfesionDto, int, PagedAndSortedResultRequestDto, ProfesionDto, ProfesionDto>, IProfesionAppService
    {
        public ProfesionAppService(IRepository<Profesion> repository)
            : base(repository)
        {
        }

        public Task<PagedResultDto<ProfesionDto>> GetAllFiltered(PagedAndSortedResultRequestDto input, string filter)
        {
            var provinciaList = new List<Profesion>();
            var query = Repository.GetAll();

            query = ApplySorting(query, input);


            if (filter != null && filter != string.Empty)
            {
                provinciaList = query
                    .Where(x => x.Descripcion.StartsWith(filter))
                    .Skip(input.SkipCount)
                    .Take(input.MaxResultCount).ToList();

                var result = new PagedResultDto<ProfesionDto>(query.Count(), ObjectMapper.Map<List<ProfesionDto>>(provinciaList));
                return Task.FromResult(result);
            }
            else
            {
                provinciaList = query
                    .Skip(input.SkipCount)
                    .Take(input.MaxResultCount).ToList()
                    .ToList();

                var result = new PagedResultDto<ProfesionDto>(query.Count(), ObjectMapper.Map<List<ProfesionDto>>(provinciaList));
                return Task.FromResult(result);
            }
        }

        protected override IQueryable<Profesion> ApplySorting(IQueryable<Profesion> query, PagedAndSortedResultRequestDto input)
        {
            if (input.Sorting.IsNullOrEmpty())
            {
                input.Sorting = "Identificador asc";
            }
            return base.ApplySorting(query, input);
        }

        public List<ProfesionDto> GetAllForSelect()
        {
            var paisList = new List<Profesion>();

            var query = Repository.GetAll();
            paisList = query.ToList();

            return new List<ProfesionDto>(ObjectMapper.Map<List<ProfesionDto>>(paisList));
        }
    }
}
