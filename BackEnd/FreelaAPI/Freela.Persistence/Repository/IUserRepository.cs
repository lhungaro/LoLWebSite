using Freela.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Freela.Persistence.Repository
{
    public interface IUserRepository
    {
        Task<User> GetFreelaByIdAsync(int Id);
        Task<User[]> GetAllFreelas();
        Task<User[]> GetAllFreelaByAreaAsync(string Area);
    }
}
