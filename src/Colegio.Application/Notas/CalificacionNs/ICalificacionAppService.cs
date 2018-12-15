using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Colegio.Notas.CalificacionNs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Colegio.Generales.CalificacionNs
{
    public interface ICalificacionAppService: IAsyncCrudAppService<CalificacionDto, int, PagedAndSortedResultRequestDto, CalificacionDto, CalificacionDto>
    {
        Task<PagedResultDto<CalificacionDto>> GetAllFiltered(PagedAndSortedResultRequestDto input, string filter);
        List<CalificacionDto> GetAllForSelect();
    }
}
