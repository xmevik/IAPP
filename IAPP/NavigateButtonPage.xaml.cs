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

namespace IAPP
{
    /// <summary>
    /// Логика взаимодействия для NavigateButtonPage.xaml
    /// </summary>
    public partial class NavigateButtonPage : Page
    {
        public NavigateButtonPage()
        {
            InitializeComponent();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Manager.MEF.Navigate(Manager.coefficientsPage);
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Manager.MEF.Navigate(Manager.addEditPage);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Manager.MEF.Navigate(Manager.apartmentsListPage);
        }
    }
}
