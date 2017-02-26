using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YahooFantasyFootball.Services
{
    public interface ITempConvertApiService
    {
        string ConvertTemperature(string temp, string fromUnits, string toUnits);
    }
}
