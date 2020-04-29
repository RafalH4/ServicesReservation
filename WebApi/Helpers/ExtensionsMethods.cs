using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using WebApi.UserDirectory;

namespace WebApi.Helpers
{
    public static class ExtensionsMethods
    {
        public static bool CheckPassword(this User user, string password)
        {
            var hmac = new HMACSHA512(user.PasswordSalt);
            var computedHmac = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            for (int i = 0; i < user.PasswordHash.Length; i++)
            {
                if (user.PasswordHash[i] != computedHmac[i])
                    return false;
            }
            return true;
        }

        public static void AddApplicationError(this HttpResponse response, string message)
        {
            response.Headers.Add("Application-Error", message);
        }
    }
}
