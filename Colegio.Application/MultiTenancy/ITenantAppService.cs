using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Colegio.MultiTenancy.Dto;

namespace Colegio.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}
