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

        private double _remainingPriceToPay;
        public double RemainingPriceToPay
        {
            get { return _remainingPriceToPay; }
            set { _remainingPriceToPay = value; RaisePropertyChanged(() => RemainingPriceToPay); }
        }

        public ObservableCollection<string> PaymentCardUsernames { get; set; }

        public ICommand PayByCardCommand => new RelayCommand(() =>
        {
            PayDrink(payWithCard: true);
        });
        public ICommand PayByCoinCommand => new RelayCommand<double>(coinValue =>
        {
            Console.WriteLine("Test");
            PayDrink(payWithCard: false, insertedMoney: coinValue);
        });

        public PaymentViewModel(MainViewModel mainVM)
        {
            _mainViewModel = mainVM;
            _payment = new Payment();

            AddPaymentCardUsernames();
        }

        #region ClassSetup
        private void AddPaymentCardUsernames()
        {
            PaymentCardUsernames = new ObservableCollection<string>(_payment.CardPayment.CashOnCards.Keys);
            SelectedPaymentCardUsername = PaymentCardUsernames[0];
        }
        #endregion

        #region PaymentHandling
        private void PayDrink(bool payWithCard, double insertedMoney = 0)
        {
            if(!_mainViewModel.DrinkVM.DrinkExists)
            {
                return;
            }

            if (payWithCard)
            {
                insertedMoney = PayWithCard();
            }
            else if (!payWithCard)
            {
                insertedMoney = PayWithCash(insertedMoney);
            }

            _mainViewModel.LogText.Add($"Inserted {insertedMoney.ToString("C", CultureInfo.CurrentCulture)}, Remaining: {RemainingPriceToPay.ToString("C", CultureInfo.CurrentCulture)}.");

            if (RemainingPriceToPay == 0)
            {
                _mainViewModel.DrinkVM.LogDrinkMaking(_mainViewModel.LogText);
                _mainViewModel.LogText.Add("------------------");
            }
        }

        private double PayWithCard()
        {
            double insertedMoney = _payment.CardPayment.Pay(SelectedPaymentCardUsername, ref _remainingPriceToPay);

            RaisePropertyChanged(() => PaymentCardRemainingAmount);
            return insertedMoney;
        }

        private double PayWithCash(double insertedMoney)
        {
            _payment.CashPayment.Pay(insertedMoney, ref _remainingPriceToPay);

            RaisePropertyChanged(() => PaymentCardRemainingAmount);
            return insertedMoney;
        }
        #endregion
    }
}
