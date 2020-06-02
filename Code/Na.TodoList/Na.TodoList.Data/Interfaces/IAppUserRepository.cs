using Na.TodoList.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Na.TodoList.Data.Interfaces
{
    public interface IAppUserRepository
    {
        Task<List<AppUser>> GetUsers();
        Task<AppUser> GetUserById(int id);
        Task<int> CreateUser(AppUser todo);
        Task<int> UpdateUser(AppUser todo);
    }
}
