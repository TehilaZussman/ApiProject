using ex2.Models;
using EX2.Repositories;

using Microsoft.AspNetCore.Http.HttpResults;
using System.Threading.Tasks;

namespace EX2.services
{
    public class TaskService: ITaskService
    {
        private readonly ITaskRepository _taskRepository;
        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }


        public IEnumerable<Tasks> GetTasks()
        {
            return _taskRepository.GetTasks();
        }

        public void addTask(int Id, string Title, string Date, string Status, int UserId)
        {
            Tasks newTask = new Tasks();
            newTask.Id = Id;
            newTask.Date = Title;
            newTask.Date = Date;
            newTask.Status = Status;
            newTask.UserId = UserId;
         

            _taskRepository.addTask(newTask);
        }
        public void DeleteTaskById(int id)
        {
            _taskRepository.DeleteTaskById(id);
        }
        public void updateTask(Tasks newTask)
        {
            _taskRepository.updateTask(newTask);
        }

        public IEnumerable<Tasks> getTasksById(int id)
        {
            var UserTasks = new List<Tasks>();
            var list = _taskRepository.GetTasks();

            foreach(var e in list)
            {
                if (e.UserId == id)
                    UserTasks.Add(e);
            }

            if (UserTasks != null)
                return UserTasks;
            else
                return null;
        }

        public void addTaskInProject(int Id, string Title, string Date, string Status, int ProjectId)
        {
            Tasks newTask = new Tasks();
            newTask.Id = Id;
            newTask.Date = Title;
            newTask.Date = Date;
            newTask.Status = Status;
            newTask.ProjectId = ProjectId;
            _taskRepository.addTaskInProject(newTask);
        }


    }
}