namespace LolWebAPI.Models
{
    public class Mastery
    {
        public string puuid { get; set; }
        public string championId { get; set; }
        public string championLevel { get; set; }
        public string championPoints { get; set; }
        public string lastPlayTime { get; set; }
        public string championPointsSinceLastLevel { get; set; }
        public string championPointsUntilNextLevel { get; set; }
        public string chestGranted { get; set; }
        public string tokensEarned { get; set; }
        public string summonerId { get; set; }
        public string? ChampName { get; set; }
        public string? ChampUrlImg { get; set; }

    }
}
