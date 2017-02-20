using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace YahooFantasyFootball.ViewModels
{
    public class GameWeekVM
    {
        [Required]
        public int GameWeekId { get; set; }
        public IEnumerable<SelectListItem> GameWeekList { get; set; }
    }
}
