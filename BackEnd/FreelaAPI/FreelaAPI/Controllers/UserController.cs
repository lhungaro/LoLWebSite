using Freela.Application.Contratos;
using Freela.Domain.Models;
using FreelaAPI.Data;
using Microsoft.AspNetCore.Mvc;

namespace Freela_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var projects = await _userService.GetAllUser();
                if (projects == null) return NotFound("Nenhum projeto encontrado");

                return Ok(projects);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar projetos. Erro : {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)

        {
            try
            {
                var projects = await _userService.GetUserByIdAsync(id);
                if (projects == null) return NotFound("Nenhum projeto encontrado");

                return Ok(projects);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar usuário. Erro : {ex.Message}");
            }
        }


        [HttpGet("{area}/area")]
        public async Task<IActionResult> GetByArea(string area)

        {
            try
            {
                var projects = await _userService.GetAllUserByAreaAsync(area);
                if (projects == null) return NotFound("Nenhum projeto encontrado");

                return Ok(projects);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar projetos. Erro : {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, User model)
        {
            try
            {
                var projects = await _userService.UpdateUser(id,model);
                if (projects == null) return BadRequest("Erro ao adicionar o Projeto");

                return Ok(projects);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar projetos. Erro : {ex.Message}");
            }
        }
        [HttpPost]
        public async Task<IActionResult> Post(User model)
        {
            try
            {
                var projects = await _userService.AddUser(model);
                if (projects == null) return BadRequest("Erro ao adicionar o Projeto");

                return Ok(projects);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar usuario. Erro : {ex.InnerException}");
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                return await _userService.DeleteUser(id) 
                    ? Ok() 
                    : BadRequest();
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar deleta o projeto. Erro : {ex.Message}");
            }
        }
    }
}
