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
    public sealed class WizualizacjaViewModel : BindableBase
    {

        #region singleton
        private static WizualizacjaViewModel m_oInstance = null;

        public static WizualizacjaViewModel Instance
        {
            get
            {
                if (m_oInstance == null)
                {
                    m_oInstance = new WizualizacjaViewModel();
                }
                return m_oInstance;
            }
        }

        #endregion


        #region variable

        private string _Wynik = "00000000";
        
        private string _WynikALU1 = "00000000";
        private string _WynikALU2 = "00000000";
        private string _WynikALU3 = "00000000";

        private string _OperandABinary = "00000000";
        private string _OperandBBinary = "00000000";
        
        ALUViewModel _ALUViewModel;
        BledyViewModel _BledyViewModel;
        #endregion


        #region properties

        public ALUViewModel ALUViewModel
        {
            get
            {
                _ALUViewModel = ALUViewModel.Instance;
                return _ALUViewModel;
            }
            set
            {
                _ALUViewModel = value;
                RaisePropertyChanged("ALUViewModel");
            }
        }

        public BledyViewModel BledyViewModel
        {
            get
            {
                _BledyViewModel = BledyViewModel.Instance;
                return _BledyViewModel;
            }
            set
            {
                _BledyViewModel = value;
                RaisePropertyChanged("BledyViewModel");
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

       

        public string OperandABinary
        {
            get
            {
                
                _OperandABinary = Utils.SbyteToBinaryString(sbyte.Parse(ALUViewModel.Instance.OperandA), 8);
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
                _OperandBBinary = Utils.SbyteToBinaryString(sbyte.Parse(ALUViewModel.Instance.OperandB), 8);
                return _OperandBBinary;
            }
            set
            {
                _OperandBBinary = value;
                RaisePropertyChanged("OperandBBinary");
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

    }
}
