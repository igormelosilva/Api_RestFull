using Api_RestFull.Models;
namespace Api_RestFull.Global
{
    public class Config
    {
        public static List<Produto> listProdutos = new List<Produto>();
        public static void GerarProdutos()//entrar na classe program e colocar antes de app.run
        {
            Produto produto = new Produto();
            produto.id = 1;
            produto.name = "Mesa";
            produto.quantity = 1;
            produto.price = 100.5f;
            produto.description = "Produto Teste 1";
            listProdutos.Add(produto);

            produto = new Produto();
            produto.id = 2;
            produto.name = "Cadeira";
            produto.quantity = 20;
            produto.price = 78.83f;
            produto.description = "Produto Teste 2";
            listProdutos.Add(produto);
        }
    }
}
