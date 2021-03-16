using System.Collections.Generic;
using System.Threading.Tasks;
using UniversityServer.DTOs;
using UniversityServer.Entities;

namespace UniversityServer.Interfaces
{
    public interface IUserRepository
    {
        void Update(AppUser user);
        Task<IEnumerable<AppUser>> GetUsersAsync();
        Task<AppUser> GetUserByIdAsync(int id);
        Task<AppUser> GetUserByUsernameAsync(string username);
       // Task<PagedList<MemberDto>> GetMembersAsync(UserParams userParams);
        //Task<MemberDto> GetMemberAsync(string username);
        Task<string> GetUserGender(string username);
    }
}