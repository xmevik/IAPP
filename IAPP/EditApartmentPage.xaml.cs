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
    /// Логика взаимодействия для EditApartmentPage.xaml
    /// </summary>
    public partial class EditApartmentPage : Page
    {
        public Apartaments apartnentData;
        public EditApartmentPage()
        {
            InitializeComponent();
            var houses = BaseDomNSLEEntities.GetContext().House.ToList();
            nameTextCombobox.ItemsSource = houses;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bool flag = false;
            if (apartnentData == null)
            {
                apartnentData = new Apartaments();
                flag = true;
            }

            var houses = BaseDomNSLEEntities.GetContext().House.ToList();

            House selectHouse = houses[nameTextCombobox.SelectedIndex];
            apartnentData.House = selectHouse;

            apartnentData.Area = Convert.ToDouble(areaTextBlock.Text);
            apartnentData.Floor = Convert.ToInt32(floorTextBlock.Text);
            apartnentData.CountOfRooms = Convert.ToInt32(countOfRoomsTextBlock.Text);
            apartnentData.Section = Convert.ToInt32(sectionTextBlock.Text);
            apartnentData.IsSold = Convert.ToBoolean(statusTextBlock.IsChecked);

            if (flag)
                BaseDomNSLEEntities.GetContext().Apartaments.Add(apartnentData);

            BaseDomNSLEEntities.GetContext().SaveChanges();

            Manager.MEF.Navigate(Manager.apartmentsListPage);
            Manager.titel.Text = "Список квартир";
        }
    }
}
