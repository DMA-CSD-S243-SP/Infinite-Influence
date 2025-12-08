using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BCrypt.Net;

namespace DataAccessLibrary
{
    public static class BCrypter
    {
        public static string SaltHashed(this string secret)
        {
            return BCrypt.Net.BCrypt.EnhancedHashPassword(secret, workFactor: 20);
        }

        public static bool ValidateHash(this string unencrypted, string hash)
        {
            return BCrypt.Net.BCrypt.EnhancedVerify(unencrypted, hash);
        }
    }
}
