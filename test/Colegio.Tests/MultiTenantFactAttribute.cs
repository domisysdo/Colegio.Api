using Xunit;

namespace Colegio.Tests
{
    public sealed class MultiTenantFactAttribute : FactAttribute
    {
        public MultiTenantFactAttribute()
        {
            if (!ColegioConsts.MultiTenancyEnabled)
            {
                Skip = "MultiTenancy is disabled.";
            }
        }
    }
}
