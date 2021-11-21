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
        private Coefficients _currentcoefficients;
        public Coef()
        {
            InitializeComponent();

            if(_currentcoefficients != null)
            {
                area.Text = _currentcoefficients.area.ToString();
                areac.Text = _currentcoefficients.areac.ToString();
                rooms.Text = _currentcoefficients.rooms.ToString();
                romsc.Text = _currentcoefficients.roomsc.ToString();
                apartmentc.Text = _currentcoefficients.apartmentc.ToString();
                housec.Text = _currentcoefficients.housec.ToString();
                complexc.Text = _currentcoefficients.complexc.ToString();
                basec.Text = _currentcoefficients.basec.ToString();
            }
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            bool flag = false;
            if (_currentcoefficients == null)
            {
                _currentcoefficients = new Coefficients();
                flag = true;
            }
            _currentcoefficients.area = Convert.ToDouble(area.Text);
            _currentcoefficients.areac = Convert.ToDouble(areac.Text);
            _currentcoefficients.rooms = Convert.ToInt32(rooms.Text);
            _currentcoefficients.roomsc = Convert.ToDouble(romsc.Text);
            _currentcoefficients.apartmentc = Convert.ToDouble(apartmentc.Text);
            _currentcoefficients.housec = Convert.ToDouble(housec.Text);
            _currentcoefficients.complexc = Convert.ToDouble(complexc.Text);
            _currentcoefficients.basec = Convert.ToDouble(basec.Text);
            if(flag)
                BaseDomNSLEEntities.GetContext().Coefficients.Add(_currentcoefficients as Coefficients);

            BaseDomNSLEEntities.GetContext().SaveChanges();

        }
    }
}
