using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Colegio.Generales.DireccionFamiliarEstudianteNs
{
    public interface IDireccionFamiliarEstudianteAppService: IAsyncCrudAppService<DireccionFamiliarEstudianteDto, int, PagedAndSortedResultRequestDto, DireccionFamiliarEstudianteDto, DireccionFamiliarEstudianteDto>
    {
        Task<PagedResultDto<DireccionFamiliarEstudianteDto>> GetAllFiltered(PagedAndSortedResultRequestDto input, string filter);

        List<DireccionFamiliarEstudianteDto> GetAllForSelect();
    }
}
