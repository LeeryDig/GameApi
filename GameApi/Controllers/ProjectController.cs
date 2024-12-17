using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Models;

namespace GameApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly ProjectContext _context;
        private readonly IProjectService _services;

        public ProjectController(ProjectContext context, IProjectService services)
        {
            _context = context;
            _services = services;
        }

        // GET: api/Project
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjectModel>>> GetProjectModels()
        {
            var users = await _services.GetAllProject();
            return Ok(users);
        }

        // GET: api/Project/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectModel>> GetProjectModel(long id)
        {
            var users = await _services.GetProjectById(id);

            if (!users.Any())
            {
                return NotFound();
            }

            return Ok(users);
        }

        // PUT: api/Project/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProjectModel(long id, ProjectDto projectModel)
        {
            try
            {
                var result = await _services.UpdateProjectById(id, projectModel);
                return base.CreatedAtAction(nameof(GetProjectModels), result);
            }
            catch (InvalidOperationException ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // POST: api/Project
        [HttpPost]
        public async Task<ActionResult<ProjectModel>> PostProjectModel(ProjectDto projectModel)
        {
            try
            {
                var createProject = await _services.CreateProject(projectModel);
                return CreatedAtAction(nameof(GetProjectModels), createProject);
            }
            catch (InvalidOperationException ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // DELETE: api/Project/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProjectModel(long id)
        {
            try
            {
                var user = await _services.DeleteProjectById(id);
                return CreatedAtAction(nameof(GetProjectModels), user);
            }
            catch (InvalidOperationException ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


    }
}
