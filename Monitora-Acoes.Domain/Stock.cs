using MongoDB.Bson;

namespace Monitora_Acoes.Domain
{
    public class Stock
    {
        public int Id { get; set; }
        public string ChatId { get; set; }
        public string Acronym { get; set; }
        public string StockName { get; set; }
        public string PriceInit { get; set; }
        public string PriceMin { get; set; }
        public string PriceMax { get; set; }
        public string DateInit { get; set; }
        public string Status { get; set; } = "1";
    }
}