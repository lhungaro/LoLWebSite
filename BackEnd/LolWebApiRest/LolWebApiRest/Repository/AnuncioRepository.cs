using LolWebAPI.Models;
using LolWebApiRest.Data;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace LolWebApiRest.Repository
{
    public class AnuncioRepository : IAnuncioRepository
    {
        private readonly DuoDbContext _context;

        public AnuncioRepository(DuoDbContext context)
        {
            _context = context;
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
        public async Task<DuoDTO[]> GetAllDuos()
        {
            IQueryable<Duo> query = _context.Duos;
            query = query.OrderBy(p => p.Id);

            var duos = await query.ToArrayAsync();

            var duosDTO = duos.Select(duo => new DuoDTO
            {
                Id = duo.Id,
                Puuid = duo.Puuid,
                GameName = duo.GameName,
                TagLine = duo.TagLine,
                Lane = duo.Lane,
                LaneDuo = duo.LaneDuo,
                Elo = duo.Elo,
                ModoDeJogo = duo.ModoDeJogo,
                IsVoiceUser = duo.IsVoiceUser,
                Note = duo.Note
            }).ToArray();

            return duosDTO;
        }
        public async Task<DuoDTO> GetDuoDTOByIdAsync(int Id)
        {
            IQueryable<Duo> query = _context.Duos;
            query = query.OrderBy(p => p.Id).Where(p => p.Id == Id);

            var duo = await query.FirstOrDefaultAsync();
            var duoDTO = new DuoDTO
            {
                Id = duo.Id,
                Puuid = duo.Puuid,
                GameName = duo.GameName,
                TagLine = duo.TagLine,
                Lane = duo.Lane,
                LaneDuo = duo.LaneDuo,
                Elo = duo.Elo,
                ModoDeJogo = duo.ModoDeJogo,
                IsVoiceUser = duo.IsVoiceUser,
                Note = duo.Note
            };
            return duoDTO;
        }

        public async Task<Duo> GetDuoByIdAsync(int Id)
        {
            IQueryable<Duo> query = _context.Duos;
            query = query.OrderBy(p => p.Id).Where(p => p.Id == Id);

            return await query.FirstOrDefaultAsync();
        }

    }
}
