using YahooFantasyFootball.ViewModels;

namespace YahooFantasyFootball.Services
{
    public interface IYahooApiService
    {
        StandingsVM GetLeagueStandings();
    }
}
