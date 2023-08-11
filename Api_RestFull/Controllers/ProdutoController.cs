using Api_RestFull.Global;
using Api_RestFull.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api_RestFull.Controllers
{
    [ApiController]
    [Route("api/Api_RestFull")]
    public class ProdutoController : Controller
    {
        [HttpGet]
        [Route("GetAll")]
        public JsonResult GetAll()
        {
            List<Produto> listProdutos = new List<Produto>();
            try
            {
                listProdutos = Config.listProdutos;

                if (listProdutos.Count > 0)
                {
                    return new JsonResult(new { success = true, produtos = listProdutos });
                }
                else
                {
                    return new JsonResult(new { success = false, msg = "0 produtos encontrados" });
                }
            }
            catch (Exception ex)
            {

                return new JsonResult(new { success = false, msg = ex.Message });
            }
        }
        [HttpPost]
        [Route("Add")]
        public JsonResult Add(Produto produto)
        {
            try
            {
                Config.listProdutos.Add(produto);
                return new JsonResult(new { success = true, msg = "Produto "+ produto.name+" adicionado com sucesso "});
            }
            catch (Exception ex)
            {

                return new JsonResult(new { success = false, msg = ex.Message });
            }

        }
        [HttpPut]
        [Route("Update")]
        public JsonResult Update(Produto produto)
        {
            int idx = -1;
            try
            {
                idx = Config.listProdutos.FindIndex(x => x.id == produto.id);
                if (idx >= 0)
                {
                    Config.listProdutos[idx] = produto;
                    return new JsonResult(new { success = true, msg = "Produto " + produto.id + " alterado"});
                }
                else
                    return new JsonResult(new { success = false, msg = "0 produtos encontrados" });

            }
            catch (Exception ex)
            {

                return new JsonResult(new { success = false, msg = ex.Message }); ;
            }
        }
        [HttpDelete]
        [Route("Delete")]
        public JsonResult Delete(int id)
        {
            int idx = -1;
            try
            {
                idx = Config.listProdutos.FindIndex(x => x.id == id);
                if (idx >= 0)
                {
                    Config.listProdutos.RemoveAt(idx);
                    return new JsonResult(new { success = true, msg = "Produto " + id + " excluído" });
                }
                else
                    return new JsonResult(new { success = false, msg = "0 produtos encontrados" });

            }
            catch (Exception ex)
            {

                return new JsonResult(new { success = false, msg = ex.Message }); ;
            }
        }
    }
}
