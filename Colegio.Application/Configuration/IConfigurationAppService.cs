using System.Threading.Tasks;
using Colegio.Configuration.Dto;

namespace Colegio.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
