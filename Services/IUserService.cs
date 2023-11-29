using StundenplanApp.Models;

namespace StundenplanApp.Services
{
    public interface IUserService
    {
        public Task<Users> createUser(Users newUser);
        public Task<Users> deleteUser(int userID);
        public Task<Users> getUser(int userID);
        public Task<Users> editUser(Users userToEdit);
    }
}
