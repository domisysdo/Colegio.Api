using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Colegio.Generales.IncidenciaEstudianteNs
{
    public interface IIncidenciaEstudianteAppService: IAsyncCrudAppService<IncidenciaEstudianteDto, int, PagedAndSortedResultRequestDto, IncidenciaEstudianteDto, IncidenciaEstudianteDto>
    {
        Task<PagedResultDto<IncidenciaEstudianteDto>> GetAllFiltered(PagedAndSortedResultRequestDto input, string filter);

        List<IncidenciaEstudianteDto> GetAllForSelect();
    }
}
