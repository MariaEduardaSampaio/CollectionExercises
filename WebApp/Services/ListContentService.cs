using Microsoft.Extensions.Options;
using WebApp.Options;

namespace WebApp.Services
{
    public class ListContentService
    {
        private List<string> _lista { get; set; } = new();
        public ListContentService(IOptionsSnapshot<ListOption> options)
        {
            _lista = options.Value.Lista;
        }

        public List<string> FiltrarLista()
        {
            List<string> result = new();
            foreach (var palavra in _lista)
            {
                if (palavra.Length >= 10)
                    result.Add(palavra);
            }

            return result;
        }
    }
}
