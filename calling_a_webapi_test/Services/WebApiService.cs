using System;
using System.Text;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using UrbanRankingTelegBot.DataModels;
using UrbanRankingTelegBot.DataModels.Database;
using UrbanRankingTelegBot.AddLogic;

namespace UrbanRankingTelegBot.Services
{
    public class WebApiService : IWebApiService
    {
        public static HttpClient httpClient = new();
        
        public async Task<string> GetCityReview (string CityName, int ChatId)
        {
            string LowerCaseCityName = CityName.ToLower();
            string JsonValidatedString = AddLogicMethods.JsonSerializationValidation(LowerCaseCityName);

            if (JsonValidatedString == "kyiv")
            {
                JsonValidatedString = "kiev";
            }

            DbModel CityData = new()
            {
                cityname = CityName,
                chatid = ChatId
            };

            //posting request data to database
            if (CityData.cityname != "kiev" && ChatId != 01)
            {
                var stringContent = new StringContent
                    (JsonConvert.SerializeObject(CityData), Encoding.UTF8, "application/json");

                await httpClient.PostAsync(Constants.WebApiAdress + "users", stringContent);
            }

            //requesting data from webapi
            var responseCategories = await httpClient.
                GetAsync(httpClient.BaseAddress + $"cities/teleport/{JsonValidatedString}");

            var contentCategories = responseCategories.Content.ReadAsStringAsync().Result;
            var CityCategoriesList = JsonConvert.DeserializeObject<List<Review>>(contentCategories);

            var responseSummary = await httpClient.
                GetAsync(httpClient.BaseAddress + $"cities/teleport/{JsonValidatedString}/summary");

            var contentSummary = responseSummary.Content.ReadAsStringAsync().Result;
            var SummaryResult = JsonConvert.DeserializeObject<Summary>(contentSummary);

            var responseBasicInfo = await httpClient.
                GetAsync(httpClient.BaseAddress + $"cities/geodb/{JsonValidatedString}");

            var contentBasicInfo = responseBasicInfo.Content.ReadAsStringAsync().Result;
            var BasicInfo = JsonConvert.DeserializeObject<BasicCityInfo>(contentBasicInfo);

            //processing the data from web api
            if (SummaryResult != null && BasicInfo != null)
            {
                string CityGeneralInfo = $"🌆 City: {BasicInfo.cityName} {BasicInfo.countryCode},\n" +
                                                  $"👥 Population: {BasicInfo.cityPopulation},\n" +
                                                  $"🗺 Located in: {BasicInfo.countryName}, {BasicInfo.continent}.\n\n";

                string[] categories = new string[CityCategoriesList.Count];
                int count = 0;

                foreach (var City in CityCategoriesList)
                {
                    categories[count] = $"{City.name} - {City.score}/10\n\n";
                    count++;
                }
                string CityRatings = String.Join("", categories);

                string CitySummary = "📍" + SummaryResult.summary + "\n";

                if (CityName.ToLower() == "kyiv")
                {
                    CityName = "kiev";
                }
                string MoreInfo = $"\nIn case if you want more information: https://teleport.org/cities/{CityName}/.";

                string ConcatenatedResult = CityGeneralInfo + CityRatings + CitySummary + MoreInfo;
                string FinalOutput = AddLogicMethods.NumberFormatting(ConcatenatedResult);

               
                return FinalOutput;
            }
            else
            {
                string notfound = "No city with such a name found in our database.";
                return notfound;
            }
        }
        public async Task<string> GetSavedCitiesList(int ChatId)
        {
            var jsonResponse = await httpClient.
                GetAsync(Constants.WebApiAdress + $"users/{ChatId}");

            var CitiesInDatabase = jsonResponse.Content.ReadAsStringAsync().Result;
            var DeserializedData = JsonConvert.DeserializeObject<List<DbModel>>(CitiesInDatabase); //

            string[] citiesData = new string[DeserializedData.Count];
            int count = 0;

            foreach (var Data in DeserializedData)
            {
                string CityName = AddLogicMethods.
                    CapitalizingFirstLetter(Data.cityname.ToCharArray());

                citiesData[count] = CityName;
                count++;
            }

            string CityRatings = String.Join(",\n", citiesData);

            string Output;

            if (CityRatings == "")
            {
                Output = "Your list of saved cities is empty.";
            }
            else
            {
                Output = "Your list of saved cities:\n\n" + CityRatings + ".";
            }

            return Output;
        }

        public async Task<string> GetBestByCategory(string category)
        {
            var jsonResponse = await httpClient.
                GetAsync(Constants.WebApiAdress + $"cities/getbest/{category}");

            var BestCities = jsonResponse.Content.ReadAsStringAsync().Result;
            var DeserializedData = JsonConvert.DeserializeObject<List<DbGetBestByCategory>>(BestCities);

            string[] citiesData = new string[DeserializedData.Count];
            int count = 0;

            foreach (var Data in DeserializedData)
            {
                citiesData[count] = Data.cities;
                count++;
            }

            string Cities = String.Join(",\n", citiesData);

            string Output = $"The best cities for the " +
                $"'{AddLogicMethods.CapitalizingFirstLetter(category.ToCharArray())}' category are\n\n" + Cities;

            return Output;
        }

        public async Task<string> GetAvailableCities (string letter)
        {
            bool IsAValidLetter = AddLogicMethods.CheckingIfAValidLetter(letter.ToLower());

            if (IsAValidLetter)
            {
                var jsonResponse = await httpClient.
                GetAsync(Constants.WebApiAdress + $"cities/getavailable/{letter.ToLower()}");

                var AvailableCities = jsonResponse.Content.ReadAsStringAsync().Result;
                var DeserializedData = JsonConvert.DeserializeObject<List<DbAvailableCities>>(AvailableCities);

                string[] citiesData = new string[DeserializedData.Count];
                int count = 0;

                foreach (var Data in DeserializedData)
                {
                    citiesData[count] = Data.cityname;
                    count++;
                }

                string Cities = String.Join(",\n", citiesData);

                return Cities;
            }

            else
            {
                string Output = "Wrong letter input.";
                return Output;
            }
        }
      
        
        public async Task<IEnumerable<int>> GetSubscribeData ()
        {
            var responseCategories = await httpClient.
                   GetAsync(httpClient.BaseAddress + $"users/actions/subscribe");

            var contentCategories = responseCategories.Content.ReadAsStringAsync().Result;
            var SubscribedUsers = JsonConvert.DeserializeObject<List<DbSubscription>>(contentCategories);

            int[] chatIds = new int[SubscribedUsers.Count];
            int count = 0;
            
            foreach (var Data in SubscribedUsers)
            {
                chatIds[count] = Data.chatid;
                count++;
            }

            return chatIds;
        }
        
        public async Task PostSubDetails (int ChatId)
        {
            DbSubscription Subscription = new()
            {
                purpose = "subscribe",
                chatid = ChatId
            };

            //posting request data to database
            var stringContent = new StringContent
                (JsonConvert.SerializeObject(Subscription), Encoding.UTF8, "application/json");

            await httpClient.PostAsync(Constants.WebApiAdress + "users/actions", stringContent);
        }
        public async Task DeleteSubscription (int ChatId)
        {
            await httpClient.DeleteAsync
                (Constants.WebApiAdress + $"users/subscription/{ChatId}/delete");
        }
        public async Task Delete (int ChatId, string CityName)
        {
            bool IsACity = AddLogicMethods.CheckingIfACity(CityName.ToLower());

            if (IsACity)
            {
                await httpClient.DeleteAsync
                    (Constants.WebApiAdress + $"users/{ChatId}/{CityName.ToLower()}");
            }
        }

        public async Task DeleteAll (int ChatId)
        {
            await httpClient.DeleteAsync
                (Constants.WebApiAdress + $"users/{ChatId}/deleteall");
        }
    }
}
