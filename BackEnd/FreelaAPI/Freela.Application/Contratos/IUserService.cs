using Freela.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Freela.Application.Contratos
{
    public interface IUserService
    {
        Task<User> AddUser(User model);
        Task<User> UpdateUser(int projectId, User model);
        Task <bool> DeleteUser(int projectId);
        Task<User[]> GetAllUser();
        Task<User[]> GetAllUserByAreaAsync(string Area);
        Task<User> GetUserByIdAsync(int Id);

    }
}
