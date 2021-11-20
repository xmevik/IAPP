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
    /// Логика взаимодействия для ApartmentsListPage.xaml
    /// </summary>
    public partial class ApartmentsListPage : Page
    {
        struct apartments
        {

        }
        public ApartmentsListPage()
        {
            InitializeComponent();
            var apartments = BaseDomNSLEEntities.GetContext().Apartaments.ToList();
            LViewApartments.ItemsSource = apartments;
        }

        private void StackPanel_Scroll(object sender, System.Windows.Controls.Primitives.ScrollEventArgs e)
        {

        }

        private void filterBtn_Click(object sender, RoutedEventArgs e)
        {
            filretGroupBox.Visibility = Visibility.Visible;
            addBtn.Visibility = Visibility.Collapsed;
            deleteBtn.Visibility = Visibility.Collapsed;
            filterBtn.Visibility = Visibility.Collapsed;
            pagginateButtonsWrapPanel.Visibility = Visibility.Collapsed;
        }

        private void closeFilterBtn_Click(object sender, RoutedEventArgs e)
        {
            filretGroupBox.Visibility = Visibility.Hidden;
            addBtn.Visibility = Visibility.Visible;
            deleteBtn.Visibility = Visibility.Visible;
            filterBtn.Visibility = Visibility.Visible;
            pagginateButtonsWrapPanel.Visibility = Visibility.Visible;

        }
    }
}
