namespace LolWebAPI.Models
{
    public class Account
    {
        public string puuid { get; set; }
        public string gameName { get; set; }
        public string tagLine { get; set; } 
    }

    public class AccountInformations
    {
        public string id { get; set; }
        public string accountId { get; set; }
        public string puuid { get; set; }
        public string name { get; set; }
        public string profileIconId { get; set; }
        public string revisionDate { get; set; }
        public string summonerLevel { get; set; }
        public string profileIconUrl { get; set; }
    }
}
