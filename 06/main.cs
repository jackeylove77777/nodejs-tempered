//C# 标准的事件处理
Stock stock = new Stock("haha", 11.0m);

//注册委托事件
stock.PriceChanged += stock_PriceChanged!;
stock.Price = 17.0m;

void stock_PriceChanged(object sender, PriceChangedEventArgs e)
{
    var increase = (e.NewPrice - e.LastPrice) / e.LastPrice;
    Console.WriteLine($"Alert,{(increase * 100):.0}% stock price increase");
}


public class PriceChangedEventArgs : EventArgs
{
    public readonly decimal LastPrice;
    public readonly decimal NewPrice;

    public PriceChangedEventArgs(decimal lastPrice, decimal newPrice)
    {
        LastPrice = lastPrice;
        NewPrice = newPrice;
    }
}

public class Stock
{
    string symbol;
    decimal price;

    public Stock(string symbol, decimal price)
    {
        this.symbol = symbol;
        this.price = price;
    }

    public event EventHandler<PriceChangedEventArgs> PriceChanged;

    protected virtual void OnPriceChanged(PriceChangedEventArgs e)
    {
        PriceChanged?.Invoke(this, e);
    }

    public decimal Price
    {
        get => price;
        set
        {
            if (price == value) return;
            decimal old = price;
            price = value;
            OnPriceChanged(new PriceChangedEventArgs(old, price));
        }
    }
}