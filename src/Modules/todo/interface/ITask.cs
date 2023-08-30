
namespace backend_challenge.Modules.todo;

public interface ITask
{
    Task<ToDo> RegisterTask(ToDo entity);
}
