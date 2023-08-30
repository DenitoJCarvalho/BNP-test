
namespace backend_challenge.Modules.todo;

public interface ITask
{
    Task<ToDo> RegisterTask(ToDo entity);

    Task<List<ToDo>> ViewTask();

    Task<ToDo> EditTask(Guid id);

    Task<ToDo> DeleteTask(Guid id);

    Task<ToDo> MarkAsCompleted(Guid id);
}
