using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Colegio.Generales.AulaNs
{
    public interface IAulaAppService : IAsyncCrudAppService<AulaDto, int, PagedAndSortedResultRequestDto, AulaDto, AulaDto>
    {
        Task<PagedResultDto<AulaDto>> GetAllFiltered(PagedAndSortedResultRequestDto input, string filter);

        List<AulaDto> GetAllForSelect();
    }
}
