using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Colegio.Generales.PaisNs
{
    public interface IPaisAppService: IAsyncCrudAppService<PaisDto, int, PagedAndSortedResultRequestDto, PaisDto, PaisDto>
    {
        Task<PagedResultDto<PaisDto>> GetAllFiltered(PagedAndSortedResultRequestDto input, string filter);
        List<PaisDto> GetAllForSelect();

    }
}
