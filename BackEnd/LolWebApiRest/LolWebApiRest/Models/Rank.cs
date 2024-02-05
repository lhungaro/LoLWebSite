namespace LolWebAPI.Models
{
    public class Rank
    {
        public string leagueId { get; set; }
        public string queueType { get; set; }
        public string tier { get; set; }
        public string rank { get; set; }
        public string summonerId { get; set; }
        public string summonerName { get; set; }
        public string leaguePoints { get; set; }
        public string wins { get; set; }
        public string losses { get; set; }
        public string veteran { get; set; }
        public string inactive { get; set; }
        public string freshBlood { get; set; }
        public string hotStreak { get; set; }
    }
}
