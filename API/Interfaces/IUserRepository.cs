using API.DTOs;
using API.Entities;

namespace API.Interfaces
{
    public interface IUserRepository
    {
        public Task<User> GetUserById(int id);
        public Task<User> GetUserByUsername(string username);
        public Task<IEnumerable<User>> GetAllUsers();
        public Task<MemberDTO> GetMember(string username);
        public Task<IEnumerable<MemberDTO>> GetAllMembers();
    }
}
