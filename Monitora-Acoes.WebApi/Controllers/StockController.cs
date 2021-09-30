using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using Monitora_Acoes.Domain;

namespace Monitora_Acoes.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly IConfiguration _config;
        public StockController(IConfiguration config)
        {
            _config = config;
        }

        [HttpGet]
        public JsonResult Get()
        {
            MongoClient dbCli = new MongoClient(_config.GetConnectionString("MongoStockCon"));
            var dbList = dbCli.GetDatabase("stockdb").GetCollection<Stock>("stockmonit").AsQueryable();
            return new JsonResult(dbList);
        }
    }
}