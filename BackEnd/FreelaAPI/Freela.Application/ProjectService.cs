using Freela.Application.Contratos;
using Freela.Domain.Models;
using Freela.Persistence.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Freela.Application
{
    public class ProjectService : IProjectService
    {
        private readonly IFreelaRepository _freelaRepository;
        private readonly IProjectRepository _projectRepository;

        public ProjectService(IFreelaRepository freelaRepository, IProjectRepository projectRepository)
        {
            _freelaRepository = freelaRepository;
            _projectRepository = projectRepository;
        }
        public async Task<Project> AddProject(Project model)
        {
            try
            {
                _freelaRepository.Add<Project>(model);
                if (await _freelaRepository.SaveChangesAsync())
                    return await _projectRepository.GetProjectByIdAsync(model.Id, false);

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<Project> UpdateProject(int projectId, Project model)
        {
            try
            {
                var project = await _projectRepository.GetProjectByIdAsync(projectId, false);
                if(project == null) return null;

                model.Id = project.Id;

                _freelaRepository.Update(model);

                if (await _freelaRepository.SaveChangesAsync())
                    return await _projectRepository.GetProjectByIdAsync(model.Id, false);

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<bool> DeleteProject(int projectId)
        {
            try
            {
                var project = await _projectRepository.GetProjectByIdAsync(projectId, false);
                if (project == null) throw new Exception("Projeto não encontrado!");

                _freelaRepository.Delete<Project>(project);

                return await _freelaRepository.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Project[]> GetAllProjects(bool includeUser)
        {
            try
            {
                var projects = await _projectRepository.GetAllProjects(false);
                if (projects == null) return null;

                return projects;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Project[]> GetAllProjectsByAreaAsync(string Area, bool includeUser = false)
        {
            try
            {
                var projects = await _projectRepository.GetAllProjectsByAreaAsync(Area, includeUser);
                if (projects == null) return null;

                return projects;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Project> GetProjectByIdAsync(int Id, bool includeUser = false)
        {
            try
            {
                var projects = await _projectRepository.GetProjectByIdAsync(Id, includeUser);
                if (projects == null) return null;

                return projects;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

   
    }
}
