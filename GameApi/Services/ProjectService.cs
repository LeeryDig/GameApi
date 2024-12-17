using GameApi.Services;
using Microsoft.EntityFrameworkCore;
using Project.Models;

namespace GameApi.Services
{
    public class ProjectServices : IProjectService
    {
        private readonly ProjectContext _context;

        public ProjectServices(ProjectContext context)
        {
            _context = context;
        }

        public async Task<ProjectModel> CreateProject(ProjectDto projectDto)
        {
            var projectModel = new ProjectModel
            {
                Name = projectDto.Name,
                TimeRequired = projectDto.TimeRequired,
                Difficulty = projectDto.Difficulty,
                IsComplete = false,
            };
            _context.ProjectModels.Add(projectModel);
            await _context.SaveChangesAsync();

            return projectModel;
        }

        public async Task<long> DeleteProjectById(long id)
        {
            if (_context.ProjectModels == null)
            {
                throw new KeyNotFoundException($"User with ID {id} was not found.");
            }
            var userModel = await _context.ProjectModels.FindAsync(id);
            if (userModel == null)
            {
                throw new KeyNotFoundException($"User Not Found.");
            }

            _context.ProjectModels.Remove(userModel);
            await _context.SaveChangesAsync();

            return id;
        }

        public async Task<IEnumerable<ProjectModel>> GetAllProject()
        {
            if (_context.ProjectModels == null)
            {
                return Enumerable.Empty<ProjectModel>();
            }

            return await _context.ProjectModels.ToListAsync();
        }

        public async Task<IEnumerable<ProjectModel>> GetProjectById(long id)
        {
            if (_context.ProjectModels == null)
            {
                return Enumerable.Empty<ProjectModel>();
            }
            var projectModel = await _context.ProjectModels.FindAsync(id);

            if (projectModel == null)
            {
                return Enumerable.Empty<ProjectModel>();
            }

            return await _context.ProjectModels.ToListAsync();
        }

        public async Task<long> UpdateProjectById(long id, ProjectDto projectDto)
        {
            var existingUser = await _context.ProjectModels.FindAsync(id);

            if (existingUser == null)
            {
                throw new KeyNotFoundException($"User with ID {id} was not found.");
            }

            existingUser.Name = projectDto.Name;
            existingUser.TimeRequired = projectDto.TimeRequired;
            existingUser.Difficulty = projectDto.Difficulty;

            await _context.SaveChangesAsync();
            return id;
        }

        private bool ProjectModelExists(long id)
        {
            return (_context.ProjectModels?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}