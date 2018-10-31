using System.Threading.Tasks;
using Abp.Application.Services;
using Colegio.Authorization.Accounts.Dto;

namespace Colegio.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
