using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALUSimulation.ViewModel
{
    public sealed class BledyViewModel : BindableBase
    {

        #region singleton
        private static BledyViewModel m_oInstance = null;

        public static BledyViewModel Instance
        {
            get
            {
                if (m_oInstance == null)
                {
                    m_oInstance = new BledyViewModel();
                }
                return m_oInstance;
            }
        }
        #endregion


        #region variable
        private bool _IsCheckedBox1 = false;
        private bool _IsCheckedBox2 = false;
        private bool _IsCheckedBox3 = false;


        private string _StrokeColor1 = "BLACK";
        private string _StrokeColor2 = "BLACK";
        private string _StrokeColor3 = "BLACK";


        #endregion


        #region properties
        public bool IsCheckedBox1
        {
            get
            {
                return _IsCheckedBox1;
            }
            set
            {
                _IsCheckedBox1 = value;
                if (_IsCheckedBox1 == true)
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

        #endregion

    }
}
