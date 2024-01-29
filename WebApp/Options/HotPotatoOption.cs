using System.ComponentModel.DataAnnotations;

namespace WebApp.Options
{
    public class HotPotatoOption
    {
        public const string Section = "HotPotatoOption";

        [Required]
        public int QuantidadeJogadores { get; set; }
    }
}
