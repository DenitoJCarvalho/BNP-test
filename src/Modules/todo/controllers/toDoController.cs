
using backend_challenge.context;

namespace backend_challenge.Modules.todo;

public class TodoController : ITask
{

  private readonly AppDbContext _context;

  public TodoController(
    AppDbContext context
  )
  {
    this._context = context;
  }

  #region Register Task
  public async Task<ToDo> RegisterTask(ToDo entity)
  {
    try
    {
      _context.ToDos.Add(entity);
      await _context.SaveChangesAsync();

      return entity;

    }
    catch (Exception ex)
    {
      throw new Exception(ex.Message);
    }
  }
  #endregion
}