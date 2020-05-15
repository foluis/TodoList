using Na.TodoList.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Na.TodoList.Data.Interfaces
{
    public interface ITaskRepository
    {
        Task<List<Todo>> GetTodos();
        Task<Todo> GetTodosById(int id);
        Task<int> CreateTodo(Todo todo);        
        Task<int> UpdateExaVaultPath(Todo todo);
    }
}
