using Microsoft.Extensions.Options;
using System.Text;
using WebApp.Options;

namespace WebApp.Services
{
    public class HotPotatoService
    {
        private int _quantidadeJogadores { get; set; }
        public HotPotatoService(IOptionsSnapshot<HotPotatoOption> options)
        {
            _quantidadeJogadores = options.Value.QuantidadeJogadores;
        }

        public string JogarBatataQuente()
        {
            Random random = new();
            StringBuilder resultadoJogo = new StringBuilder();
            Queue<int> jogadores = new Queue<int>();

            for(int i = 1; i <= _quantidadeJogadores; i++)
                jogadores.Enqueue(i);


            while (jogadores.Count > 1)
            {
                int passes = random.Next(1, 10);

                for (int i = 1; i < passes; i++)
                {
                    int jogador = jogadores.Dequeue();
                    jogadores.Enqueue(jogador);
                }

                int perdedorDaRodada = jogadores.Dequeue();
                resultadoJogo.AppendLine($"O jogador {perdedorDaRodada} perdeu nesta rodada após {passes} passes!");
                resultadoJogo.AppendLine($"Jogadores restantes: {string.Join(", ", jogadores)}");
            }

            resultadoJogo.AppendLine($"O vencedor foi o jogador {jogadores.Peek()}!");
            return resultadoJogo.ToString();
        }
    }
}
