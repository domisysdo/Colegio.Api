using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Colegio.Generales.TipoEmailNs
{
    public interface ITipoEmailAppService: IAsyncCrudAppService<TipoEmailDto, int, PagedAndSortedResultRequestDto, TipoEmailDto, TipoEmailDto>
    {
        Task<PagedResultDto<TipoEmailDto>> GetAllFiltered(PagedAndSortedResultRequestDto input, string filter);

        List<TipoEmailDto> GetAllForSelect();
    }
}
