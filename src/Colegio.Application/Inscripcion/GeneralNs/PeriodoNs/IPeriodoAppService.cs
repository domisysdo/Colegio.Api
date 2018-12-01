using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Colegio.Incripcion.PeriodoNs
{
    public interface IPeriodoAppService: IAsyncCrudAppService<PeriodoDto, int, PagedAndSortedResultRequestDto, PeriodoDto, PeriodoDto>
    {
        Task<PagedResultDto<PeriodoDto>> GetAllFiltered(PagedAndSortedResultRequestDto input, string filter);

        List<PeriodoDto> GetAllForSelect();
    }
}
