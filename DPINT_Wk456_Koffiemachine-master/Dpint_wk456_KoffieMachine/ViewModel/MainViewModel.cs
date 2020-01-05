using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using KoffieMachineDomain;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows.Input;

namespace Dpint_wk456_KoffieMachine.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public ObservableCollection<string> LogText { get; private set; }
        
        public DrinkViewModel DrinkVM
        {
            get; set;
        }

        public PaymentViewModel PaymentVM
        {
            get; set;
        }

        public MainViewModel()
        {
            LogText = new ObservableCollection<string>();
            LogText.Add("Starting up...");

            DrinkVM = new DrinkViewModel(this);
            PaymentVM = new PaymentViewModel(this);

            LogText.Add("Done, what would you like to drink?");
        }
    }
}