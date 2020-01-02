using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
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

        private Dictionary<string, double> _cashOnCards;
        public double PaymentCardRemainingAmount => _cashOnCards.ContainsKey(SelectedPaymentCardUsername ?? "") ? _cashOnCards[SelectedPaymentCardUsername] : 0;

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

            SetupCards();
            AddPaymentCardUsernames();
        }

        #region ClassSetup
        private void SetupCards()
        {
            _cashOnCards = new Dictionary<string, double>();
            _cashOnCards["Arjen"] = 5.0;
            _cashOnCards["Bert"] = 3.5;
            _cashOnCards["Chris"] = 7.0;
            _cashOnCards["Daan"] = 6.0;
        }

        private void AddPaymentCardUsernames()
        {
            PaymentCardUsernames = new ObservableCollection<string>(_cashOnCards.Keys);
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
                PayWithCash(insertedMoney);
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
            double insertedMoney = _cashOnCards[SelectedPaymentCardUsername];
            if (RemainingPriceToPay <= insertedMoney)
            {
                _cashOnCards[SelectedPaymentCardUsername] = insertedMoney - RemainingPriceToPay;
                RemainingPriceToPay = 0;
            }
            else // Pay what you can, fill up with coins later.
            {
                _cashOnCards[SelectedPaymentCardUsername] = 0;

                RemainingPriceToPay -= insertedMoney;
            }

            RaisePropertyChanged(() => PaymentCardRemainingAmount);
            return insertedMoney;
        }

        private void PayWithCash(double insertedMoney)
        {
            RemainingPriceToPay = Math.Max(Math.Round(RemainingPriceToPay - insertedMoney, 2), 0);
        }
        #endregion
    }
}
