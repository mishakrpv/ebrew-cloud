using System.Security.Cryptography;
using System.Text;

namespace eBrew.Cloud.KeyManagement.Application;

public static class Extensions
{
    public static string GetSecretKey()
    {
        var bytes = Guid.NewGuid().ToByteArray();

        using (var sha256 = SHA256.Create())
        {
            var hash = sha256.ComputeHash(bytes);

            return Encoding.UTF8.GetString(hash);
        }
    }
}