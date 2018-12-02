using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Colegio.Inscripcion.ParentescoNs
{
    public interface IParentescoAppService: IAsyncCrudAppService<ParentescoDto, int, PagedAndSortedResultRequestDto, ParentescoDto, ParentescoDto>
    {
        Task<PagedResultDto<ParentescoDto>> GetAllFiltered(PagedAndSortedResultRequestDto input, string filter);

        List<ParentescoDto> GetAllForSelect();
    }
}
