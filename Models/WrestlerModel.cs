using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BreakHomework_CThomason.Models
{
    public class WrestlerModel
    {
        public int Id { get; set; }
        public string RingName { get; set; } = string.Empty;
        public string RealName { get; set; } = string.Empty;
        public string Brand { get; set; } = string.Empty;
        public string WeightClass { get; set; } = string.Empty;
        public string Alignment { get; set; } = string.Empty;
        public string Finisher { get; set; } = string.Empty;
        public int Wins { get; set; }
        public int Losses { get; set; }
        public int DebutYear { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}