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

        public CardPayment()
        {
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

        public double Pay(string username, ref double remainingPriceToPay)
        {
            double insertedMoney = _cashOnCards[username];
            if (remainingPriceToPay <= insertedMoney)
            {
                _cashOnCards[username] = insertedMoney - remainingPriceToPay;
                remainingPriceToPay = 0;
            }
            else // Pay what you can, fill up with coins later.
            {
                _cashOnCards[username] = 0;

                remainingPriceToPay -= insertedMoney;
            }
            return insertedMoney;
        }
    }
}
