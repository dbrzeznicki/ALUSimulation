using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TMRSim;

namespace ALUSimulation.ViewModel
{
    public class MainWindowViewModel : BindableBase
    {

        #region variable

        private string _Wynik = "00000000";
        private sbyte _WynikDecimal = 0;

        private string _OperandA = "22";
        private string _OperandB = "22";
        private List<string> _ListaOperacji;
        private string _WybranaOperacja = "OR";
        private bool _IsCheckedBox1 = false;
        private bool _IsCheckedBox2 = false;
        private bool _IsCheckedBox3 = false;
        private string _WynikALU1 = "00000000";
        private string _WynikALU2 = "00000000";
        private string _WynikALU3 = "00000000";

        private string _StrokeColor1 = "BLACK";
        private string _StrokeColor2 = "BLACK";
        private string _StrokeColor3 = "BLACK";

        private string _OperandABinary = "00000000";
        private string _OperandBBinary = "00000000";

        #endregion



        #region properties

        public sbyte WynikDecimal
        {
            get
            {
                return _WynikDecimal;
            }
            set
            {
                _WynikDecimal = value;
                RaisePropertyChanged("WynikDecimal");
            }
        }

        public string StrokeColor1
        {
            get
            {
                return _StrokeColor1;
            }
            set
            {
                _StrokeColor1 = value;
                RaisePropertyChanged("StrokeColor1");
            }
        }

        public string StrokeColor2
        {
            get
            {
                return _StrokeColor2;
            }
            set
            {
                _StrokeColor2 = value;
                RaisePropertyChanged("StrokeColor2");
            }
        }

        public string StrokeColor3
        {
            get
            {
                return _StrokeColor3;
            }
            set
            {
                _StrokeColor3 = value;
                RaisePropertyChanged("StrokeColor3");
            }
        }

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

        public string OperandABinary
        {
            get
            {
                _OperandABinary = Utils.SbyteToBinaryString(sbyte.Parse(_OperandA), 8);
                return _OperandABinary;
            }
            set
            {
                _OperandABinary = value;
                RaisePropertyChanged("OperandABinary");
            }
        }

        public string OperandBBinary
        {
            get
            {
                _OperandBBinary = Utils.SbyteToBinaryString(sbyte.Parse(_OperandB), 8);
                return _OperandBBinary;
            }
            set
            {
                _OperandBBinary = value;
                RaisePropertyChanged("OperandBBinary");
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
                if(_IsCheckedBox1 == true)
                    StrokeColor1 = "RED";
                else
                    StrokeColor1 = "Black";
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
                if (_IsCheckedBox2 == true)
                    StrokeColor2 = "RED";
                else
                    StrokeColor2 = "Black";
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
                if (_IsCheckedBox3 == true)
                    StrokeColor3 = "RED";
                else
                    StrokeColor3 = "Black";
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
            bool checkOperandA = Utils.CheckOperandRange(int.Parse(OperandA));
            bool checkOperandB = Utils.CheckOperandRange(int.Parse(OperandB));

            if (checkOperandA && checkOperandB)
            {
                TMR tmr = new TMR();

                sbyte a = sbyte.Parse(OperandA),
                    b = sbyte.Parse(OperandB);
                OPERATION_TYPE type = Utils.StringOperationToEnum(WybranaOperacja);

                bool[] isErr = new bool[3];

                isErr[0] = IsCheckedBox1;
                isErr[1] = IsCheckedBox2;
                isErr[2] = IsCheckedBox3;

                tmr.SimulateOnce(a, b, type, isErr);

                WynikALU1 = Utils.SbyteToBinaryString(tmr.GetALU_Result(0), 8);
                WynikALU2 = Utils.SbyteToBinaryString(tmr.GetALU_Result(1), 8);
                WynikALU3 = Utils.SbyteToBinaryString(tmr.GetALU_Result(2), 8);

                WynikDecimal = tmr.GetVoter_Result();

                string voter = Utils.SbyteToBinaryString(WynikDecimal, 8);

                Wynik = voter;

                RaisePropertyChanged("OperandABinary");
                RaisePropertyChanged("OperandBBinary");
            } else
            {
                MessageBox.Show("Wartości operandów powinny być z zakresu <-128, 127>");
            }

        }
    }
}
