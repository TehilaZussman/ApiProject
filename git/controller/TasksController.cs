using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using EX2.services;
using ex2.Models;

namespace EX2.controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITaskService _taskService;
        public TasksController(ITaskService taskService)
        {
            _taskService = taskService;
        }


        [HttpGet]
        public IEnumerable<Tasks> GetTasks()
        {
            return _taskService.GetTasks();
        }


        [HttpPost]
        public IActionResult AddTask(int Id, string Title, string Date, string Status, int UserId)
        {
            _taskService.addTask(Id, Title,Date, Status, UserId); 
            return CreatedAtAction(nameof(GetTasks), new { id = Id , Title= Title ,date = Date , status = Status, UserId= UserId });
        }


        [HttpDelete]
        public IActionResult deleteTask([FromQuery] int id)
        {
            _taskService.DeleteTaskById(id);
            return Ok();
        }


        [HttpPut]
        public IActionResult updateTask([FromBody] Tasks newTask)
        {
            _taskService.updateTask(newTask);
            return Ok();
        }



        [HttpGet("{id}")]

        public IActionResult getTasksById(int id)
        {
            if (_taskService.getTasksById(id) != null)
                return Ok(_taskService.getTasksById(id));
            else
                return BadRequest("not undefind");
           
        }


        [HttpPost("{Id}")]
        public IActionResult AddTaskInProject(int Id, string Title, string Date, string Status, int ProjectId)
        {
            _taskService.addTaskInProject(Id, Title, Date, Status, ProjectId);
            return CreatedAtAction(nameof(GetTasks), new { id = Id, Title = Title, date = Date, status = Status, ProjectId = ProjectId });
        }



    }
}
