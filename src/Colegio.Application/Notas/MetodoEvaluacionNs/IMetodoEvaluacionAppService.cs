using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Colegio.Notas.MetodoEvaluacionNs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Colegio.Generales.MetodoEvaluacionNs
{
    public interface IMetodoEvaluacionAppService: IAsyncCrudAppService<MetodoEvaluacionDto, int, PagedAndSortedResultRequestDto, MetodoEvaluacionDto, MetodoEvaluacionDto>
    {
        Task<PagedResultDto<MetodoEvaluacionDto>> GetAllFiltered(PagedAndSortedResultRequestDto input, string filter);
        List<MetodoEvaluacionDto> GetAllForSelect();
    }
}
