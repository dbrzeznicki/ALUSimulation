using ALUSimulation.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TMRSim;

namespace ALUSimulation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainWindowViewModel vm = new MainWindowViewModel();
            this.DataContext = vm;
        }

        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    MainWindowViewModel vm = ((MainWindowViewModel)DataContext);

        //    TMR tmr = new TMR();

        //    sbyte a = sbyte.Parse(vm.OperandA),
        //        b = sbyte.Parse(vm.OperandB);
        //    OPERATION_TYPE type = Utils.StringOperationToEnum(vm.WybranaOperacja);

        //    bool[] isErr = new bool[3];

        //    isErr[0] = vm.IsCheckedBox1;
        //    isErr[1] = vm.IsCheckedBox2;
        //    isErr[2] = vm.IsCheckedBox3;

        //    tmr.SimulateOnce(a, b, type,isErr);

        //    vm.WynikALU1 = Utils.SbyteToBinaryString(tmr.GetALU_Result(0),8);
        //    vm.WynikALU2 = Utils.SbyteToBinaryString(tmr.GetALU_Result(1),8);
        //    vm.WynikALU3 = Utils.SbyteToBinaryString(tmr.GetALU_Result(2),8);

        //    string voter = Utils.SbyteToBinaryString(tmr.GetVoter_Result(),8);

        //    vm.Wynik = voter;
        //}

      
    }
}
