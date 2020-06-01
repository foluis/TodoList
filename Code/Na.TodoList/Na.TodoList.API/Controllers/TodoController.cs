using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Na.TodoList.Data.Interfaces;
using Na.TodoList.Domain;

namespace Na.TodoList.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ILogger<TodoController> _logger;
        private readonly ITodoRepository _repository;

        public TodoController(ILogger<TodoController> logger, ITodoRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet("[action]")]
        public async Task<ActionResult> GetTodos()
        {
            try
            {
                List<Todo> result = await _repository.GetTodos();

                if (result == null)
                    return NotFound();

                return Ok(result);
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                _logger.LogError(ex.ToString());
                //return StatusCode(StatusCodes.Status500InternalServerError, "Error retriving trigger paths from database");
                return StatusCode(StatusCodes.Status500InternalServerError, error);

            }
        }

        [HttpGet("[action]/{id}")]
        public async Task<ActionResult> GetTodosById(int id)
        {
            try
            {
                Todo result = await _repository.GetTodosById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                _logger.LogError(error);
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retriving todos from database");
            }
        }

        [Authorize]
        [HttpPost("[action]")]
        public async Task<ActionResult> CreateTodo([FromBody] Todo todo)
        {
            try
            {
                if (todo == null)
                    return BadRequest();

                var result = await _repository.CreateTodo(todo);
                return CreatedAtAction(nameof(GetTodosById), new { id = todo.Id }, todo);
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                _logger.LogError(error);
                //return StatusCode(StatusCodes.Status500InternalServerError, "Error creating todo data in database");
                return StatusCode(StatusCodes.Status500InternalServerError, error);
            }
        }

        [HttpPut("[action]")]
        public async Task<ActionResult> UpdateTodoById(Todo newTodo)
        {
            try
            {
                if (newTodo == null)
                    return BadRequest();           

                var result = await _repository.UpdateTodo(newTodo);        
                return Ok(result);
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                _logger.LogError(error);
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating todo from database");
            }
        }
    }
}