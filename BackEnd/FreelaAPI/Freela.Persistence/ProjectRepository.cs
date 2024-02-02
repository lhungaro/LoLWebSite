using Freela.Domain.Models;
using Freela.Persistence.Repository;
using FreelaAPI.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Freela.Persistence
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly FreelaContext _context;

        public ProjectRepository(FreelaContext context)
        {
            _context = context;
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
        public async Task<Project[]> GetAllProjects(bool includeUser = false)
        {
            IQueryable<Project> query = _context.Projects.Include(p => p.Company);
            query = query.OrderBy(p => p.Id);

            if (includeUser) { 
                query = query
                    .Include(p => p.UserProjects)
                    .ThenInclude(p => p.User); 
            }

            return await query.ToArrayAsync();
        }

        public async Task<Project[]> GetAllProjectsByAreaAsync(string Area, bool includeUser = false)
        {
            IQueryable<Project> query = _context.Projects.Include(p => p.Company);
            query = query
                .OrderBy(p => p.Id)
                .Where(p => p.Area.ToLower()
                .Contains(Area.ToLower()));

            if (includeUser)
            {
                query = query
                    .Include(p => p.UserProjects)
                    .ThenInclude(p => p.User);
            }

            return await query.ToArrayAsync();
        }

        public async Task<Project> GetProjectByIdAsync(int Id, bool includeUser = false)
        {
            IQueryable<Project> query = _context.Projects.Include(p => p.Company);
            query = query.OrderBy(p => p.Id).Where(p => p.Id == Id);
                

            if (includeUser)
            {
                query = query
                    .Include(p => p.UserProjects)
                    .ThenInclude(p => p.User);
            }

            return await query.FirstOrDefaultAsync();
        }

    }
}
