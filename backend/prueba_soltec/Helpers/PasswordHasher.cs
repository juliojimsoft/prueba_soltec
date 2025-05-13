using BCrypt.Net;

namespace prueba_soltec.Helpers
{
    public class PasswordHasher
    {

        private const int WorkFactor = 12;

        public static string Hash(string password)
        {
            return BCrypt.Net.BCrypt.EnhancedHashPassword(password,BCrypt.Net.HashType.SHA512, WorkFactor);
        }
        public static bool Verify(string password, string hashedPassword)
        {
            try
            {
                return BCrypt.Net.BCrypt.EnhancedVerify(password, hashedPassword, HashType.SHA512);
            }
            catch (SaltParseException)
            {
                return false;
            }
        }
        public static bool NeedsUpgrade(string hashedPassword)
        {
            return BCrypt.Net.BCrypt.PasswordNeedsRehash(hashedPassword, WorkFactor);
        }
    }
}
