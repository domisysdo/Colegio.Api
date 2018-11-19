using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Colegio.Roles.Dto;
using System.Threading.Tasks;

namespace Colegio.EstudianteNs
{
    public interface IEstudianteAppService: IAsyncCrudAppService<EstudianteDto, int, PagedResultRequestDto, EstudianteDto, EstudianteDto>
    {
        Task<ListResultDto<RoleDto>> GetRoles();
    }
}
