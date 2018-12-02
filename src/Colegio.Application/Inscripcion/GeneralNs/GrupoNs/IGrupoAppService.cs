using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Colegio.Incripcion.GrupoNs
{
    public interface IGrupoAppService: IAsyncCrudAppService<GrupoDto, int, PagedAndSortedResultRequestDto, GrupoDto, GrupoDto>
    {
        Task<PagedResultDto<GrupoDto>> GetAllFiltered(PagedAndSortedResultRequestDto input, string filter);

        List<GrupoDto> GetAllForSelect();
        List<GrupoDto> GetAllForSelectByMateria(int materiaId);
    }
}
