using Microsoft.Extensions.Options;
using System.Text;
using WebApp.Options;

namespace WebApp.Services
{
    public class TextStatisticsService
    {
        private string _texto { get; set; }
        public TextStatisticsService(IOptionsSnapshot<TextStatisticsOption> options)
        {
            _texto = options.Value.Texto!;
        }

        public string ContarOcorrenciaDePalavras()
        {
            Dictionary<string, int> ocorrenciaDePalavras = new();
            string[] palavras = _texto.Split(new[] { ' ', '\t', '\n', '\r', '.', ',', '!', '?', '/', ':', ';', '<', '>','(', ')', '\'', '\"' }, StringSplitOptions.RemoveEmptyEntries);
            StringBuilder resultado = new StringBuilder();

            foreach (string palavra in palavras)
            {
                string palavraMinusc = palavra.ToLowerInvariant();

                if (ocorrenciaDePalavras.ContainsKey(palavraMinusc))
                    ocorrenciaDePalavras[palavraMinusc]++;
                else
                    ocorrenciaDePalavras[palavraMinusc] = 1;
            }

            foreach (var palavra in ocorrenciaDePalavras)
                resultado.AppendLine($"{palavra.Key}: {palavra.Value} repetições.");

            return resultado.ToString();
        }
    }
}
