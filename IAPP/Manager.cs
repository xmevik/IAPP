using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace IAPP
{
    internal class Manager
    {
        public static Frame MEF { get; set; }
        public static Coef coefficientsPage { get; set; }
        public static NavigateButtonPage navigateButtonsPage { get; set; }
        public static ApartmentsListPage apartmentsListPage { get; set; }
        public static EditApartmentPage editApartmentPage { get; set; }
        public static TextBlock titel { get; set; }
        public static Image img { get; set; }
    }
}
