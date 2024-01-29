using Microsoft.Extensions.Options;
using System.Text.RegularExpressions;
using WebApp.Options;

namespace WebApp.Services
{
    public class ExpressionService
    {
        private string _expressao { get; set; }
        private static readonly Dictionary<char, char> _sinalDeAssociacao = new Dictionary<char, char>
        {
            { '(', ')' },
            { '{', '}' },
            { '[', ']' }
        };
        public ExpressionService(IOptionsSnapshot<ExpressionOption> options)
        {
            _expressao = options.Value.Expressao;
        }

        public bool ExpressaoEhBalanceada()
        {
            Stack<char> SinaisDeAssociacao = new();
            _expressao = Regex.Replace(_expressao, @"[^\d+\-*/()\[\]{}]", "");

            foreach (char caractere in _expressao)
            {
                if (EhSinalDeAbertura(caractere))
                    SinaisDeAssociacao.Push(caractere);
                else if (EhSinalDeFechamento(caractere))
                {
                    if (SinaisDeAssociacao.Count == 0 || !SinaisCorrespondem(SinaisDeAssociacao.Pop(), caractere))
                        return false;
                }
            }
            return SinaisDeAssociacao.Count == 0;
        }

        private bool EhSinalDeAbertura(char caractere)
        {
            return _sinalDeAssociacao.ContainsKey(caractere);
        }

        private bool EhSinalDeFechamento(char caractere)
        {
            return _sinalDeAssociacao.ContainsValue(caractere);
        }

        private bool SinaisCorrespondem(char sinalAbertura, char sinalFechamento)
        {
            return _sinalDeAssociacao[sinalAbertura] == sinalFechamento;
        }
    }
}
