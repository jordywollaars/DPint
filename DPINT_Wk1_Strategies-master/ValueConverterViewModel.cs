using DPINT_Wk1_Strategies.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DPINT_Wk1_Strategies
{
    public class ValueConverterViewModel : ViewModelBase
    {
        private string _fromText;
        public string FromText
        {
            get { return _fromText; }
            set
            {
                _fromText = value;
                RaisePropertyChanged("FromText");
                //this.ConvertNumbers();
            }
        }

        private string _toText;
        public string ToText
        {
            get { return _toText; }
            set
            {
                _toText = value;
                RaisePropertyChanged("ToText");
            }
        }

        private INumberConverter _fromConverter;
        private string _fromConverterName;
        public string FromConverterName
        {
            get { return _fromConverterName; }
            set
            {
                _fromConverterName = value;
                _fromConverter = NumberConverterFactory.GetConverter(_fromConverterName);
                RaisePropertyChanged("FromConverterName");
                //this.ConvertNumbers();
            }
        }

        private INumberConverter _toConverter;
        private string _toConverterName;
        public string ToConverterName
        {
            get { return _toConverterName; }
            set
            {
                _toConverterName = value;
                _toConverter = NumberConverterFactory.GetConverter(_toConverterName);
                RaisePropertyChanged("ToConverterName");
                //this.ConvertNumbers();
            }
        }

        public NumberConverterFactory NumberConverterFactory;
        public ObservableCollection<string> ConverterNames { get; set; }
        public ICommand ConvertCommand { get; set; }

        public ValueConverterViewModel()
        {
            NumberConverterFactory = new NumberConverterFactory();
            ConverterNames = new ObservableCollection<string>();
            NumberConverterFactory.ConverterNames.ToList().ForEach(x => ConverterNames.Add(x));

            FromText = "0";
            ToText = "0";
            FromConverterName = ConverterNames[0];
            ToConverterName = ConverterNames[0];

            ConvertCommand = new RelayCommand(ConvertNumbers);
        }

        private void ConvertNumbers()
        {
            try
            {
                int number = _fromConverter.ToNumerical(FromText);
                ToText = _toConverter.ToLocalString(number);

            }
            catch (FormatException e)
            {
                ToText = "Error!";
            }
        }
    }
}
