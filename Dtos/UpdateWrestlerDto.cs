using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BreakHomework_CThomason.Dtos
{
    public class UpdateWrestlerDto
    {
         [Required(ErrorMessage = "Ring name is required")]
          [StringLength(60, MinimumLength = 1, ErrorMessage = "Ring Name must be between 1 and 60 characters")]
        public string RingName { get; set; } = string.Empty;
        [Required(ErrorMessage = "Real name is required")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Real Name must be between 1 and 100 characters")]
        public string RealName { get; set; } = string.Empty;
        [Required(ErrorMessage = "Brand is required")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Brand must be between 1 and 50 characters")]
        public string Brand { get; set; } = string.Empty;
        [Required(ErrorMessage = "Weight class is required")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Weight class must be between 1 and 50 characters")]
        public string WeightClass { get; set; } = string.Empty;
        [Required(ErrorMessage = "Alignment is required")]
               public string Alignment { get; set; } = string.Empty;
        [Required(ErrorMessage = "Finisher is required")]
        [StringLength(60, MinimumLength = 1, ErrorMessage = "Finisher must be between 1 and 60 characters")]
        public string Finisher { get; set; } = string.Empty;
        [Required(ErrorMessage = "Wins is required")]
        [Range(0, int.MaxValue, ErrorMessage = "Wins must be a positive number")]
        public int Wins { get; set; }

        [Required(ErrorMessage = "Losses is required")]
        [Range(0, int.MaxValue, ErrorMessage = "Losses must be a positive number")]
        public int Losses { get; set; }
        [Required(ErrorMessage = "Debut year is required")]
        [Range(1950, 2100, ErrorMessage = "Debut year must be between 1950 and 2100")]
        public int DebutYear { get; set; }
        [Required(ErrorMessage = "Status is required")]
        public string Status { get; set; } = string.Empty;
    }
}