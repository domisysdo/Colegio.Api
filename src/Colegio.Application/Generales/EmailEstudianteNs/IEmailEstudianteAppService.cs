using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Colegio.Models.Generales.EmailEstudianteNs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Colegio.Generales.EmailEstudianteNs
{
    public interface IEmailEstudianteAppService: IAsyncCrudAppService<EmailEstudianteDto, int, PagedAndSortedResultRequestDto, EmailEstudianteDto, EmailEstudianteDto>
    {
        Task<PagedResultDto<EmailEstudianteDto>> GetAllFiltered(PagedAndSortedResultRequestDto input, string filter);
        void DeleteAll(List<EmailEstudiante> emailEstudiantes);
        List<EmailEstudianteDto> GetAllForSelect();
    }
}
