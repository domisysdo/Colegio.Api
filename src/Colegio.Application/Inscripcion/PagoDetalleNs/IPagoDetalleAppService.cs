using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Colegio.Inscripcion.PagoDetalleNs
{
    public interface IPagoDetalleAppService: IAsyncCrudAppService<PagoDetalleDto, int, PagedAndSortedResultRequestDto, PagoDetalleDto, PagoDetalleDto>
    {
        Task<PagedResultDto<PagoDetalleDto>> GetAllFiltered(PagedAndSortedResultRequestDto input, string filter);

        List<PagoDetalleDto> GetAllForSelect();
    }
}
