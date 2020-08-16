using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    class FactoryMethod
    {
        public static void Driver()
        {
            PaymentProcessor paymentProcessor = new PaymentProcessor();

            var product = new Product("Park Avenue Voyage", 250, "Items : Mens Body Deodrant");
            paymentProcessor.MakePayment(PaymentMethod.BestOne, product);
        }
    }

    public class Product
    {
        public Product(string name, int price, string desc)
        {
            Name = name;
            Price = price;
            Description = desc;
        }
        public string Name { get; }
        public int Price { get; }
        public string Description { get; }
    }

    public enum PaymentMethod
    {
        AxisBank,
        HDFCBank,
        BestOne
    }

    public interface IPaymentGateWay
    {
        void MakePayment(Product product);
    }

    public class AxisBank : IPaymentGateWay
    {
        public void MakePayment(Product product) => Console.WriteLine($"Axis bank payment gateway for  {product.Name} , amount is  {product.Price}");        
    }

    public class HDFCBank : IPaymentGateWay
    {
        public void MakePayment(Product product) => Console.WriteLine($"HDFC bank payment gateway for  {product.Name} , amount is  {product.Price}");        
    }

    public interface IPaymentGatewayFactory
    {
        IPaymentGateWay GetPaymentGateWay(PaymentMethod paymentMethod, Product product);
    }


    public class PaymentGatewayFactory : IPaymentGatewayFactory
    {
        IPaymentGateWay paymentGateWay;

        public IPaymentGateWay GetPaymentGateWay(PaymentMethod paymentMethod, Product product)
        {
            switch(paymentMethod)
            {
                case PaymentMethod.AxisBank:
                    paymentGateWay =  new AxisBank();
                    break;
                case PaymentMethod.HDFCBank:
                    paymentGateWay =  new HDFCBank();
                    break;
                case PaymentMethod.BestOne:
                    if (product.Price > 50)
                        paymentGateWay = new AxisBank();
                    else
                        paymentGateWay = new HDFCBank();
                    break;
                default:
                    paymentGateWay = new AxisBank();
                    break;
            }
            return paymentGateWay;
        }
    }

    public class PaymentProcessor
    {
        IPaymentGatewayFactory paymentGateWay;

        public PaymentProcessor()
        {
            paymentGateWay = new PaymentGatewayFactory();
        }

        public void MakePayment(PaymentMethod paymentMethod, Product product)
        {
            paymentGateWay.GetPaymentGateWay(paymentMethod, product).MakePayment(product);
        }
    }
}
