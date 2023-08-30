
namespace backend_challenge.Modules.todo;

public class ToDo
{
    public Guid id { get; set; }
    public string name { get; set; }
    public string description { get; set; }
    public StatusTask status { get; set; }
    public DateTime dataCriacao { get; set; }
    public DateTime dataConclusao { get; set; }

    public ToDo()
    {
        id = Guid.NewGuid();
        dataCriacao = DateTime.UtcNow;
        status = StatusTask.Pendente;
    }
}

#region Status
public enum StatusTask
{
    Pendente = 1,
    EmAndamento = 2,
    Concluido = 3
}
#endregion