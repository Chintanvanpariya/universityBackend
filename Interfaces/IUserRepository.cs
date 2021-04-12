using UniversityServer.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;
using UniversityServer.Entities;

namespace UniversityServer.Interfaces
{
    public interface IUserRepository
    {
        void Update(AppUser user);

        //Task<IEnumerable<AppUser>> GetUsersAsync();

        //Task<AppUser> GetUserByNameAsync(string name);
        Task<AppUser> GetUserByIdAsync(int id);
        Task<IEnumerable<MemberDto>> GetMembersAsync();
        Task<MemberDto> GetMemberAsync(string name);
        Task<string> EnrollCourseAsync(int id);
        Task<bool> SaveAllAsync();
    }
}