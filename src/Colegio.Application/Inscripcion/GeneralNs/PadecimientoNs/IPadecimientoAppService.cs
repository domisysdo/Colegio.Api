using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Colegio.Incripcion.PadecimientoNs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Colegio.Incripcion.General.PadecimientoNs
{
    public interface IPadecimientoAppService: IAsyncCrudAppService<PadecimientoDto, int, PagedAndSortedResultRequestDto, PadecimientoDto, PadecimientoDto>
    {
        Task<PagedResultDto<PadecimientoDto>> GetAllFiltered(PagedAndSortedResultRequestDto input, string filter);

        List<PadecimientoDto> GetAllForSelect();
    }
}
