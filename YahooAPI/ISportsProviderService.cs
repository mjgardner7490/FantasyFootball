using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YahooSports.Api.Sports.Models;

namespace YahooAPI
{
    public interface ISportsProviderService
    {
        FantasyContent GetLeagueInfo();
    }
}
