using LolWebAPI.Models;
using LolWebApiRest.Interfaces;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
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

        public LolService(IConfiguration configuration)
        {
            _apiKey = configuration.GetValue<string>("AppSettings:ApiKey");
            _baseUrl = configuration.GetValue<string>("AppSettings:BaseUrl");
            _baseUrlBr = configuration.GetValue<string>("AppSettings:BaseUrlBr");
            _urlChampionsList = configuration.GetValue<string>("AppSettings:urlChampionsList");
            _urlChampionsImage = configuration.GetValue<string>("AppSettings:urlChampionImage");
            _urlIconsImage = configuration.GetValue<string>("AppSettings:urlIconsImage");
            
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

            // Return null if there is an issue or if username is empty
            return null;
        }

        private void PreencheIconUrl(AccountInformations accountInformations)
        {
            accountInformations.profileIconUrl = _urlIconsImage + accountInformations.profileIconId + ".png"; 
        }

    }

}