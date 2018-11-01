using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Colegio.Models.EstudianteNs;
using Colegio.Roles.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Colegio.EstudianteNs
{
    public interface IEstudianteAppService: IAsyncCrudAppService<EstudianteDto, int, PagedResultRequestDto, EstudianteDto, EstudianteDto>
    {
        //PagedResultDto<EstudianteDto> GetAll();
        //override Task Create(EstudianteDto input);
        //void Update(EstudianteDto input);
        //void Delete(DeleteEstudianteInput input);
        //EstudianteDto GetEstudianteById(GetEstudianteInput input);
        Task<ListResultDto<RoleDto>> GetRoles();
    }
}
