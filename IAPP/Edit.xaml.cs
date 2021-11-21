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
    /// Логика взаимодействия для Edit.xaml
    /// </summary>
    public partial class Edit : Page
    {
        private House _currenthouse = new House();
        private Apartaments _currentapartments = new Apartaments();
        private ResidentialComplex _currentcomplex = new ResidentialComplex();
        private int choose2;
        public Edit(House house, Apartaments apartament, ResidentialComplex residentialComplex, int choose)
        {
            InitializeComponent();
            choose2 = choose;
            switch(choose)
            {
                case 1:
                    {
                        GridHouses.Visibility = Visibility;
                        _currenthouse = house;
                        DataContext = _currenthouse;
                    }
                    break;
                case 2:
                    {
                        GridApartments.Visibility = Visibility;
                        _currentapartments = apartament;
                        DataContext = _currentapartments;
                    }
                    break;
                case 3:
                    {
                        GridComplex.Visibility = Visibility;
                        _currentcomplex = residentialComplex;
                        DataContext = _currentcomplex;
                    }
                    break;
            }
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            switch(choose2)
            {
                case 1:
                    {
                        if(_currenthouse.ID == 0)
                        BaseDomNSLEEntities.GetContext().House.Add(_currenthouse);
                    }
                    break;
                case 2:
                    {
                        if(_currentapartments.ID == 0)
                        BaseDomNSLEEntities.GetContext().Apartaments.Add(_currentapartments);
                    }
                    break;
                case 3:
                    {
                        if(_currentcomplex.ID == 0)
                        BaseDomNSLEEntities.GetContext().ResidentialComplex.Add(_currentcomplex);
                    }
                    break;
            }
            try
            {
                BaseDomNSLEEntities.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
