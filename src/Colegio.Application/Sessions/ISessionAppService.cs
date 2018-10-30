using System.Threading.Tasks;
using Abp.Application.Services;
using Colegio.Sessions.Dto;

namespace Colegio.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
