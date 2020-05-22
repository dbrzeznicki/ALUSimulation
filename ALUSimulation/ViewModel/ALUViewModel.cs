using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALUSimulation.ViewModel
{
    public sealed class ALUViewModel : BindableBase
    {

        #region singleton
        private static ALUViewModel m_oInstance = null;

        public static ALUViewModel Instance
        {
            get
            {
                if (m_oInstance == null)
                {
                    m_oInstance = new ALUViewModel();
                }
                return m_oInstance;
            }
        }

        #endregion


        #region variable

        private string _OperandA = "22";
        private string _OperandB = "22";
        private List<string> _ListaOperacji;
        private string _WybranaOperacja = "OR";

        #endregion


        #region properties

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
                _ListaOperacji = new List<string> { "OR", "AND", "XOR", "ADD", "SUB" };
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

        #endregion

    }
}
