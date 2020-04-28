using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ALUSimulation.ViewModel
{
    public class MainWindowViewModel : BindableBase
    {

        #region variable

        private string _Wynik = "00000000";
        private string _OperandA = "0111";
        private string _OperandB = "0111";
        private List<string> _ListaOperacji;
        private string _WybranaOperacja = "OR";
        private bool _IsCheckedBox1;
        private bool _IsCheckedBox2 = false;
        private bool _IsCheckedBox3 = false;
        private string _WynikALU1 = "00000000";
        private string _WynikALU2 = "11111111";
        private string _WynikALU3 = "00111";
        #endregion



        #region properties

        public string Wynik
        {
            get
            {
                return _Wynik;
            }
            set
            {
                _Wynik = value;
                RaisePropertyChanged("Wynik");
            }
        }

        public string OperandA
        {
            get
            {
                return _OperandA;
            }
            set
            {
                _OperandA = value;
                RaisePropertyChanged("OperandA");
            }
        }

        public string OperandB
        {
            get
            {
                return _OperandB;
            }
            set
            {
                _OperandB = value;
                RaisePropertyChanged("OperandB");
            }
        }

        public List<string> ListaOperacji
        {
            get
            {
                _ListaOperacji = new List<string> { "OR", "AND", "XOR","ADD","SUB" };
                return _ListaOperacji;
            }
        }

        public string WybranaOperacja
        {
            get
            {
                return _WybranaOperacja;
            }
            set
            {
                _WybranaOperacja = value;
                RaisePropertyChanged("WybranaOperacja");
            }
        }

        public bool IsCheckedBox1
        {
            get
            {
                return _IsCheckedBox1;
            }
            set
            {
                _IsCheckedBox1 = value;
                RaisePropertyChanged("IsCheckedBox1");
            }
        }

        public bool IsCheckedBox2
        {
            get
            {
                return _IsCheckedBox2;
            }
            set
            {
                _IsCheckedBox2 = value;
                RaisePropertyChanged("IsCheckedBox2");
            }
        }

        public bool IsCheckedBox3
        {
            get
            {
                return _IsCheckedBox3;
            }
            set
            {
                _IsCheckedBox3 = value;
                RaisePropertyChanged("IsCheckedBox3");
            }
        }

        public string WynikALU1
        {
            get
            {
                return _WynikALU1;
            }
            set
            {
                _WynikALU1 = value;
                RaisePropertyChanged("WynikALU1");
            }
        }

        public string WynikALU2
        {
            get
            {
                return _WynikALU2;
            }
            set
            {
                _WynikALU2 = value;
                RaisePropertyChanged("WynikALU2");
            }
        }

        public string WynikALU3
        {
            get
            {
                return _WynikALU3;
            }
            set
            {
                _WynikALU3 = value;
                RaisePropertyChanged("WynikALU3");
            }
        }
        #endregion



        #region command

        public ICommand StartButton { get; set; }

        #endregion



        #region constructor

        public MainWindowViewModel()
        {
            StartButton = new DelegateCommand(Start);
        }

        #endregion

        public void Start()
        {
            var rand = new Random();
           // Wynik = rand.Next(10, 100).ToString();
        }
    }
}
