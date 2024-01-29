using Microsoft.Extensions.Options;
using System.Text;
using WebApp.Options;

namespace WebApp.Services
{
    public class HotPotatoService
    {
        private Queue<string> _fila { get; set; } = new();
        public HotPotatoService(IOptionsSnapshot<HotPotatoOption> options)
        {
            _fila = options.Value.Fila;
        }

        public string JogarBatataQuente()
        {
            Random random = new();
            StringBuilder resultadoJogo = new StringBuilder();
            string? pessoa = null;

            while (_fila.Count > 0)
            {
                int passes = random.Next(1, 30);
                int indicePessoaPerdedora = passes % _fila.Count;

                for (int i = 0; i < indicePessoaPerdedora; i++)
                {
                    pessoa = _fila.Dequeue();
                    resultadoJogo.AppendLine($"Jogador {pessoa} perdeu!");
                }
            }

            resultadoJogo.AppendLine($"O vencedor foi {pessoa}!");
            return resultadoJogo.ToString();
        }
    }
}
