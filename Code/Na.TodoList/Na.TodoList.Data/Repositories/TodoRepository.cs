using Microsoft.EntityFrameworkCore;
using Na.TodoList.Data.Interfaces;
using Na.TodoList.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Na.TodoList.Data.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private readonly TodoContext _context;

        public TodoRepository(TodoContext context)
        {
            _context = context;
        }

        public async Task<int> CreateTodo(Todo todo)
        {
            _context.Add(todo);
            await _context.SaveChangesAsync();

            return todo.Id;
        }

        public async Task<List<Todo>> GetTodos()
        {
            List<Todo> paths = new List<Todo>();

            paths = await _context.Todos.ToListAsync();

            return paths;
        }

        public async Task<Todo> GetTodosById(int id)
        {
            Todo path = await _context.Todos.FindAsync(id);

            return path;
        }

        public async Task<int> UpdateTodo(Todo todo)
        {
            Todo currentExaVaultPath = await _context.Todos.FindAsync(todo.Id);

            _context.Entry(currentExaVaultPath).State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }
    }
}
