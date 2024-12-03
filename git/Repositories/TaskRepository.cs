
using ex2.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Threading.Tasks;

namespace EX2.Repositories
{
    public class TaskRepository: ITaskRepository
    {
        private readonly TasksDbContext _context;
        private readonly ILogger _logger;
        private readonly repositories.Logger.Logger _loggerFactory;

        public TaskRepository(TasksDbContext context, repositories.Logger.Logger _loggerFactory)
        {
            _context = context;
            _loggerFactory = loggerFactory;
            _logger = _logger.GetLogger(true);
        }

        public IEnumerable<Tasks> GetTasks()
        {

            return _context.Tasks.ToList();
        }
        public void addTask(Tasks newTask)
        {
            _context.Tasks.Add(newTask);
            _context.SaveChanges();

        }

        public void DeleteTaskById(int id)
        {
            Tasks? thisTask = _context.Tasks.Find(id);
            _context.Tasks.Remove(thisTask);
            _context.SaveChanges();

        }
        //public void SaveChanges(List<TaskModel> newListTasks)//כתיבת הרשימה כולל המשימה החדשה לקובץ
        //{
        //    if (!File.Exists(_filePath))
        //    {
        //        return;
        //    }
        //    var newList = JsonSerializer.Serialize(newListTasks);//ממיר  מגיסון למחרוזת
        //    File.WriteAllText(_filePath, newList);//מחזיר  משימות כמחרוזת
        //}
        public void updateTask(Tasks newTask)
        {
            Tasks? thisTask = _context.Tasks.Find(newTask.Id);
            _context.Tasks.Remove(thisTask);
            _context.Tasks.Add(newTask);
            _context.SaveChanges();
        }

        public void addTaskInProject(Tasks newTask)
        {
            _context.Tasks.Add(newTask);
            _context.SaveChanges();
        }
    }
}
