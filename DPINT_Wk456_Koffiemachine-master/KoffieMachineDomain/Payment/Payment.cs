using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain.Payment
{
    public class Payment : Observable<Payment>
    {
        public CashPayment CashPayment { get; private set; }
        public CardPayment CardPayment { get; private set; }

        private double _remainingPriceToPay;
        public double RemainingPriceToPay
        {
            get { return _remainingPriceToPay; }
            set { _remainingPriceToPay = value; }
        }

        public double LastInsertedMoney { get; private set; }

        public Payment()
        {
            CashPayment = new CashPayment(this);
            CardPayment = new CardPayment(this);
        }

        public double PayWithCard(string username)
        {
            double insertedMoney = CardPayment.Pay(username);
            HandlePayment(insertedMoney);
            return insertedMoney;
        }

        public double PayWithCash(double insertedMoney)
        {
            CashPayment.Pay(insertedMoney);
            HandlePayment(insertedMoney);
            return insertedMoney;
        }

        private void HandlePayment(double insertedMoney)
        {
            LastInsertedMoney = insertedMoney;
            base.Notify(this);
        }
    }
}
