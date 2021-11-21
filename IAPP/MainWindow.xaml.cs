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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Manager.MEF = MEF;
            Manager.img = img;
            Manager.titel = titelTextBlock;
            Manager.coefficientsPage = new Coef();
            Manager.navigateButtonsPage = new NavigateButtonPage();
            Manager.apartmentsListPage = new ApartmentsListPage();
            Manager.editApartmentPage = new EditApartmentPage(null);

            Manager.MEF.Navigate(Manager.navigateButtonsPage);
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Manager.MEF.GoBack();
            Manager.titel.Text = "Главная страница";
        }

        private void MEF_ContentRendered(object sender, EventArgs e)
        {
            if(MEF.CanGoBack)
            {
                BtnBack.Visibility = Visibility.Visible;
            }
            else
            {
                BtnBack.Visibility = Visibility.Hidden;
            }
        }
    }
}
