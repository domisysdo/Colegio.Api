using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Colegio.Generales.TelefonoFamiliarEstudianteNs
{
    public interface ITelefonoFamiliarEstudianteAppService: IAsyncCrudAppService<TelefonoFamiliarEstudianteDto, int, PagedAndSortedResultRequestDto, TelefonoFamiliarEstudianteDto, TelefonoFamiliarEstudianteDto>
    {
        Task<PagedResultDto<TelefonoFamiliarEstudianteDto>> GetAllFiltered(PagedAndSortedResultRequestDto input, string filter);

        List<TelefonoFamiliarEstudianteDto> GetAllForSelect();
    }
}
