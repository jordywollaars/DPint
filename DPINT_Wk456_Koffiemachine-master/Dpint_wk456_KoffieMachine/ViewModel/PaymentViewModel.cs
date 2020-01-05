using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using KoffieMachineDomain.Payment;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Dpint_wk456_KoffieMachine.ViewModel
{
    public class PaymentViewModel : ViewModelBase
    {
        private MainViewModel _mainViewModel;

        private Payment _payment;

        public double PaymentCardRemainingAmount
            => _payment.CardPayment.CashOnCards.ContainsKey(SelectedPaymentCardUsername ?? "") ? _payment.CardPayment.CashOnCards[SelectedPaymentCardUsername] : 0;

        private string _selectedPaymentCardUsername;
        public string SelectedPaymentCardUsername
        {
            get { return _selectedPaymentCardUsername; }
            set
            {
                _selectedPaymentCardUsername = value;
                RaisePropertyChanged(() => SelectedPaymentCardUsername);
                RaisePropertyChanged(() => PaymentCardRemainingAmount);
            }
        }

        public double RemainingPriceToPay
        {
            get { return _payment.RemainingPriceToPay; }
        }

        public double LastInsertedMoney
        {
            get { return _payment.LastInsertedMoney; }
        }

        public ObservableCollection<string> PaymentCardUsernames { get; set; }

        public ICommand PayByCardCommand => new RelayCommand(() =>
        {
            if (_mainViewModel.DrinkVM.DrinkExists)
            {
                _payment.PayWithCard(SelectedPaymentCardUsername);
            }
            RaisePropertyChanged(() => PaymentCardRemainingAmount);
        });
        public ICommand PayByCoinCommand => new RelayCommand<double>(coinValue =>
        {
            if (_mainViewModel.DrinkVM.DrinkExists)
            {
                _payment.PayWithCash(coinValue);
            }
        });

        public PaymentViewModel(MainViewModel mainVM)
        {
            _mainViewModel = mainVM;

            _payment = new Payment();
            _payment.Subscribe(_mainViewModel.DrinkVM);

            AddPaymentCardUsernames();
        }

        private void AddPaymentCardUsernames()
        {
            PaymentCardUsernames = new ObservableCollection<string>(_payment.CardPayment.CashOnCards.Keys);
            SelectedPaymentCardUsername = PaymentCardUsernames[0];
        }

        public void SetPrice(double priceToPay)
        {
            _payment.RemainingPriceToPay = priceToPay;
        }
    }
}
