using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain.Payment
{
    public class CashPayment
    {
        private Payment _payment;

        public CashPayment(Payment payment)
        {
            _payment = payment;
        }

        public double Pay(double insertedMoney)
        {
            _payment.RemainingPriceToPay = Math.Max(Math.Round(_payment.RemainingPriceToPay - insertedMoney, 2), 0);
            return insertedMoney;
        }
    }
}
