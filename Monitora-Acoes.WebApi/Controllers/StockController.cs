using Microsoft.AspNetCore.Mvc;
using Monitora_Acoes.Data.Interfaces;

namespace Monitora_Acoes.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly IStocksDAO _stockdao;
        public StockController(IStocksDAO stockdao)
        {
            _stockdao = stockdao;
        }

        [HttpGet]
        public JsonResult GetAllStocks()
        {
            return new JsonResult(_stockdao.ListAllStock());
        }

        [HttpGet("{acronym}")]
        public JsonResult GetStockByAcronym(string acronym)
        {
            JsonResult ret = null;
            if (!string.IsNullOrEmpty(acronym))
                ret = new JsonResult(_stockdao.ListStockByAcronym(acronym));

            return ret;
        }

    }
}