using LolWebAPI.Models;
using LolWebApiRest.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace LolWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DuoController : Controller
    {
        private readonly ILolService _lolService;

        public DuoController(ILolService lolService)
        {
            _lolService = lolService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var duos = await _lolService.GetAllDuos();
                if (duos == null) return NoContent();


                return Ok(duos);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar duos. Erro: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var duo = await _lolService.GetDuoByIdAsync(id);
                if (duo == null) return NoContent();
                return Ok(duo);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar duo. Erro: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Duo model)
        {
            try
            {
                var duo = await _lolService.AddDuo(model);
                if (duo == null) return NoContent();
                return Ok(duo);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar adicionar duo. Erro: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Duo model)
        {
            try
            {
                var duo = await _lolService.UpdateDuo(id, model);
                if (duo == null) return NoContent();
                return Ok(duo);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar atualizar eventos. Erro: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var duo = await _lolService.GetDuoByIdAsync(id);
                if (duo == null) return NoContent();

                if (await _lolService.DeleteDuo(id))
                {
                    return Ok(new { message = "Deletado" });
                }
                else
                {
                    throw new Exception("Ocorreu um problema não específico ao tentar deletar.");
                }
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar deletar. Erro: {ex.Message}");
            }
        }

    }
}
