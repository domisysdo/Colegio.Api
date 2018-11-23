using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Colegio.Generales.MunicipioNs
{
    public interface IMunicipioAppService: IAsyncCrudAppService<MunicipioDto, int, PagedAndSortedResultRequestDto, MunicipioDto, MunicipioDto>
    {
        Task<PagedResultDto<MunicipioDto>> GetAllFiltered(PagedAndSortedResultRequestDto input, string filter);

        List<MunicipioDto> GetAllForSelect();
    }
}
