using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Colegio.Incripcion.CostoInscripcionNs
{
    public interface ICostoInscripcionAppService : IAsyncCrudAppService<CostoInscripcionDto, int, PagedAndSortedResultRequestDto, CostoInscripcionDto, CostoInscripcionDto>
    {
        Task<PagedResultDto<CostoInscripcionDto>> GetAllFiltered(PagedAndSortedResultRequestDto input, string filter);

        List<CostoInscripcionDto> GetAllForSelect();
    }
}
