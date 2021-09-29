using Monitora_Acoes.Domain;
using Xunit;

namespace Monitora_Acoes.Domain.Test
{
    public class StockTest
    {
        [Fact]
        public void Create_Stock_Test()
        {
            var StockExpected = new
            {
                ChatId = "11111",
                Acronym = "aaaa",
                StockName = "A_test",
                PriceInit = "25,00",
                PriceMin = "24,00",
                PriceMax = "30,00",
                Dateinti = "28/09/2021",
                Status = "1"
            };
            var stock = new Stock(
                    StockExpected.ChatId,
                    StockExpected.Acronym,
                    StockExpected.StockName,
                    StockExpected.PriceInit,
                    StockExpected.PriceMin,
                    StockExpected.PriceMax,
                    StockExpected.Dateinti,
                    StockExpected.Status
                );

            Assert.Equal(StockExpected.ChatId, stock.ChatId);
        }
    }
}