using CasaDoCodigo.Models;
using CasaDoCodigo.Repositories;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace CasaDoCodigo
{
    public partial class Startup
    {
        class DataService : IDataService
        {
            private readonly ApplicationContext contexto;
            private readonly IProdutoRepository produtoRepository;

            public DataService(ApplicationContext contexto, IProdutoRepository produtoRepository)
            {
                this.contexto = contexto;
                this.produtoRepository = produtoRepository;
            }

            public void InicializaDB()
            {
                contexto.Database.EnsureCreated();
                List<Livro> livors = GetLivros();
                produtoRepository.SaveProdutos(livors);
            }            

            private static List<Livro> GetLivros()
            {
                var json = File.ReadAllText("livros.json");
                var livors = JsonConvert.DeserializeObject<List<Livro>>(json);
                return livors;
            }
        }
    }
}
