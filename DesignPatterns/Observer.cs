using System;
using System.Collections.Generic;

namespace DesignPatterns
{
    /*
     * Defines one-to-many dependency between objects
     * i.e. when one object changes state, then all its dependents are notified and updated
     * https://www.dofactory.com/net/observer-design-pattern
     */
    public class Observer
    {
        public static void Driver()
        {
            IBM ibm = new IBM("IBM", 25.5);
            
            Investor investorOne = new Investor("Prem", new List<Stock>() { ibm });
            //Investor investorTwo = new Investor("Pallavi", new List<Stock>() { ibm });

            ibm.Attach(investorOne);
            //ibm.Attach(investorTwo);

            ibm.Price = 25.1;
            ibm.Price = 25.6;
            ibm.Price = 55.5;
            ibm.Price = 55.5;
            ibm.Price = 59.5;
        }
    }

    public interface IStock
    {
        List<IInvestor> Investors { get; set; }
        void Attach(IInvestor investor);
        void Dettach(IInvestor investor);
        void Notify();
    }

    public abstract class Stock : IStock
    {
        public List<IInvestor> Investors { get; set; } = new List<IInvestor>();

        public string Symbol { get; }

        private double price;
        public double Price
        {
            get { return price; }
            set
            {
                if(price != value)
                {
                    price = value;
                    Notify();
                }
            }
        }
        
        public Stock(string smbl, double price)
        {
            Symbol = smbl;
            Price = price;
        }

        public void Attach(IInvestor investor) => Investors.Add(investor);

        public void Dettach(IInvestor investor) => Investors.Remove(investor);

        public void Notify()
        {
            foreach (var inv in Investors)
                inv.Update(this);
        }
    }


    public class IBM : Stock
    {
        //Base Constructor to be called 
        public IBM(string smbl, double price) : base(smbl, price)
        {
        }
    }

    public interface IInvestor
    {
        string Name { get; }
        List<Stock> Purchased { get; set; }
        void Add(Stock stock);
        void Remove(Stock stock);
        void Update(Stock stock);        
    }

    public class Investor : IInvestor
    {
        public Investor(string name, List<Stock> purchased)
        {
            Name = name;
            Purchased = purchased;
        }
        public string Name { get; }

        public List<Stock> Purchased { get; set; }

        public void Add(Stock stock) => Purchased.Add(stock);

        public void Remove(Stock stock) => Purchased.Remove(stock);

        public void Update(Stock stock)
        {
            Console.WriteLine($"{stock.Symbol} price has been changed to {stock.Price}, for Investor : {Name}");
        }
    }
}
