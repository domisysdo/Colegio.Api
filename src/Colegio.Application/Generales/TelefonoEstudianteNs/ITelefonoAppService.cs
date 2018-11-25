using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Colegio.Generales.TelefonoEstudianteNs
{
    public interface ITelefonoEstudianteAppService: IAsyncCrudAppService<TelefonoEstudianteDto, int, PagedAndSortedResultRequestDto, TelefonoEstudianteDto, TelefonoEstudianteDto>
    {
        Task<PagedResultDto<TelefonoEstudianteDto>> GetAllFiltered(PagedAndSortedResultRequestDto input, string filter);

        List<TelefonoEstudianteDto> GetAllForSelect();
    }
}
