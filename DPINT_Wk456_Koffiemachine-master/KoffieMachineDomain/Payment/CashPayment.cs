using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain.Payment
{
    public class CashPayment
    {
        public double Pay(double insertedMoney, ref double remainingPriceToPay)
        {
            remainingPriceToPay = Math.Max(Math.Round(remainingPriceToPay - insertedMoney, 2), 0);
            return insertedMoney;
        }
    }
}
