using System.Threading.Tasks;
using UniversityServer.Entities;

namespace UniversityServer.Interfaces
{
    public interface ITokenService
    {
        Task<string> CreateToken(AppUser user);
    }
}