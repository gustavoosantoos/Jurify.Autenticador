using Jurify.Autenticador.Domain.Services.Abstractions;
using Crypto = BCrypt.Net.BCrypt;

namespace Jurify.Autenticador.Domain.Services.Implementations
{
    public class HashService : IHashService
    {
        public string Hash(string source)
        {
            return Crypto.HashPassword(source);
        }

        public bool Verify(string hash, string password)
        {
            return Crypto.Verify(password, hash);
        }
    }
}
