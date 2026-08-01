using MiniAutomationToolkit.Core.Models;
using MiniAutomationToolkit.Core.Serivces;
namespace MiniAutomationToolkit.Core
{
    public class PrintReference
    {
        public string Hello()
        {
            return "MiniAutomationToolkit started";
        }
        public string Discount(ClientType clientType, decimal amount)
        {
            var discount = DiscountCalculator.CalculateDiscount(amount, clientType);
            return $"Client: {clientType}, amount: {amount}, discount: {discount}";
        }
    }
}
