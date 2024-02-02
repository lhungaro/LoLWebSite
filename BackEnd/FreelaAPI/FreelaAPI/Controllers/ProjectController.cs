using Freela.Application.Contratos;
using Freela.Domain.Models;
using FreelaAPI.Data;
using Microsoft.AspNetCore.Mvc;

namespace Freela_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var projects = await _projectService.GetAllProjects(true);
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
                var projects = await _projectService.GetProjectByIdAsync(id,true);
                if (projects == null) return NotFound("Nenhum projeto encontrado");

                return Ok(projects);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar projetos. Erro : {ex.Message}");
            }
        }


        [HttpGet("{area}/area")]
        public async Task<IActionResult> GetByArea(string area)

        {
            try
            {
                var projects = await _projectService.GetAllProjectsByAreaAsync(area, true);
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
        public async Task<IActionResult> Put(int id, Project model)
        {
            try
            {
                var projects = await _projectService.UpdateProject(id,model);
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
        public async Task<IActionResult> Post(Project model)
        {
            try
            {
                var projects = await _projectService.AddProject(model);
                if (projects == null) return BadRequest("Erro ao adicionar o Projeto");

                return Ok(projects);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar projetos. Erro : {ex.Message}");
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                return await _projectService.DeleteProject(id) 
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
