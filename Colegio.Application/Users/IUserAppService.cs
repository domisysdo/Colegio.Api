using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Colegio.Roles.Dto;
using Colegio.Users.Dto;

namespace Colegio.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedAndSortedResultRequestDto, CreateUserDto, UserDto>
    {
        Task<ListResultDto<RoleDto>> GetRoles();

        Task<PagedResultDto<UserDto>> GetAllFiltered(PagedAndSortedResultRequestDto input, string filter);

        Task ChangeLanguage(ChangeUserLanguageDto input);
    }
}
