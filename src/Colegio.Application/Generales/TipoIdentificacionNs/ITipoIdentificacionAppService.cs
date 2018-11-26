using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Colegio.Generales.TipoIdentificacionNs
{
    public interface ITipoIdentificacionAppService: IAsyncCrudAppService<TipoIdentificacionDto, int, PagedAndSortedResultRequestDto, TipoIdentificacionDto, TipoIdentificacionDto>
    {
        Task<PagedResultDto<TipoIdentificacionDto>> GetAllFiltered(PagedAndSortedResultRequestDto input, string filter);

        List<TipoIdentificacionDto> GetAllForSelect();
    }
}
