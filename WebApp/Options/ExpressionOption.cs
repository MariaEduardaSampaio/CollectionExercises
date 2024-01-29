using System.ComponentModel.DataAnnotations;

namespace WebApp.Options
{
    public class ExpressionOption
    {
        public const string Section = "ExpressionOption";

        [Required]
        public string Expressao { get; set; }
    }
}
