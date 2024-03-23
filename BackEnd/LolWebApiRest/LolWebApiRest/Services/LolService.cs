using LolWebAPI.Models;
using LolWebApiRest.Constants;
using LolWebApiRest.Interfaces;
using LolWebApiRest.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileSystemGlobbing;
using Newtonsoft.Json;
using System;
using System.Text.RegularExpressions;
using static System.Net.WebRequestMethods;

namespace LolWebAPI.Services
{

    public class LolService : ILolService
    {
        private readonly HttpClient httpClient;
        private readonly string _apiKey;
        private readonly string _baseUrl;
        private readonly string _baseUrlBr;
        private readonly string _urlChampionsList;
        private readonly string _urlChampionsImage;
        private readonly string _urlIconsImage;
        private readonly string _urlSpeelImage;
        private readonly string _urlItemImage;
        private readonly IAnuncioRepository _anuncioRepository;
        private readonly IDuoRepository _duoRepository;

        public LolService(IConfiguration configuration, IAnuncioRepository anuncioRepository,IDuoRepository duoRepository)
        {
            _apiKey = configuration.GetValue<string>("AppSettings:ApiKey");
            _baseUrl = configuration.GetValue<string>("AppSettings:BaseUrl");
            _baseUrlBr = configuration.GetValue<string>("AppSettings:BaseUrlBr");
            _urlChampionsList = configuration.GetValue<string>("AppSettings:urlChampionsList");
            _urlChampionsImage = configuration.GetValue<string>("AppSettings:urlChampionImage");
            _urlIconsImage = configuration.GetValue<string>("AppSettings:urlIconsImage");
            _urlSpeelImage = configuration.GetValue<string>("AppSettings:urlSpeelImage");
            _urlItemImage = configuration.GetValue<string>("AppSettings:urlItemImage");
            _anuncioRepository = anuncioRepository;
            _duoRepository = duoRepository;

            httpClient = new HttpClient();
        }

        public async Task<Account> GetAccountAsync(string username,string tag)
        {
            if (!string.IsNullOrEmpty(username))
            {
                try
                {
                    string url = $"{_baseUrl}/riot/account/v1/accounts/by-riot-id/{username}/{tag}?api_key={_apiKey}";

                    HttpResponseMessage response = await httpClient.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();

                        Account user = JsonConvert.DeserializeObject<Account>(responseBody);

                        return user;
                    }
                    else
                    {
                        Console.WriteLine($"Failed to get user. Status code: {response.StatusCode}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }

            // Return null if there is an issue or if username is empty
            return null;
        }

        public async Task<AccountInformations> GetAccountInformations(string piuuid)
        {
            if (!string.IsNullOrEmpty(piuuid))
            {
                try
                {
                    string url = $"{_baseUrlBr}/lol/summoner/v4/summoners/by-puuid/{piuuid}?api_key={_apiKey}";

                    HttpResponseMessage response = await httpClient.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();

                        AccountInformations accountInformations = JsonConvert.DeserializeObject<AccountInformations>(responseBody);
                        PreencheIconUrl(accountInformations);

                        return accountInformations;
                    }
                    else
                    {
                        Console.WriteLine($"Failed to get user. Status code: {response.StatusCode}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }

            // Return null if there is an issue or if username is empty
            return null;
        }
        public async Task<List<Rank>> GetAccountRankByPiuuid(string piuuid)
        {
            if (!string.IsNullOrEmpty(piuuid))
            {
                try
                {
                    string urlAcc = $"{_baseUrlBr}/lol/summoner/v4/summoners/by-puuid/{piuuid}?api_key={_apiKey}";

                    HttpResponseMessage responseAcc = await httpClient.GetAsync(urlAcc);

                    if (responseAcc.IsSuccessStatusCode)
                    {
                        string responseBodyAcc = await responseAcc.Content.ReadAsStringAsync();

                        AccountInformations accountInformations = JsonConvert.DeserializeObject<AccountInformations>(responseBodyAcc);

                        string url = $"{_baseUrlBr}/lol/league/v4/entries/by-summoner/{accountInformations.id}?api_key={_apiKey}";
                        HttpResponseMessage response = await httpClient.GetAsync(url);

                        if (response.IsSuccessStatusCode)
                        {
                            string responseBody = await response.Content.ReadAsStringAsync();

                            List<Rank> rank = JsonConvert.DeserializeObject<List<Rank>>(responseBody);

                            return rank;
                        }
                        else
                        {
                            Console.WriteLine($"Failed to get user. Status code: {response.StatusCode}");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Failed to get user. Status code: {responseAcc.StatusCode}");
                    }
                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }

            // Return null if there is an issue or if username is empty
            return null;
        }

        public async Task<List<Mastery>> GetMasteryAsync(string piuuid)
        {
            if (!string.IsNullOrEmpty(piuuid))
            {
                try
                {
                    string url = $"{_baseUrlBr}/lol/champion-mastery/v4/champion-masteries/by-puuid/{piuuid}?api_key={_apiKey}";

                    HttpResponseMessage response = await httpClient.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        // Convert the response content to a string
                        string responseBody = await response.Content.ReadAsStringAsync();
               
                        // Deserialize the JSON into a User object
                        List<Mastery> masterys = JsonConvert.DeserializeObject<List<Mastery>>(responseBody);
                        
                        HttpResponseMessage responseChampionList = await httpClient.GetAsync(_urlChampionsList);

                        if (responseChampionList.IsSuccessStatusCode)
                        {
                            string ChampionListresponseBody = await responseChampionList.Content.ReadAsStringAsync();
                            ChampionList championList = JsonConvert.DeserializeObject<ChampionList>(ChampionListresponseBody);
                            List<Champion> champions = championList.data.Values.ToList();

                            foreach (var mastery in masterys)
                            {
                                var champ = champions.FirstOrDefault(c => c.key == mastery.championId);
                                if (champ != null)
                                {
                                    mastery.ChampName = champ.name;
                                    mastery.ChampUrlImg = _urlChampionsImage + champ.image.full;
                                    mastery.Tags = champ.tags;
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine($"Failed to get champion list. Status code: {responseChampionList.StatusCode}");
                        }

                        // Return the User object
                        return masterys;
                    }
                    else
                    {
                        Console.WriteLine($"Failed to get mastery. Status code: {response.StatusCode}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }

            return null;
        }

        private void PreencheIconUrl(AccountInformations accountInformations)
        {
            accountInformations.profileIconUrl = _urlIconsImage + accountInformations.profileIconId + ".png"; 
        }

        public async Task<List<Matche>> GetMatchesInformationsAsync(string puuid)
        {
            if (!string.IsNullOrEmpty(puuid))
            {
                try
                {
                    //Consultando o ID das partidas 
                    string url = $"{_baseUrl}/lol/match/v5/matches/by-puuid/{puuid}/ids?api_key={_apiKey}";


                    HttpResponseMessage response = await httpClient.GetAsync(url);
                    List<string> matchesIds = new List<string>();

                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();

                        matchesIds = JsonConvert.DeserializeObject<List<string>>(responseBody);
                    }
                    else
                    {
                        Console.WriteLine($"Failed to get user. Status code: {response.StatusCode}");
                    }

                    //Buscando informações de cada partida separadamente

                    var matchs = await GetMatchesInformationsByMatchId(matchesIds);

                    var matchsOrdenadas = new List<Matche>();

                    matchs.ForEach(match => {
                        var participant = match.info.participants.FirstOrDefault(p => p.puuid == puuid);
                        if (participant != null)
                        {
                            match.info.participants.Remove(participant);
                            match.info.participants.Insert(0, participant);
                            participant.summoner1Image = SerializaSummonerSpell(participant.summoner1Id);
                            participant.summoner2Image = SerializaSummonerSpell(participant.summoner2Id);
                            participant.championImage = _urlChampionsImage + participant.championName + ".png";
                            SerializaItens(participant);
                        }

                    });

                    return matchs;

                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }

            // Return null if there is an issue or if username is empty
            return null;
        }

        private void SerializaItens(Participant participant)
        {
            participant.item0Image = participant.item0.ToString() != "" ? _urlItemImage + participant.item0.ToString() + ".png" : "";
            participant.item1Image = participant.item0.ToString() != "" ?_urlItemImage + participant.item1.ToString() + ".png" : "";
            participant.item2Image = participant.item0.ToString() != "" ?_urlItemImage + participant.item2.ToString()  + ".png": "";
            participant.item3Image = participant.item0.ToString() != "" ?_urlItemImage + participant.item3.ToString() + ".png": "";
            participant.item4Image = participant.item0.ToString() != "" ?_urlItemImage + participant.item4.ToString() + ".png": "";
            participant.item5Image = participant.item0.ToString() != "" ?_urlItemImage + participant.item5.ToString() + ".png": "";
            participant.item6Image = participant.item0.ToString() != "" ?_urlItemImage + participant.item6.ToString() + ".png": "";
        }

        private async Task<List<Matche>> GetMatchesInformationsByMatchId(List<string> matchesIds)
        {
            const int maxParallelism = 5; // Define o número máximo de chamadas simultâneas

            var semaphore = new SemaphoreSlim(maxParallelism, maxParallelism);
            var matchTasks = new List<Task<Matche>>();

            foreach (var matchId in matchesIds)
            {
                await semaphore.WaitAsync(); 
                matchTasks.Add(Task.Run(async () =>
                {
                    try
                    {
                        string urlMatch = $"{_baseUrl}/lol/match/v5/matches/{matchId}?api_key={_apiKey}";
                        HttpResponseMessage responseMatch = await httpClient.GetAsync(urlMatch);

                        if (responseMatch.IsSuccessStatusCode)
                        {
                            string responseBodyMatch = await responseMatch.Content.ReadAsStringAsync();
                            return JsonConvert.DeserializeObject<Matche>(responseBodyMatch);
                        }
                        else
                        {
                            Console.WriteLine($"Failed to get match. Status code: {responseMatch.StatusCode}");
                            return null;
                        }
                    }
                    finally
                    {
                        semaphore.Release();
                    }
                }));
            }

            var matches = await Task.WhenAll(matchTasks);
            return matches.ToList();
        }

        private async Task<Matche> GetMatchInformationAsync(string matchId)
        {
            string urlMatch = $"{_baseUrl}/lol/match/v5/matches/{matchId}?api_key={_apiKey}";
            HttpResponseMessage responseMatch = await httpClient.GetAsync(urlMatch);

            if (responseMatch.IsSuccessStatusCode)
            {
                string responseBodyMatch = await responseMatch.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Matche>(responseBodyMatch);
            }
            else
            {
                Console.WriteLine($"Failed to get match. Status code: {responseMatch.StatusCode}");
                return null;
            }
        }

        public async Task<List<Champion>> GetChampionsAsync()
        {
            try
            {
                string url = _urlChampionsList;

                HttpResponseMessage response = await httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();

                    ChampionList championList = JsonConvert.DeserializeObject<ChampionList>(responseBody);
                    List<Champion> champions = championList.data.Values.ToList();

                    foreach (var champ in champions)
                    {
                            champ.imageUrl = _urlChampionsImage + champ.image.full;
                    }
                    return champions;
                }
                else
                {
                    Console.WriteLine($"Failed to get user. Status code: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            // Return null if there is an issue or if username is empty
            return null;
        }

        private string SerializaSummonerSpell(int summoner1Id)
        {
            switch (summoner1Id)
            {
                case (int)SummonersSpellEnum.SummonerBarrier:
                    return _urlSpeelImage + "SummonerBarrier" + ".png";

                case (int)SummonersSpellEnum.SummonerDot:
                    return _urlSpeelImage + "SummonerDot" + ".png";

                case (int)SummonersSpellEnum.SummonerCherryFlash:
                    return _urlSpeelImage + "SummonerCherryFlash" + ".png";

                case (int)SummonersSpellEnum.SummonerCherryHold:
                    return _urlSpeelImage + "SummonerCherryHold" + ".png";

                case (int)SummonersSpellEnum.SummonerBoost:
                    return _urlSpeelImage + "SummonerBoost" + ".png";

                case (int)SummonersSpellEnum.SummonerExhaust:
                    return _urlSpeelImage + "SummonerExhaust" + ".png";

                case (int)SummonersSpellEnum.SummonerFlash:
                    return _urlSpeelImage + "SummonerFlash" + ".png";

                case (int)SummonersSpellEnum.SummonerHaste:
                    return _urlSpeelImage + "SummonerHaste" + ".png";

                case (int)SummonersSpellEnum.SummonerHeal:
                    return _urlSpeelImage + "SummonerHeal" + ".png";

                case (int)SummonersSpellEnum.SummonerMana:
                    return _urlSpeelImage + "SummonerMana" + ".png";

                case (int)SummonersSpellEnum.SummonerPoroRecall:
                    return _urlSpeelImage + "SummonerPoroRecall" + ".png";

                case (int)SummonersSpellEnum.SummonerPoroThrow:
                    return _urlSpeelImage + "SummonerPoroThrow" + ".png";

                case (int)SummonersSpellEnum.SummonerSmite:
                    return _urlSpeelImage + "SummonerSmite" + ".png";

                case (int)SummonersSpellEnum.SummonerSnowURFSnowball_Mark:
                    return _urlSpeelImage + "SummonerSnowURFSnowball_Mark" + ".png";

                case (int)SummonersSpellEnum.SummonerSnowball:
                    return _urlSpeelImage + "SummonerSnowball" + ".png";

                case (int)SummonersSpellEnum.SummonerTeleport:
                    return _urlSpeelImage + "SummonerTeleport" + ".png";

                default:
                    return "";
            }
        }

        public async Task<Duo> AddDuo(Duo model)
        {
            try
            {
                _duoRepository.Add<Duo>(model);
                if (await _duoRepository.SaveChangesAsync())
                    return await _anuncioRepository.GetDuoByIdAsync(model.Id);

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Duo> UpdateDuo(int DuoId, Duo model)
        {
            try
            {
                var duo = await _anuncioRepository.GetDuoByIdAsync(DuoId);
                if (duo == null) return null;

                model.Id = duo.Id;

                _duoRepository.Update(model);

                if (await _duoRepository.SaveChangesAsync())
                    return await _anuncioRepository.GetDuoByIdAsync(model.Id);

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteDuo(int DuoId)
        {
            try
            {
                var duo = await _anuncioRepository.GetDuoByIdAsync(DuoId);
                if (duo == null) throw new Exception("Projeto não encontrado!");

                _duoRepository.Delete<Duo>(duo);

                return await _duoRepository.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Duo[]> GetAllDuos()
        {
            try
            {
                var duos = await _anuncioRepository.GetAllDuos();
                if (duos == null) return null;

                return duos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Duo> GetDuoByIdAsync(int Id)
        {
            try
            {
                var duo = await _anuncioRepository.GetDuoByIdAsync(Id);
                if (duo == null) return null;

                return duo;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }

}