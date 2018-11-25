using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Colegio.Generales.LugarTrabajoNs
{
    public interface ILugarTrabajoAppService: IAsyncCrudAppService<LugarTrabajoDto, int, PagedAndSortedResultRequestDto, LugarTrabajoDto, LugarTrabajoDto>
    {
        Task<PagedResultDto<LugarTrabajoDto>> GetAllFiltered(PagedAndSortedResultRequestDto input, string filter);

        List<LugarTrabajoDto> GetAllForSelect();
    }
}
