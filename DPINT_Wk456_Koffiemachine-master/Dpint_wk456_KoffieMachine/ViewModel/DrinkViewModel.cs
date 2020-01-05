using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using KoffieMachineDomain.Drink;
using KoffieMachineDomain.Drink.DrinkFactory;
using KoffieMachineDomain.Drink.DispenserAdapter.SpecialCoffee;
using KoffieMachineDomain.Drink.DispenserAdapter.TeaBlendAndHotChoc;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using KoffieMachineDomain.Payment;

namespace Dpint_wk456_KoffieMachine.ViewModel
{
    public class DrinkViewModel : ViewModelBase, IObserver<Payment>
    {
        private MainViewModel _mainVM;

        private DrinkFactory _drinkFactory;

        private IDrink _drink;
        public bool DrinkExists => _drink != null ? true : false;

        public string DrinkName
        {
            get { return _drink?.Name; }
        }
        public double DrinkPrice
        {
            get { return _drink.GetPrice(); }
        }

        public IEnumerable<string> TeaBlends
        {
            get { return TeaAdapter.TeaBlends; }
        }
        public IEnumerable<string> SpecialCoffees
        {
            get { return new SpecialCoffeeJSONHandler().SpecialCoffees.Keys; }
        }

        private string _specialCoffee;
        public string SpecialCoffee
        {
            get { return _specialCoffee; }
            set { _specialCoffee = value; RaisePropertyChanged("SpecialCoffee"); }
        }
        private string _teaBlend;
        public string TeaBlend
        {
            get { return _teaBlend; }
            set { _teaBlend = value; RaisePropertyChanged("TeaBlend"); }
        }
        private Strength _coffeeStrength;
        public Strength CoffeeStrength
        {
            get { return _coffeeStrength; }
            set { _coffeeStrength = value; RaisePropertyChanged(() => CoffeeStrength); }
        }
        private Amount _sugarAmount;
        public Amount SugarAmount
        {
            get { return _sugarAmount; }
            set { _sugarAmount = value; RaisePropertyChanged(() => SugarAmount); }
        }
        private Amount _milkAmount;
        public Amount MilkAmount
        {
            get { return _milkAmount; }
            set { _milkAmount = value; RaisePropertyChanged(() => MilkAmount); }
        }

        public ICommand DrinkCommand => new RelayCommand<string>((drinkName) =>
        {
            _drinkFactory.SetFactorySettings(CoffeeStrength, MilkAmount, SugarAmount, TeaBlend, SpecialCoffee);
            _drink = _drinkFactory.CreateDrink(drinkName, new List<string>());

            HandleNewDrink();
        });
        public ICommand DrinkWithSugarCommand => new RelayCommand<string>((drinkName) =>
        {
            _drinkFactory.SetFactorySettings(CoffeeStrength, MilkAmount, SugarAmount, TeaBlend, SpecialCoffee);
            _drink = _drinkFactory.CreateDrink(drinkName, new List<string>() { "Sugar" });

            HandleNewDrink();
        });
        public ICommand DrinkWithMilkCommand => new RelayCommand<string>((drinkName) =>
        {
            _drinkFactory.SetFactorySettings(CoffeeStrength, MilkAmount, SugarAmount, TeaBlend, SpecialCoffee);
            _drink = _drinkFactory.CreateDrink(drinkName, new List<string>() { "Milk" });

            HandleNewDrink();
        });
        public ICommand DrinkWithSugarAndMilkCommand => new RelayCommand<string>((drinkName) =>
        {
            _drinkFactory.SetFactorySettings(CoffeeStrength, MilkAmount, SugarAmount, TeaBlend, SpecialCoffee);
            _drink = _drinkFactory.CreateDrink(drinkName, new List<string>() { "Sugar", "Milk" });

            HandleNewDrink();
        });

        public DrinkViewModel(MainViewModel mainVM)
        {
            _mainVM = mainVM;
            _drinkFactory = new DrinkFactory();

            _coffeeStrength = Strength.Normal;
            _sugarAmount = Amount.Normal;
            _milkAmount = Amount.Normal;
            TeaBlend = TeaBlends.First();
            SpecialCoffee = SpecialCoffees.First();
        }

        public void LogDrinkMaking(ObservableCollection<string> LogText)
        {
            _drink.LogDrinkMaking(LogText);

            LogText.Add($"Finished making {DrinkName}");
        }

        private void HandleNewDrink()
        {
            if (_drink != null)
            {
                _mainVM.PaymentVM.SetRemainingPrice(DrinkPrice);
                _mainVM.LogText.Add($"Selected {DrinkName}, price: {_mainVM.PaymentVM.RemainingPriceToPay.ToString("C", CultureInfo.CurrentCulture)}");
                RaisePropertyChanged(() => DrinkName);
                RaisePropertyChanged(() => DrinkPrice);
            }
        }

        public void OnNext(Payment value)
        {
            _mainVM.LogText.Add($"Inserted {_mainVM.PaymentVM.LastInsertedMoney.ToString("C", CultureInfo.CurrentCulture)}, Remaining: {_mainVM.PaymentVM.RemainingPriceToPay.ToString("C", CultureInfo.CurrentCulture)}.");

            if (_mainVM.PaymentVM.RemainingPriceToPay == 0)
            {
                LogDrinkMaking(_mainVM.LogText);
                _mainVM.LogText.Add("------------------");
                _drink = null;
            }
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnCompleted()
        {
            throw new NotImplementedException();
        }
    }
}
