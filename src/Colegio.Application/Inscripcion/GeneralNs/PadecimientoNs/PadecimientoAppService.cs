using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Colegio.Incripcion.General.PadecimientoNs;
using Colegio.Models.Inscripcion.GeneralNs.PadecimientoNs;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Colegio.Incripcion.PadecimientoNs
{
    public class PadecimientoAppService : AsyncCrudAppService<Padecimiento, PadecimientoDto, int, PagedAndSortedResultRequestDto, PadecimientoDto, PadecimientoDto>, IPadecimientoAppService
    {
        public PadecimientoAppService(IRepository<Padecimiento> repository)
            : base(repository)
        {
        }

        public Task<PagedResultDto<PadecimientoDto>> GetAllFiltered(PagedAndSortedResultRequestDto input, string filter)
        {
            var provinciaList = new List<Padecimiento>();
            var query = Repository.GetAll();

            query = ApplySorting(query, input);


            if (filter != null && filter != string.Empty)
            {
                provinciaList = query
                    .Where(x => x.Descripcion.StartsWith(filter))
                    .Skip(input.SkipCount)
                    .Take(input.MaxResultCount).ToList();

                var result = new PagedResultDto<PadecimientoDto>(query.Count(), ObjectMapper.Map<List<PadecimientoDto>>(provinciaList));
                return Task.FromResult(result);
            }
            else
            {
                provinciaList = query
                    .Skip(input.SkipCount)
                    .Take(input.MaxResultCount).ToList()
                    .ToList();

                var result = new PagedResultDto<PadecimientoDto>(query.Count(), ObjectMapper.Map<List<PadecimientoDto>>(provinciaList));
                return Task.FromResult(result);
            }
        }

        protected override IQueryable<Padecimiento> ApplySorting(IQueryable<Padecimiento> query, PagedAndSortedResultRequestDto input)
        {
            if (input.Sorting.IsNullOrEmpty())
            {
                input.Sorting = "Identificador asc";
            }
            return base.ApplySorting(query, input);
        }

        public List<PadecimientoDto> GetAllForSelect()
        {
            var paisList = new List<Padecimiento>();

            var query = Repository.GetAll();
            paisList = query.ToList();

            return new List<PadecimientoDto>(ObjectMapper.Map<List<PadecimientoDto>>(paisList));
        }
    }
}
