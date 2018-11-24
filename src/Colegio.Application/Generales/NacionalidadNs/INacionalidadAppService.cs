using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Colegio.Generales.NacionalidadNs
{
    public interface INacionalidadAppService: IAsyncCrudAppService<NacionalidadDto, int, PagedAndSortedResultRequestDto, NacionalidadDto, NacionalidadDto>
    {
        Task<PagedResultDto<NacionalidadDto>> GetAllFiltered(PagedAndSortedResultRequestDto input, string filter);

        List<NacionalidadDto> GetAllForSelect();
    }
}
