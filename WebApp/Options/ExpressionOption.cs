using System.ComponentModel.DataAnnotations;

namespace WebApp.Options
{
    public class ExpressionOption
    {
        public const string Section = "ExpressionOption";

        [Required]
        public Stack<char> Pilha { get; set; } = new Stack<char>();
    }
}
