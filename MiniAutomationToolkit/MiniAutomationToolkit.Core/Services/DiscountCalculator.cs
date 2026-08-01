using MiniAutomationToolkit.Core.Models;
namespace MiniAutomationToolkit.Core.Serivces
{
    public class DiscountCalculator
    {
        public static decimal CalculateDiscount(decimal orderAmount, ClientType clientType)
        {
            if (orderAmount < 0)
            {
                throw new ArgumentOutOfRangeException("Сумма меньше 0");
            }
            switch (clientType)
            {
                case ClientType.Vip:
                    {
                        return orderAmount * 0.15m;
                    }
                case ClientType.Premium:
                    {
                        if (orderAmount > 1000)
                        {
                            return orderAmount * 0.1m;
                        }
                        else
                        {
                            return (orderAmount * 0.05m);
                        }

                    }
                case ClientType.Regular:
                    {
                        if (orderAmount > 1000)
                        {
                            return orderAmount * 0.05m;
                        }
                        else
                        {
                            return orderAmount * 0.0m;
                        }
                    }
                default:
                    {
                        throw new Exception("Клиент вне бизнесс логики");
                        return 0;
                    }
            }
        }
    }
}