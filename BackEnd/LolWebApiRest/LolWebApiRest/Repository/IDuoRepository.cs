using LolWebAPI.Models;
using LolWebApiRest.Data;
using System.Text.RegularExpressions;

namespace LolWebApiRest.Repository
{
    public interface IDuoRepository
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        void DeleteRange<T>(T[] entity) where T : class;
        Task<bool> SaveChangesAsync();
    }
}
