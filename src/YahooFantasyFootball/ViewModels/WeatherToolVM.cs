using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YahooFantasyFootball.ViewModels
{
    public class WeatherToolVM
    {
        public int GameWeekId { get; set; }
        public IEnumerable<SelectListItem> GameWeeks { get; set; }
        public string TeamId { get; set; }
        public int TemperatureUnitId { get; set; }
        public IEnumerable<SelectListItem> TemperatureUnits { get; set; }
        public IEnumerable<SelectListItem> Managers { get; set; }
        public IEnumerable<NflPlayer> TeamRoster { get; set; }

        public WeatherToolVM()
        {
            GameWeeks = GameWeeksDictionary.GameWeekSelectList;
            Managers = ManagersDictionary.ManagersSelectList;
            TemperatureUnits = TemperatureUnitsDictionary.TemperatureUnitSelectList;
        }
    }

    public class NflPlayer
    {
        public string NflTeam { get; set; }
        public string PlayerName { get; set; }
        public string PlayerPosition { get; set; }
        public string PlayerImageUrl { get; set; }
        public GameWeather gameWeather { get; set; }
    }

    public class GameWeather
    {
        public double temperature { get; set; }
        public string description { get; set; }
        public double windSpeed { get; set; }
    }

    public static class TemperatureUnitsDictionary
    {
        public static SelectList TemperatureUnitSelectList
        {
            get
            {
                return new SelectList(TemperatureUnitDictionary, "Key", "Value");
            }
        }

        public static readonly IDictionary<int, string> TemperatureUnitDictionary
            = new Dictionary<int, string>
            {
                { 0, "Kelvin" },
                { 1, "Fahrenheit" },
                { 2, "Celsius" }
            };
    }

    public static class GameWeeksDictionary
    {
        public static SelectList GameWeekSelectList
        {
            get
            {
                return new SelectList(GameWeekDictionary, "Key", "Value");
            }
        }

        public static readonly IDictionary<int, string> GameWeekDictionary
            = new Dictionary<int, string>
            {
                { 1, "Week 1" },
                { 2, "Week 2" },
                { 3, "Week 3" },
                { 4, "Week 4" },
                { 5, "Week 5" },
                { 6, "Week 6" },
                { 7, "Week 7" },
                { 8, "Week 8" },
                { 9, "Week 9" },
                { 10, "Week 10" },
                { 11, "Week 11" },
                { 12, "Week 12" },
                { 13, "Week 13" },
                { 14, "Week 14" },
                { 15, "Week 15" },
                { 16, "Week 16" }
            };
    }

    public static class ManagersDictionary
    {
        public static SelectList ManagersSelectList
        {
            get
            {
                return new SelectList(ManagerDictionary, "Key", "Value");
            }
        }

        public static readonly IDictionary<string, string> ManagerDictionary
            = new Dictionary<string, string>
            {
                { "359.l.247388.t.1", "Tom's Team" },
                { "359.l.247388.t.2", "Raymond's Team" },
                { "359.l.247388.t.3", "Brandon's Team" },
                { "359.l.247388.t.4", "Chris's Team" },
                { "359.l.247388.t.5", "Ziad's Team" },
                { "359.l.247388.t.6", "Bashar's Team" },
                { "359.l.247388.t.7", "Jason's Team" },
                { "359.l.247388.t.8", "Cameron's Team" },
                { "359.l.247388.t.9", "Mike's Team" },
                { "359.l.247388.t.10", "Jake's Team" }
            };
    }


}
