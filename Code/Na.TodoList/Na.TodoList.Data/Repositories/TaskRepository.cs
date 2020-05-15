using Na.TodoList.Data.Interfaces;
using Na.TodoList.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Na.TodoList.Data.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        public Task<int> CreateTodo(Todo todo)
        {
            throw new NotImplementedException();
        }

        public Task<List<Todo>> GetTodos()
        {
            throw new NotImplementedException();
        }

        public Task<Todo> GetTodosById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateExaVaultPath(Todo todo)
        {
            throw new NotImplementedException();
        }
    }
}
