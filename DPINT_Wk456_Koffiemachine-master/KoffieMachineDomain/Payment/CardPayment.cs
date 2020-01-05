using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain.Payment
{
    public class CardPayment
    {
        private Dictionary<string, double> _cashOnCards;
        public IDictionary<string, double> CashOnCards
        {
            get { return _cashOnCards; }
        }

        private Payment _payment;

        public CardPayment(Payment payment)
        {
            _payment = payment;
            SetupCards();
        }

        private void SetupCards()
        {
            _cashOnCards = new Dictionary<string, double>();
            _cashOnCards["Arjen"] = 5.0;
            _cashOnCards["Bert"] = 3.5;
            _cashOnCards["Chris"] = 7.0;
            _cashOnCards["Daan"] = 6.0;
        }

        public double Pay(string username)
        {
            double insertedMoney = _cashOnCards[username];
            if (_payment.RemainingPriceToPay <= insertedMoney)
            {
                _cashOnCards[username] = insertedMoney - _payment.RemainingPriceToPay;
                _payment.RemainingPriceToPay = 0;
            }
            else // Pay what you can, fill up with coins later.
            {
                _cashOnCards[username] = 0;

                _payment.RemainingPriceToPay -= insertedMoney;
            }
            return insertedMoney;
        }
    }
}
