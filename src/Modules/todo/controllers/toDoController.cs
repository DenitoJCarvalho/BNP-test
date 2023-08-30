
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

  #region RegisterTask
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

  #region ViewTask
  public async Task<List<ToDo>> ViewTask()
  {
    try
    {
      var items = await _context.ToDos.ToListAsync();

      return items;
    }
    catch (Exception ex)
    {
      throw new Exception(ex.Message);
    }
  }
  #endregion

  #region EditTask
  public async Task<ToDo> EditTask(Guid id)
  {
    try
    {
      var validateId = await _context.ToDos.FirstOrDefaultAsync(et => et.id.Equals(id));

      if (validateId is null)
      {
        throw new ArgumentNullException(nameof(validateId), $"Id não encontrado.");
      }

      var item = new ToDo
      {
        name = validateId.name,
        description = validateId.description
      };

      _context.ToDos.Update(item);
      await _context.SaveChangesAsync();

      return item;

    }
    catch (Exception ex)
    {
      throw new Exception(ex.Message);
    }
  }
  #endregion  

  #region DeleteTask
  public async Task<ToDo> DeleteTask(Guid id)
  {
    try
    {
      var validateId = await _context.ToDos.FirstOrDefaultAsync(dt => dt.id.Equals(id));

      if (validateId is null)
      {
        throw new ArgumentNullException(nameof(validateId), $"Id não encontrado para exclusão.");
      }

      _context.ToDos.Remove(validateId);
      await _context.SaveChangesAsync();

      return validateId;
    }
    catch (Exception ex)
    {
      throw new Exception(ex.Message);
    }
  }
  #endregion

  #region MarkAsCompleted
  public async Task<ToDo> MarkAsCompleted(Guid id)
  {
    try
    {
      var validateId = await _context.ToDos.FirstOrDefaultAsync(mac => mac.id.Equals(id));

      if (validateId is null)
      {
        throw new ArgumentNullException(nameof(validateId), $"Id não encontrado para atualização de tarefa.");
      }

      validateId.status = StatusTask.Concluido;
      validateId.dataCriacao = DateTime.Now;

      _context.ToDos.Update(validateId);
      await _context.SaveChangesAsync();

      return validateId;
    }
    catch (Exception ex)
    {
      throw new Exception(ex.Message);
    }
  }
  #endregion
}