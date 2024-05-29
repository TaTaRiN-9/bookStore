using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace TestWebApi.Core.Auth
{
    public class AuthOptions
    {
        public const string ISSUER = "BooksServer";
        public const string AUDIENCE = "BooksClient";
        // key необходимо хранить в файле приложения, например, appsettings.json
        // ключ, который будет применяться для создания токена
        private const string KEY = "DjFgfdKJfASsJFLJPdSdsFJZlMoCPKDA_DSKJakdAsYUPbkMhHAQGrwReR";
        // возвращает ключ безопасности, который применяется для генерации токена
        public static SymmetricSecurityKey GetSymmetricSecurityKey() =>
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY));
    }
}
