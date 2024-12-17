using Project.Models;

namespace GameApi.Services
{
    public interface IProjectService
    {
        Task<IEnumerable<ProjectModel>> GetAllProject();
        Task<IEnumerable<ProjectModel>> GetProjectById(long id);
        Task<ProjectModel> CreateProject(ProjectDto projectDto);
        Task<long> UpdateProjectById(long id, ProjectDto projectDto);
        Task<long> DeleteProjectById(long id);
    }
}