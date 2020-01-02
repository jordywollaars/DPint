using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using KoffieMachineDomain;
using KoffieMachineDomain.DrinkFactory;
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
    public class DrinkViewModel : ViewModelBase
    {
        private MainViewModel _mainVM;

        private DrinkFactory _drinkFactory;

        private IDrink _drink;
        public bool DrinkExists => _drink != null ? true : false;

        public string DrinkName
        {
            get { return _drink?.Name; }
        }
        public double? DrinkPrice
        {
            get { return _drink?.GetPrice(); }
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
            _drinkFactory.SetFactorySettings(CoffeeStrength, MilkAmount, SugarAmount);
            _drink = _drinkFactory.CreateDrink(drinkName, new List<string>());

            HandleNewDrink();
        });
        public ICommand DrinkWithSugarCommand => new RelayCommand<string>((drinkName) =>
        {
            _drinkFactory.SetFactorySettings(CoffeeStrength, MilkAmount, SugarAmount);
            _drink = _drinkFactory.CreateDrink(drinkName, new List<string>() { "Sugar" });

            HandleNewDrink();
        });
        public ICommand DrinkWithMilkCommand => new RelayCommand<string>((drinkName) =>
        {
            _drinkFactory.SetFactorySettings(CoffeeStrength, MilkAmount, SugarAmount);
            _drink = _drinkFactory.CreateDrink(drinkName, new List<string>() { "Milk" });

            HandleNewDrink();
        });
        public ICommand DrinkWithSugarAndMilkCommand => new RelayCommand<string>((drinkName) =>
        {
            _drinkFactory.SetFactorySettings(CoffeeStrength, MilkAmount, SugarAmount);
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
                _mainVM.PaymentVM.RemainingPriceToPay = _drink.GetPrice();
                _mainVM.LogText.Add($"Selected {DrinkName}, price: {_mainVM.PaymentVM.RemainingPriceToPay.ToString("C", CultureInfo.CurrentCulture)}");
                RaisePropertyChanged(() => DrinkName);
                RaisePropertyChanged(() => DrinkPrice);
            }
        }
    }
}
