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
    public class StartViewModel : BindableBase
    {

        #region singleton 
        private static StartViewModel m_oInstance = null;

        public static StartViewModel Instance
        {
            get
            {
                if (m_oInstance == null)
                {
                    m_oInstance = new StartViewModel();
                }
                return m_oInstance;
            }
        }

        #endregion


        #region variable

        private sbyte _WynikDecimal = 0;

        #endregion


        #region command

        public ICommand StartButton { get; set; }

        #endregion


        #region constructor

        public StartViewModel()
        {
            StartButton = new DelegateCommand(Start);
        }

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

        #endregion


        #region method

        public void Start()
        {
            bool checkOperandA = Utils.CheckOperandRange(int.Parse(ALUViewModel.Instance.OperandA));
            bool checkOperandB = Utils.CheckOperandRange(int.Parse(ALUViewModel.Instance.OperandB));

            if (checkOperandA && checkOperandB)
            {
                TMR tmr = new TMR();

                sbyte a = sbyte.Parse(ALUViewModel.Instance.OperandA),
                    b = sbyte.Parse(ALUViewModel.Instance.OperandB);
                OPERATION_TYPE type = Utils.StringOperationToEnum(ALUViewModel.Instance.WybranaOperacja);

                bool[] isErr = new bool[3];

                isErr[0] = BledyViewModel.Instance.IsCheckedBox1;
                isErr[1] = BledyViewModel.Instance.IsCheckedBox2;
                isErr[2] = BledyViewModel.Instance.IsCheckedBox3;

                tmr.SimulateOnce(a, b, type, isErr);

                WizualizacjaViewModel.Instance.WynikALU1 = Utils.SbyteToBinaryString(tmr.GetALU_Result(0), 8);
                WizualizacjaViewModel.Instance.WynikALU2 = Utils.SbyteToBinaryString(tmr.GetALU_Result(1), 8);
                WizualizacjaViewModel.Instance.WynikALU3 = Utils.SbyteToBinaryString(tmr.GetALU_Result(2), 8);

                WynikDecimal = tmr.GetVoter_Result();

                string voter = Utils.SbyteToBinaryString(WynikDecimal, 8);

                WizualizacjaViewModel.Instance.Wynik = voter;

                WizualizacjaViewModel.Instance.OperandABinary = Utils.SbyteToBinaryString(sbyte.Parse(ALUViewModel.Instance.OperandA), 8);
                WizualizacjaViewModel.Instance.OperandBBinary = Utils.SbyteToBinaryString(sbyte.Parse(ALUViewModel.Instance.OperandB), 8);

                Utils.WriteLog("Kliknięto start");
                Utils.WriteLog("Parametry uruchomienia: " +
                    "\nOperand A: " + ALUViewModel.Instance.OperandA +
                    "\nOperand B: " + ALUViewModel.Instance.OperandB +
                    "\nOperacja: " + ALUViewModel.Instance.WybranaOperacja +
                    "\nBłąd ALU1: " + BledyViewModel.Instance.IsCheckedBox1.ToString() + " - " + WizualizacjaViewModel.Instance.WynikALU1.ToString() +
                    "\nBłąd ALU2: " + BledyViewModel.Instance.IsCheckedBox2.ToString() + " - " + WizualizacjaViewModel.Instance.WynikALU2.ToString() +
                    "\nBłąd ALU3: " + BledyViewModel.Instance.IsCheckedBox3.ToString() + " - " + WizualizacjaViewModel.Instance.WynikALU3.ToString() +
                    "\nWynik: " + WynikDecimal.ToString());
            }
            else
            {
                MessageBox.Show("Wartości operandów powinny być z zakresu <-128, 127>");
            }

        }

        #endregion

    }
}
