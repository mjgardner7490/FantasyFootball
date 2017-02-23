using YahooFantasyFootball.ViewModels;

namespace YahooFantasyFootball.Services
{
    public interface IYahooApiService
    {
        StandingsVM GetLeagueStandings();
        WeatherToolVM GetTeamRoster(string teamId, int gameWeekId);
    }
}
