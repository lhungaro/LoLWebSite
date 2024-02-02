using Freela.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Freela.Persistence.Repository
{
    public interface IProjectRepository
    {
        Task<Project> GetProjectByIdAsync(int Id, bool includeUser);
        Task<Project[]> GetAllProjects(bool includeUser);
        Task<Project[]> GetAllProjectsByAreaAsync(string Area, bool includeUser);

    }
}
