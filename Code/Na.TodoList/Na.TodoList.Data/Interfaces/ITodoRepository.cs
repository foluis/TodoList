using Na.TodoList.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Na.TodoList.Data.Interfaces
{
    public interface ITodoRepository
    {
        Task<List<Todo>> GetTodos();
        Task<Todo> GetTodosById(int id);
        Task<int> CreateTodo(Todo todo);
        Task<int> UpdateTodo(Todo todo);
    }
}
