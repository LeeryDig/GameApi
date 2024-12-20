using GameApi.Services;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Project.Models;

namespace GameApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IMongoCollection<ProjectModel> _context;
        private readonly IProjectService _services;

        public ProjectController(MongoDbContext context, IProjectService services)
        {
            _context = context.Projects;
            _services = services;
        }

        // GET: api/Project
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjectModel>>> GetAllProjects()
        {
            try
            {
                var projects = await _services.GetAllProject();
                return Ok(projects);
            }
            catch (InvalidOperationException ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // GET: api/Project/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectModel>> GetProjectById(string id)
        {
            try
            {
                var project = await _services.GetProjectById(id);
                return Ok(project);
            }
            catch (InvalidOperationException ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // PUT: api/Project/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProjectById(string id, ProjectDto projectModel)
        {
            try
            {
                var project = await _services.UpdateProjectById(id, projectModel);
                return Ok(project);
            }
            catch (InvalidOperationException ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // POST: api/Project
        [HttpPost]
        public async Task<ActionResult<ProjectModel>> CreateProject(ProjectDto projectModel)
        {
            try
            {
                var project = await _services.CreateProject(projectModel);
                return Ok(project);
            }
            catch (InvalidOperationException ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // DELETE: api/Project/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProjectById(string id)
        {
            try
            {
                var result = await _services.DeleteProjectById(id);
                return Ok(result);
            }
            catch (InvalidOperationException ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


    }
}
