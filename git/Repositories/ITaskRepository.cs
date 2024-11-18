using ex2.Models;

using System.Threading.Tasks;

namespace EX2.Repositories
{
    public interface ITaskRepository
    {
        IEnumerable<Tasks> GetTasks(); 
        void addTask(Tasks newTask);
        void DeleteTaskById(int id);
        //void SaveChanges(List<TaskModel> newListTasks);
        void updateTask(Tasks newTask);
        void addTaskInProject(Tasks newTask);
    }
}
