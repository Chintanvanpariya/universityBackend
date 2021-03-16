using UniversityServer.Entities;

namespace UniversityServer.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}