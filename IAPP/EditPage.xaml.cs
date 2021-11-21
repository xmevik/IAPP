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
    /// Логика взаимодействия для EditPage.xaml
    /// </summary>
    public partial class EditPage : Page
    {
        public int choose2;
        public EditPage(int choose)
        {
            InitializeComponent();
            choose2 = choose;
            switch(choose)
            {
                case 1:
                    {
                        GridHouses.Visibility = Visibility;
                        DGHouse.ItemsSource = BaseDomNSLEEntities.GetContext().House.ToList();
                    }
                    break;
                case 2:
                    {
                        GridApartments.Visibility = Visibility;
                        DGApartments.ItemsSource = BaseDomNSLEEntities.GetContext().Apartaments.ToList();
                    }
                    break;
                case 3:
                    {
                        GridComplex.Visibility = Visibility;
                        DGComplex.ItemsSource = BaseDomNSLEEntities.GetContext().ResidentialComplex.ToList();
                    }
                    break;
            }
            
        }
        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            Manager.MEF.Navigate(new Edit((sender as Button).DataContext as House, (sender as Button).DataContext as Apartaments, (sender as Button).DataContext as ResidentialComplex, choose2));
        }
    }
}
