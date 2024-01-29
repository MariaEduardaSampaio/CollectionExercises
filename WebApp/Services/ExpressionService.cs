using Microsoft.Extensions.Options;
using WebApp.Options;

namespace WebApp.Services
{
    public class ExpressionService
    {
        private Stack<char> _pilha { get; set; } = new();
        public ExpressionService(IOptionsSnapshot<ExpressionOption> options)
        {
            _pilha = options.Value.Pilha;
        }

        public bool ExpressaoEhBalanceada()
        {
            Stack<char> SinaisDeAssociacao = new();

            foreach (char caractere in _pilha)
            {
                if (EhSinalDeAbertura(caractere))
                    SinaisDeAssociacao.Push(caractere);
                else if (EhSinalDeFechamento(caractere))
                {
                    if (SinaisDeAssociacao.Count == 0)
                        return false;

                    if (!SinaisCorrespondem(caractere))
                        return false;
                }
                else
                    continue;
            }
            return true;
        }

        private bool EhSinalDeAbertura(char caractere)
        {
            return caractere == '(' || caractere == '[' || caractere == '{';
        }

        private bool EhSinalDeFechamento(char caractere)
        {
            return caractere == ')' || caractere == ']' || caractere == '}';
        }

        private bool SinaisCorrespondem(char sinalFechamento)
        {
            if ((_pilha.Contains('(') && sinalFechamento == ')')
                || (_pilha.Contains('[') && sinalFechamento == ']')
                || (_pilha.Contains('{') && sinalFechamento == '}'))
                return true;
            return false;
        }
    }
}
