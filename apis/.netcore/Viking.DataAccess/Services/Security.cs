using System;
using System.Security.Cryptography;
using System.Text;

namespace Viking.DataAccess
{
    public class Security
    {
        public string CreatePasswordHash(string password)
        {
            //TODO::
            string passwordSalt = "Viking-seed-Salt";

            using (HMACSHA256 hmac = new HMACSHA256(Encoding.UTF8.GetBytes(passwordSalt)))
            {
                byte[] passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                
                return Convert.ToBase64String(passwordHash);
            }
        }

        public bool VerifyPasswordHash(string passwordInput, string passwordStored)
        {
            //TODO::
            string passwordSalt = "Viking-seed-Salt";



            byte[] PasswordFromBase = System.Convert.FromBase64String(passwordStored);

            using (HMACSHA256 hmac = new HMACSHA256(Encoding.UTF8.GetBytes(passwordSalt)))
            {
                byte[] passwordFromUser = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(passwordInput));

                for (int i = 0; i < passwordFromUser.Length; i++)
                {
                    if (passwordFromUser[i] != PasswordFromBase[i])
                        return false;
                }
            }
            return true;
        }

    }
}
