namespace FlightFinder.UI.Services
{
    public interface IApiService
    {
        Task<string> GetCount(string inputString);
    }
}
