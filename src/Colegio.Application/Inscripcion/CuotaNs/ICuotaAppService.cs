using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Colegio.Inscripcion.CuotaNs
{
    public interface ICuotaAppService: IAsyncCrudAppService<CuotaDto, int, PagedAndSortedResultRequestDto, CuotaDto, CuotaDto>
    {
        Task<PagedResultDto<CuotaDto>> GetAllFiltered(PagedAndSortedResultRequestDto input, string filter);

        List<CuotaDto> GetAllForSelect();
        List<CuotaDto> GetCuotasPendiente(int estudianteId);
    }
}
