using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Colegio.Generales.PaisNs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Colegio.Generales.ProvinciaNs
{
    public interface IProvinciaAppService: IAsyncCrudAppService<ProvinciaDto, int, PagedAndSortedResultRequestDto, ProvinciaDto, ProvinciaDto>
    {
        Task<PagedResultDto<ProvinciaDto>> GetAllFiltered(PagedAndSortedResultRequestDto input, string filter);
    }
}
