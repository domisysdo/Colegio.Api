using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Colegio.Generales.ProfesionNs
{
    public interface IProfesionAppService: IAsyncCrudAppService<ProfesionDto, int, PagedAndSortedResultRequestDto, ProfesionDto, ProfesionDto>
    {
        Task<PagedResultDto<ProfesionDto>> GetAllFiltered(PagedAndSortedResultRequestDto input, string filter);

        List<ProfesionDto> GetAllForSelect();
    }
}
