using LolWebAPI.Models;
using LolWebApiRest.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LolWebAPI.Controllers
{
    public class LolController : Controller
    {
        private readonly ILolService _lolService;

        public LolController(ILolService lolService)
        {
            _lolService = lolService;
        }

        [HttpGet("GetAccount/{username}/{tag}")]
        public async Task<IActionResult> GetAccount(string username, string tag)
        {
            try
            {
                var account = await _lolService.GetAccountAsync(username, tag);
                if (account == null) return NotFound("Nenhuma conta encontrado");

                return Ok(account);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar conta. Erro : {ex.Message}");
            }
        }

        [HttpGet("GetMastery/{piuuid}")]
        public async Task<IActionResult> GetMastery(string piuuid)
        {
            try
            {
                List<Mastery> mastery = await _lolService.GetMasteryAsync(piuuid);
                if (mastery == null) return NotFound("Nenhuma maestria encontrado");

                return Ok(mastery);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar maestrias. Erro : {ex.Message}");
            }
        }

        [HttpGet("GetAccountInformations/{piuuid}")]
        public async Task<IActionResult> GetAccountInformations(string piuuid)
        {
            try
            {
                AccountInformations accountInformations = await _lolService.GetAccountInformations(piuuid);
                if (accountInformations == null) return NotFound("Nenhuma informação encontrada!");

                return Ok(accountInformations);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar informações sobre a conta. Erro : {ex.Message}");
            }
        }

        [HttpGet("GetAccountRankByPiuuid/{piuuid}")]
        public async Task<IActionResult> GetAccountRankByPiuuid(string piuuid)
        {
            try
            {
                List<Rank> rank = await _lolService.GetAccountRankByPiuuid(piuuid);
                if (rank == null) return NotFound("Nenhuma informação encontrada!");

                return Ok(rank);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar informações sobre o elo. Erro : {ex.Message}");
            }
        }
    }
}
