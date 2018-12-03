using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Colegio.Inscripcion.MateriaNs
{
    public interface IMateriaAppService: IAsyncCrudAppService<MateriaDto, int, PagedAndSortedResultRequestDto, MateriaDto, MateriaDto>
    {
        Task<PagedResultDto<MateriaDto>> GetAllFiltered(PagedAndSortedResultRequestDto input, string filter);

        List<MateriaDto> GetAllForSelect();
    }
}
