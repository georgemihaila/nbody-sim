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

namespace NBodySim.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            App.Current.DispatcherUnhandledException += (se, ev) =>
            {
                ev.Handled = true;
                MessageBox.Show(ev.Exception.ToString());
            };
        }

        private async void NextFrame_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                NextFrame_Button.IsEnabled = false;
                
            }
            catch
            {
                throw;
            }
            finally
            {
                NextFrame_Button.IsEnabled = true;
            }
        }
    }
}
