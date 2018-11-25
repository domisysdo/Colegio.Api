using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Colegio.Generales.EmailFamiliarEstudianteNs
{
    public interface IEmailFamiliarEstudianteAppService: IAsyncCrudAppService<EmailFamiliarEstudianteDto, int, PagedAndSortedResultRequestDto, EmailFamiliarEstudianteDto, EmailFamiliarEstudianteDto>
    {
        Task<PagedResultDto<EmailFamiliarEstudianteDto>> GetAllFiltered(PagedAndSortedResultRequestDto input, string filter);

        List<EmailFamiliarEstudianteDto> GetAllForSelect();
    }
}
