using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Colegio.Roles.Dto;

namespace Colegio.Roles
{
    public interface IRoleAppService : IAsyncCrudAppService<RoleDto, int, PagedAndSortedResultRequestDto, CreateRoleDto, RoleDto>
    {
        Task<ListResultDto<PermissionDto>> GetAllPermissions();

        Task<GetRoleForEditOutput> GetRoleForEdit(EntityDto input);

        Task<ListResultDto<RoleListDto>> GetRolesAsync(GetRolesInput input);

        Task<PagedResultDto<RoleDto>> GetAllFiltered(PagedAndSortedResultRequestDto input, string filter);

        void DeleteMultipleRoles(List<RoleDto> roleList);

    }
}