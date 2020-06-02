using Microsoft.EntityFrameworkCore;
using Na.TodoList.Data.Interfaces;
using Na.TodoList.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Na.TodoList.Data.Repositories
{
    public class AppUserRepository : IAppUserRepository
    {
        private readonly TodoContext _context;

        public AppUserRepository(TodoContext context)
        {
            _context = context;
        }

        public async Task<int> CreateUser(AppUser appUser)
        {
            _context.Add(appUser);
            await _context.SaveChangesAsync();

            return appUser.Id;
        }

        public async Task<List<AppUser>> GetUsers()
        {
            List<AppUser> appUser = new List<AppUser>();

            appUser = await _context.AppUsers.ToListAsync();

            return appUser;
        }

        public async Task<AppUser> GetUserById(int id)
        {
            AppUser appUser = await _context.AppUsers.FindAsync(id);

            return appUser;            
        }

        public async Task<int> UpdateUser(AppUser appUser)
        {
            Todo currentExaVaultPath = await _context.Todos.FindAsync(appUser.Id);

            _context.Entry(currentExaVaultPath).State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }
    }
}
