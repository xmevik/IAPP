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
        public static AddEditPage addEditPage { get; set; }
        public static Coefficients coefficientsPage { get; set; }
        public static NavigateButtonPage navigateButtonsPage { get; set; }
    }
}
