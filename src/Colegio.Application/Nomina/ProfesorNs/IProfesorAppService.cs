using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Colegio.Generales.PaisNs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Colegio.Nomina.ProfesorNs
{
    public interface IProfesorAppService: IAsyncCrudAppService<ProfesorDto, int, PagedAndSortedResultRequestDto, ProfesorDto, ProfesorDto>
    {
        Task<PagedResultDto<ProfesorDto>> GetAllFiltered(PagedAndSortedResultRequestDto input, string filter);
    }
}
