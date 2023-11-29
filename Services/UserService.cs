using Microsoft.EntityFrameworkCore;
using StundenplanApp.Data;
using StundenplanApp.Models;

namespace StundenplanApp.Services
{
    public class UserService : IUserService
    {
        public readonly DataContext dataContext;
        public UserService(DataContext dataContext) { 
            this.dataContext = dataContext;
        }

        public async Task<Users> createUser(Users newUser)
        {
            Users users = new Users
            {
                Name = newUser.Name,
                Klasse = newUser.Klasse
            };
            await dataContext.Users.AddAsync(users);
            await dataContext.SaveChangesAsync();
            return users;
        }
        public async Task<Users> deleteUser(int userID)
        {
            Users user = await dataContext.Users.FirstOrDefaultAsync(u => u.ID == userID);
            dataContext.Users.Remove(user);
            await dataContext.SaveChangesAsync();
            return user;
        }
        public async Task<Users> getUser(int userID)
        {
            Users user = await dataContext.Users.FirstOrDefaultAsync(u => u.ID == userID);
            return user;
        }
        public async Task<Users> editUser(Users userToEdit)
        {
            Users user = await dataContext.Users.FirstOrDefaultAsync(u => u.ID == userToEdit.ID);
            user.Name = userToEdit.Name;
            user.Klasse = userToEdit.Klasse;
            dataContext.Users.Update(user);
            await dataContext.SaveChangesAsync();
            return user;
        }
    }
}
