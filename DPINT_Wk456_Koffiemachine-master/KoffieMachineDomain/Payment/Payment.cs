using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain.Payment
{
    public class Payment
    {
        public CashPayment CashPayment { get; private set; }
        public CardPayment CardPayment { get; private set; }

        public Payment()
        {
            CashPayment = new CashPayment();
            CardPayment = new CardPayment();
        }
    }
}
