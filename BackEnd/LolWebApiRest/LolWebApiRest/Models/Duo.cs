namespace LolWebAPI.Models
{
    public class Duo
    {

        public int Id { get; set; }
        public string Puuid { get; set; }
        public string GameName { get; set; }
        public string TagLine { get; set; } 
        public int IdLane { get; set; }
        public int IdLaneDuo { get; set; }
        public int IdElo { get; set; }
        public int IdModoDeJogo { get; set; }
        public bool IsVoiceUser { get; set; }
        public string Note { get; set; }
    }
}
