using MongoDB.Bson;

namespace Monitora_Acoes.Domain
{
    public class Stock
    {
        public ObjectId Id { get; set; }
        public string ChatId { get; set; }
        public string Acronym { get; set; }
        public string StockName { get; set; }
        public string PriceInit { get; set; }
        public string PriceMin { get; set; }
        public string PriceMax { get; set; }
        public string DateInit { get; set; }
        public string Status { get; set; } = "1";

        public Stock(ObjectId id, string chatId, string acronym, string stockName,
                     string priceInit, string priceMin, string priceMax,
                     string dateInit, string status)
        {
            this.Id = id;
            this.ChatId = chatId;
            this.Acronym = acronym;
            this.StockName = stockName;
            this.PriceInit = priceInit;
            this.PriceMin = priceMin;
            this.PriceMax = priceMax;
            this.DateInit = dateInit;
            this.Status = status;
        }
    }
}