using Microsoft.EntityFrameworkCore;
using Project.Models;
using MongoDB.Driver;

namespace GameApi.Services
{
    public class ProjectServices : IProjectService
    {
        private readonly IMongoCollection<ProjectModel> _context;

        public ProjectServices(MongoDbContext context)
        {
            _context = context.Projects;
        }

        public async Task<ProjectModel> CreateProject(ProjectDto projectDto)
        {
            var projectModel = new ProjectModel
            {
                Name = projectDto.Name,
                Description = projectDto.Description,
                TimeRequired = projectDto.TimeRequired,
                Difficulty = projectDto.Difficulty,
                IsComplete = false,
            };
            await _context.InsertOneAsync(projectModel);

            return projectModel;
        }

        public async Task<string> DeleteProjectById(string id)
        {
            await _context.DeleteOneAsync(u => u.Id == id);
            return id;
        }

        public async Task<List<ProjectModel>> GetAllProject()
        {
            return await _context.Find(user => true).ToListAsync();
        }

        public async Task<ProjectModel> GetProjectById(string id)
        {
            return await _context.Find(project => project.Id == id).FirstOrDefaultAsync();
        }

        public async Task<ProjectModel> UpdateProjectById(string id, ProjectDto projectDto)
        {
            var filter = Builders<ProjectModel>.Filter.Eq(p => p.Id, id);

            var updatedProject= new ProjectModel
            {
                Id = id,
                Name = projectDto.Name,
                Description = projectDto.Description,
                Difficulty = projectDto.Difficulty,
                TimeRequired = projectDto.TimeRequired
            };
            await _context.ReplaceOneAsync(filter, updatedProject);
            return updatedProject;
        }
    }
}