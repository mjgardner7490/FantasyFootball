using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace YahooFantasyFootball.ViewModels
{
    public class GameWeekVM
    {
        [DisplayName("Select a category")]
        public int GameWeekId { get; set; }
        public IEnumerable<SelectListItem> GameWeekList { get; set; }
    }
}
