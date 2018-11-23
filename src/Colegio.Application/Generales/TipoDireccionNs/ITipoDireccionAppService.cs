using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Colegio.Generales.TipoDireccionNs
{
    public interface ITipoDireccionAppService: IAsyncCrudAppService<TipoDireccionDto, int, PagedAndSortedResultRequestDto, TipoDireccionDto, TipoDireccionDto>
    {
        Task<PagedResultDto<TipoDireccionDto>> GetAllFiltered(PagedAndSortedResultRequestDto input, string filter);

        List<TipoDireccionDto> GetAllForSelect();
    }
}
