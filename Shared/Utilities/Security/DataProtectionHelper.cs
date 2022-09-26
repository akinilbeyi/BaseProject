using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shared.Utilities.Service;
using System.Text;

namespace Shared.Utilities.Security;
public class DataHashingHelper
{
    private IDataProtector? _dataProtector;
    public DataHashingHelper(IConfiguration configuration)
    {
        var dataProtector = ServiceCollectionHelper.ServiceProvider?.GetService<IDataProtectionProvider>();

        _dataProtector = dataProtector?.CreateProtector(configuration["ProtectionKey"]);

    }

    public byte[]? Protect(string value)
    {
        return _dataProtector?.Protect(Encoding.UTF8.GetBytes(value));
    }
    public string? UnProtect(byte[] value)
    {
        return Encoding.UTF8.GetString(_dataProtector?.Unprotect(value)!);
    }

}
