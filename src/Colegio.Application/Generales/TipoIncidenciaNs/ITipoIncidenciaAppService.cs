using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Colegio.Generales.TipoIncidenciaNs
{
    public interface ITipoIncidenciaAppService: IAsyncCrudAppService<TipoIncidenciaDto, int, PagedAndSortedResultRequestDto, TipoIncidenciaDto, TipoIncidenciaDto>
    {
        Task<PagedResultDto<TipoIncidenciaDto>> GetAllFiltered(PagedAndSortedResultRequestDto input, string filter);

        List<TipoIncidenciaDto> GetAllForSelect();
    }
}
