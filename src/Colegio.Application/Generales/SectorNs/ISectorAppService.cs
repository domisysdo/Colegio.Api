using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Colegio.Generales.SectorNs
{
    public interface ISectorAppService: IAsyncCrudAppService<SectorDto, int, PagedAndSortedResultRequestDto, SectorDto, SectorDto>
    {
        Task<PagedResultDto<SectorDto>> GetAllFiltered(PagedAndSortedResultRequestDto input, string filter);

        List<SectorDto> GetAllForSelect();
    }
}
