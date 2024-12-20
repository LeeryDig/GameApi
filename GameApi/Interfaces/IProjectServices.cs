using Project.Models;

namespace GameApi.Services
{
    public interface IProjectService
    {
        Task<List<ProjectModel>> GetAllProject();
        Task<ProjectModel> GetProjectById(string id);
        Task<ProjectModel> CreateProject(ProjectDto projectDto);
        Task<ProjectModel> UpdateProjectById(string id, ProjectDto projectDto);
        Task<string> DeleteProjectById(string id);
    }
}