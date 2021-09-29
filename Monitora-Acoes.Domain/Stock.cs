namespace Monitora_Acoes.Domain
{
    public class Stock
    {
        public string ChatId { get; set; }
        public string Acronym { get; set; }
        public string StockName { get; set; }
        public string PriceInit { get; set; }
        public string PriceMin { get; set; }
        public string PriceMax { get; set; }
        public DateTime Dateinti { get; set; }
        public bool Status { get; set; } = 1;
    }
}