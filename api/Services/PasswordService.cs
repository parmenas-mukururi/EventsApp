using api.Interfaces;
using BC = BCrypt.Net.BCrypt;


namespace api.Services
{
    public class PasswordService : IPasswordService
    {
        public string HashPassword(string password)
        {
            return BC.HashPassword(password);
        }

        public bool VerifyHashedPassword(string password, string hashedPassword)
        {
            return BC.Verify(password, hashedPassword);
        }
    }
}
