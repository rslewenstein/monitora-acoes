namespace Monitora_Acoes.WebApi.Models
{
    public class StockMonitList
    {
        public int Id { get; set; }
        public int StockId { get; set; }
        public string ChatId { get; set; }
        public string PriceInit { get; set; }
        public string PriceMin { get; set; }
        public string PriceMax { get; set; }
        public DateTime Dateinti { get; set; }
        public bool Status { get; set; } = 1;
    }
}