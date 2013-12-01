using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class Stock
    {
        public string Symbol { get; set; }
        public double Price { get; set; }
    }

    public class ExceptionStockNotFound : Exception{}

    public interface IStockPriceManager
    {
        double GetCurrentPrice(Stock stock);
    }

    public class StockPriceManager : IStockPriceManager
    {
        public double GetCurrentPrice(Stock stock)
        {
            Thread.Sleep(5000);//Simulate internet time
            if (stock.Symbol == "MSFT")
                return 35.15;
            if (stock.Symbol == "GOOG")
                return 1001.87;
            throw new ExceptionStockNotFound();
        }
    }

    public class StockSimulator
    {
        public IStockPriceManager StockPriceManager { get; set; }

        public StockSimulator(IStockPriceManager stockPriceManager)
        {
            StockPriceManager = stockPriceManager;
        }

        public bool IsStockGood(Stock stock)
        {
            stock.Price = StockPriceManager.GetCurrentPrice(stock);
            return stock.Price > 0;
        }
    }

    public class FakeStockPriceManager:IStockPriceManager
    {
        public double GetCurrentPrice(Stock stock)
        {
            return 200;
        }
    }
    
}
