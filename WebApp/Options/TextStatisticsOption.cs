using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Options
{
    public class TextStatisticsOption
    {
        public const string Section = "TextStatisticsOption";

        [Required]
        public string? Texto { get; set; }
    }
}
