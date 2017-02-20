using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace YahooFantasyFootball.ViewModels
{
    public class MembersVM
    {
        [Display(Name = "Manager Name")]
        public string TeamManagerName { get; set; }
        [Display(Name = "Final Rank")]
        public string Placement { get; set; }
    }
}
