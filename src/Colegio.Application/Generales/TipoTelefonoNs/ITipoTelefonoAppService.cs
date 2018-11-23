using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Colegio.Generales.TipoTelefonoNs
{
    public interface ITipoTelefonoAppService: IAsyncCrudAppService<TipoTelefonoDto, int, PagedAndSortedResultRequestDto, TipoTelefonoDto, TipoTelefonoDto>
    {
        Task<PagedResultDto<TipoTelefonoDto>> GetAllFiltered(PagedAndSortedResultRequestDto input, string filter);

        List<TipoTelefonoDto> GetAllForSelect();
    }
}
