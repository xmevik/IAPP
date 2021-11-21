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
        public ApartmentsListPage()
        {
            InitializeComponent();

            var residentialComplexs = BaseDomNSLEEntities.GetContext().ResidentialComplex.ToList();
            residentialComplexs.Insert(0, new ResidentialComplex { Name = "Все жилищные комплекса" });
            var houses = BaseDomNSLEEntities.GetContext().House.ToList();
            houses.Insert(0, new House { ID = 0 });

            houseComboBox.ItemsSource = houses;
            residentialComplexComboBox.ItemsSource = residentialComplexs;
            residentialComplexComboBox.SelectedIndex = 0;
            houseComboBox.SelectedIndex = 0;

            updateApartmentsList();
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
            editBtn.Visibility = Visibility.Collapsed;

        }

        private void closeFilterBtn_Click(object sender, RoutedEventArgs e)
        {
            filretGroupBox.Visibility = Visibility.Hidden;
            addBtn.Visibility = Visibility.Visible;
            deleteBtn.Visibility = Visibility.Visible;
            filterBtn.Visibility = Visibility.Visible;
            editBtn.Visibility = Visibility.Visible;
            pagginateButtonsWrapPanel.Visibility = Visibility.Visible;

        }

        private void residentialComplexComboBox_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
           
        }

        private void residentialComplexComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var houses = BaseDomNSLEEntities.GetContext().House.ToList();

            if (residentialComplexComboBox.SelectedIndex > 0)
                houses = houses.Where((item) => item.ResidentialComplexID == residentialComplexComboBox.SelectedIndex).ToList();

            houses.Insert(0, new House { ID = 0 });
            houseComboBox.ItemsSource = houses;

            updateApartmentsList();
        }
        private void updateApartmentsList()
        {
            zeroDataAlert.Visibility = Visibility.Collapsed;
            LViewApartments.Visibility = Visibility.Visible;

            var apartments = BaseDomNSLEEntities.GetContext().Apartaments.ToList();

            if (residentialComplexComboBox.SelectedIndex > 0)
                apartments = apartments.Where((item) => item.House.ResidentialComplexID == residentialComplexComboBox.SelectedIndex).ToList();

            if (houseComboBox.SelectedIndex > 0)
                apartments = apartments.Where((item) => item.HouseID == houseComboBox.SelectedIndex).ToList();

            if (floorTextBox.Text != "")
                apartments = apartments.Where((item) => item.Floor.ToString() == floorTextBox.Text).ToList();

            if (sectionTextBox.Text != "")
                apartments = apartments.Where((item) => item.Section.ToString() == sectionTextBox.Text).ToList();

            if (isSoldCheckBox.IsChecked.Value)
                apartments = apartments.Where((item) => item.IsSold).ToList();

            LViewApartments.ItemsSource = apartments;
            if (apartments.Count <= 0)
            {
                LViewApartments.Visibility = Visibility.Collapsed;
                zeroDataAlert.Visibility = Visibility.Visible;
            }
        }

        private void houseComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            updateApartmentsList();
        }

        private void floorTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            updateApartmentsList();
        }

        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {
            var HotelForRemove = LViewApartments.SelectedItems.Cast<Apartaments>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {HotelForRemove.Count()} элементов?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    BaseDomNSLEEntities.GetContext().Apartaments.RemoveRange(HotelForRemove);
                    BaseDomNSLEEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");

                    LViewApartments.ItemsSource = BaseDomNSLEEntities.GetContext().Apartaments.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            Manager.MEF.Navigate(new EditApartmentPage(null));
            Manager.titel.Text = "Редактирование списка квартир";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var HotelForRemove = LViewApartments.SelectedItems.Cast<Apartaments>().ToList();
            if (HotelForRemove.Count == 1)
            {
                Manager.MEF.Navigate(new EditApartmentPage(HotelForRemove.First<Apartaments>()));
                Manager.titel.Text = "Редактирование списка квартир";
            }
            else
            {
                MessageBox.Show("Выберите одну квартиру");
            }
            
        }

        private void isSoldCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            updateApartmentsList();
        }

        private void isSoldCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            updateApartmentsList();
        }
    }
}
