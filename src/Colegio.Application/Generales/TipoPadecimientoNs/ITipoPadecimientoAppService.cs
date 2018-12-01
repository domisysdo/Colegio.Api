using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Colegio.Generales.TipoPadecimientoNs
{
    public interface ITipoPadecimientoAppService : IAsyncCrudAppService<TipoPadecimientoDto, int, PagedAndSortedResultRequestDto, TipoPadecimientoDto, TipoPadecimientoDto>
    {
        Task<PagedResultDto<TipoPadecimientoDto>> GetAllFiltered(PagedAndSortedResultRequestDto input, string filter);

        List<TipoPadecimientoDto> GetAllForSelect();
    }
}
