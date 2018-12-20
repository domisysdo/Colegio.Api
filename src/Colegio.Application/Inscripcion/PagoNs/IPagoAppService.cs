using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Colegio.Inscripcion.PagoNs
{
    public interface IPagoAppService: IAsyncCrudAppService<PagoDto, int, PagedAndSortedResultRequestDto, PagoDto, PagoDto>
    {
        Task<PagedResultDto<PagoDto>> GetAllFiltered(PagedAndSortedResultRequestDto input, string filter);

        List<PagoDto> GetAllForSelect();
    }
}
