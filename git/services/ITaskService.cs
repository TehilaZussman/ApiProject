using ex2.Models;

using System.Threading.Tasks;

namespace EX2.services
{
    public interface ITaskService
    {
        IEnumerable<Tasks> GetTasks();
        void addTask(int Id, string Title, string Date, string Status, int UserId);
        void DeleteTaskById(int id);
        void updateTask(Tasks newTask);
        IEnumerable<Tasks> getTasksById(int id);
        void addTaskInProject(int Id, string Title, string Date, string Status, int ProjectId);
    }
}
