using LolWebAPI.Models;
using LolWebApiRest.Data;
using System.Text.RegularExpressions;

namespace LolWebApiRest.Repository
{
    public interface IAnuncioRepository
    {
        Task<Duo> GetDuoByIdAsync(int Id);
        Task<Duo[]> GetAllDuos();
    }
}
