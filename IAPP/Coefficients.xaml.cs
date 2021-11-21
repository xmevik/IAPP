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
using System.Data.Entity;

namespace IAPP
{
    /// <summary>
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    public partial class Coef : Page
    {
        public Coef()
        {
            InitializeComponent();

        }
        public int choose;

        private void BtnHouse_Click(object sender, RoutedEventArgs e)
        {
            choose = 1;
            Manager.MEF.Navigate(new EditPage(choose));
        }

        private void BtnApartments_Click(object sender, RoutedEventArgs e)
        {
            choose = 2;
            Manager.MEF.Navigate(new EditPage(choose));
        }

        private void BtnComplex_Click(object sender, RoutedEventArgs e)
        {
            choose = 3;
            Manager.MEF.Navigate(new EditPage(choose));
        }
    }
}
