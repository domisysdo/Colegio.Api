using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Colegio.Generales.DireccionEstudianteNs
{
    public interface IDireccionEstudianteAppService: IAsyncCrudAppService<DireccionEstudianteDto, int, PagedAndSortedResultRequestDto, DireccionEstudianteDto, DireccionEstudianteDto>
    {
        Task<PagedResultDto<DireccionEstudianteDto>> GetAllFiltered(PagedAndSortedResultRequestDto input, string filter);

        List<DireccionEstudianteDto> GetAllForSelect();
    }
}
