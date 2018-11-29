using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Colegio.Models.Inscripcion.GeneralNs.CostoInscripcionNs;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Colegio.Incripcion.CostoInscripcionNs
{
    public class CostoInscripcionAppService : AsyncCrudAppService<CostoInscripcion, CostoInscripcionDto, int, PagedAndSortedResultRequestDto, CostoInscripcionDto, CostoInscripcionDto>, ICostoInscripcionAppService
    {
        public CostoInscripcionAppService(IRepository<CostoInscripcion> repository)
            : base(repository)
        {
        }

        public Task<PagedResultDto<CostoInscripcionDto>> GetAllFiltered(PagedAndSortedResultRequestDto input, string filter)
        {
            var provinciaList = new List<CostoInscripcion>();
            var query = Repository.GetAll();

            query = ApplySorting(query, input);


            if (filter != null && filter != string.Empty)
            {
                provinciaList = query
                    .Where(x => x.GrupoId.ToString().StartsWith(filter))
                    .Skip(input.SkipCount)
                    .Take(input.MaxResultCount).ToList();

                var result = new PagedResultDto<CostoInscripcionDto>(query.Count(), ObjectMapper.Map<List<CostoInscripcionDto>>(provinciaList));
                return Task.FromResult(result);
            }
            else
            {
                provinciaList = query
                    .Skip(input.SkipCount)
                    .Take(input.MaxResultCount).ToList()
                    .ToList();

                var result = new PagedResultDto<CostoInscripcionDto>(query.Count(), ObjectMapper.Map<List<CostoInscripcionDto>>(provinciaList));
                return Task.FromResult(result);
            }
        }

        protected override IQueryable<CostoInscripcion> ApplySorting(IQueryable<CostoInscripcion> query, PagedAndSortedResultRequestDto input)
        {
            if (input.Sorting.IsNullOrEmpty())
            {
                input.Sorting = "GrupoId asc";
            }
            return base.ApplySorting(query, input);
        }

        public List<CostoInscripcionDto> GetAllForSelect()
        {
            var paisList = new List<CostoInscripcion>();

            var query = Repository.GetAll();
            paisList = query.ToList();

            return new List<CostoInscripcionDto>(ObjectMapper.Map<List<CostoInscripcionDto>>(paisList));
        }
    }
}
