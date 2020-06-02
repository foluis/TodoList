using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Na.TodoList.API.Controllers
{
    [Route("api/[controller]")]

    [ApiController]
    public class AppUserController : ControllerBase
    {
        private readonly ILogger<AppUserController> _logger;

        //private readonly ITodoRepository _repository;

        //public TodoController(ILogger<TodoController> logger, ITodoRepository repository)
        //{
        //    _logger = logger;
        //    _repository = repository;
        //}

        //[HttpGet("[action]")]
        //public async Task<ActionResult> GetTodos()
        //{
        //    try
        //    {
        //        List<Todo> result = await _repository.GetTodos();

        //        if (result == null)
        //            return NotFound();

        //        return Ok(result);
        //    }
        //    catch (Exception ex)
        //    {
        //        string error = ex.ToString();
        //        _logger.LogError(ex.ToString());
        //        return StatusCode(StatusCodes.Status500InternalServerError, "Error retriving trigger paths from database");
        //    }
        //}

        //[HttpGet("[action]")]
        //public async Task<ActionResult> GetTodosById(int id)

        //{
        //    try
        //    {
        //        Todo result = await _repository.GetTodosById(id);
        //        return Ok(result);
        //    }
        //    catch (Exception ex)
        //    {
        //        string error = ex.ToString();
        //        _logger.LogError(error);
        //        return StatusCode(StatusCodes.Status500InternalServerError, "Error retriving todos from database");
        //    }
        //}

        //[HttpPost("[action]")]
        //public async Task<ActionResult> CreateTodo([FromBody] Todo todo)
        //{
        //    try

        //    {
        //        if (todo == null)

        //            return BadRequest();

        //        var result = await _repository.CreateTodo(todo);

        //        return CreatedAtAction(nameof(GetTodosById), new { id = todo.Id }, todo);

        //    }

        //    catch (Exception ex)

        //    {
        //        string error = ex.ToString();

        //        _logger.LogError(error);

        //        return StatusCode(StatusCodes.Status500InternalServerError, "Error creating todo data in database");

        //    }

        //}

        //[HttpPut("[action]")]

        //public async Task<ActionResult> UpdateTodoById(Todo newTodo)

        //{
        //    try

        //    {
        //        if (newTodo == null)

        //            return BadRequest();

        //        var result = await _repository.UpdateTodo(newTodo);

        //        return Ok(result);

        //    }

        //    catch (Exception ex)

        //    {
        //        string error = ex.ToString();

        //        _logger.LogError(error);

        //        return StatusCode(StatusCodes.Status500InternalServerError, "Error updating todo from database");

        //    }

        //}
    }
}