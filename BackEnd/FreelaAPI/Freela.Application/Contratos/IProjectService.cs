using Freela.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Freela.Application.Contratos
{
    public interface IProjectService
    {
        Task<Project> AddProject(Project model);
        Task<Project> UpdateProject(int projectId, Project model);
        Task <bool>DeleteProject(int projectId);
        Task<Project[]> GetAllProjects(bool includeUser);
        Task<Project[]> GetAllProjectsByAreaAsync(string Area, bool includeUser = false);
        Task<Project> GetProjectByIdAsync(int Id, bool includeUser = false);

    }
}
