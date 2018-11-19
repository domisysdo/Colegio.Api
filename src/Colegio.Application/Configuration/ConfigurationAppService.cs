using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using Colegio.Configuration.Dto;

namespace Colegio.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : ColegioAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
