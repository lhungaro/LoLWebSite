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
    public class UserService : IUserService
    {
        private readonly IFreelaRepository _freelaRepository;
        private readonly IUserRepository _userRepository;

        public UserService(IFreelaRepository freelaRepository, IUserRepository userRepository)
        {
            _freelaRepository = freelaRepository;
            _userRepository = userRepository;
        }
        public async Task<User> AddUser(User model)
        {
            try
            {
                _freelaRepository.Add<User>(model);
                if (await _freelaRepository.SaveChangesAsync())
                    return await _userRepository.GetFreelaByIdAsync(model.Id);

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<User> UpdateUser(int projectId, User model)
        {
            try
            {
                var project = await _userRepository.GetFreelaByIdAsync(projectId);
                if(project == null) return null;

                model.Id = project.Id;

                _freelaRepository.Update(model);

                if (await _freelaRepository.SaveChangesAsync())
                    return await _userRepository.GetFreelaByIdAsync(model.Id);

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<bool> DeleteUser(int projectId)
        {
            try
            {
                var project = await _userRepository.GetFreelaByIdAsync(projectId);
                if (project == null) throw new Exception("Projeto não encontrado!");

                _freelaRepository.Delete<User>(project);

                return await _freelaRepository.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<User[]> GetAllUser()
        {
            try
            {
                var projects = await _userRepository.GetAllFreelas();
                if (projects == null) return null;

                return projects;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<User[]> GetAllUserByAreaAsync(string Area)
        {
            try
            {
                var projects = await _userRepository.GetAllFreelaByAreaAsync(Area);
                if (projects == null) return null;

                return projects;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<User> GetUserByIdAsync(int Id)
        {
            try
            {
                var projects = await _userRepository.GetFreelaByIdAsync(Id);
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
