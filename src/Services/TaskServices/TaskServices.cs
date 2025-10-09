using Domain.Enum;
using Domain.Entites;
using Tasks = Domain.Entites.Task;
using System.Text.Json;
using Task = System.Threading.Tasks.Task;

namespace Service.TaskServices;

public interface ITaskServices
{
    public Task AddTask(Tasks task);
    public Task UpdateTask(Tasks task);
    public Task<List<Tasks>>  ListAllTask(Status? status);
}
public class TaskServices : ITaskServices
{
    private readonly StreamReader _streamReader;
    private readonly StreamWriter _streamWriter;
    private readonly string _filePath;
    public TaskServices()
    {
        _filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "data.json");
        // Ensure the file exists
        using var fileStream = new FileStream(_filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
        _streamReader = new StreamReader(fileStream);
        _streamWriter = new StreamWriter(fileStream);
    }
    public async Task AddTask(Tasks task)
    {
        using var reader = new StreamReader(_filePath);
        var jsonContent = await reader.ReadToEndAsync();
        var data = JsonSerializer.Deserialize<List<Tasks>>(jsonContent);
        //Get last id
        var lastId = data == null || data.Count == 0 ? 0 : data.Max(t => t.Id);
        task.Id = lastId + 1;
        task.createAt = DateTime.Now;
        task.updatedAt = DateTime.Now;
        await _streamWriter.WriteLineAsync(JsonSerializer.Serialize(task));
        
    }
    public Task UpdateTask(Tasks task)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Tasks>> ListAllTask(Status? status)
    {
        using var reader = new StreamReader(_filePath);
        var jsonContent = await reader.ReadToEndAsync();
        var data = JsonSerializer.Deserialize<List<Tasks>>(jsonContent);
        if(data == null) return [];
        return status switch
        {
            Status.Todo => data.Where(t => t.status == Status.Todo).ToList(),
            Status.InProgress => data.Where(t => t.status == Status.InProgress).ToList(),
            Status.Done => data.Where(t => t.status == Status.Done).ToList(),
            _ => data
        };
    }
}