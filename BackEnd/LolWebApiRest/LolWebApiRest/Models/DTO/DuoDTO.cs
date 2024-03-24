namespace LolWebAPI.Models
{
    public class DuoDTO
    {

        public int Id { get; set; }
        public string Puuid { get; set; }
        public string GameName { get; set; }
        public string TagLine { get; set; } 
        public string Lane { get; set; }
        public string LaneDuo { get; set; }
        public string Elo { get; set; }
        public string ModoDeJogo { get; set; }
        public bool IsVoiceUser { get; set; }
        public string Note { get; set; }
        public string IdIcone { get; set; }
        public AccountInformations AccountInformations { get; set; }
    }
}
