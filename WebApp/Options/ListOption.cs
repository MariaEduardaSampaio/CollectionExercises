using System.ComponentModel.DataAnnotations;

namespace WebApp.Options
{
    public class ListOption
    {
        public const string Section = "ListOption";

        [Required]
        public List<string> Lista { get; set; } = new List<string>();
    }
}
