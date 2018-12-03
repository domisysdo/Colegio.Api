using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Colegio.Inscripcion.InscripcionNs
{
    public interface IInscripcionAppService: IAsyncCrudAppService<InscripcionDto, int, PagedAndSortedResultRequestDto, InscripcionDto, InscripcionDto>
    {
        Task<PagedResultDto<InscripcionDto>> GetAllFiltered(PagedAndSortedResultRequestDto input, string filter);

        List<InscripcionDto> GetAllForSelect();
    }
}
