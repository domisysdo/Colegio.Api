using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Colegio.Incripcion.FamiliarEstudianteNs
{
    public interface IFamiliarEstudianteAppService: IAsyncCrudAppService<FamiliarEstudianteDto, int, PagedAndSortedResultRequestDto, FamiliarEstudianteDto, FamiliarEstudianteDto>
    {
        Task<PagedResultDto<FamiliarEstudianteDto>> GetAllFiltered(PagedAndSortedResultRequestDto input, string filter);

        List<FamiliarEstudianteDto> GetAllForSelect();
    }
}
