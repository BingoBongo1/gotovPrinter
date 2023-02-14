using Printer.Models;
using Printer.ViewModel;
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

namespace Printer.View
{
    /// <summary>
    /// Логика взаимодействия для ClaimPage.xaml
    /// </summary>
    public partial class ClaimPage : Page
    {
        public ClaimPage(Claim edit, MainViewModel mainViewModel)
        {
            InitializeComponent();
            DataContext = new ClaimPageVm(edit, mainViewModel);
        }
    }
}
