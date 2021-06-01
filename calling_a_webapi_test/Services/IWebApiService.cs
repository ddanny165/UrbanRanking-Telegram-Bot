using System.Threading.Tasks;

namespace UrbanRankingTelegBot.Services
{
    public interface IWebApiService
    {
        Task<string> GetCityReview(string CityName, int ChatId);
        Task<string> GetSavedCitiesList(int ChatId);
        Task<string> GetBestByCategory(string category);
        Task<string> GetAvailableCities(string letter);

        Task DeleteSubscription(int ChatId);
        Task Delete(int ChatId, string CityName);
        Task DeleteAll(int ChatId);
    }
}
