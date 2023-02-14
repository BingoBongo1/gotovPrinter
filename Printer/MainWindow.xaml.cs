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

namespace Printer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();

            //DB.DEContext.GetInstance().ClaimTypes.AddRange(new[] { 
            //new Models.ClaimType{Id = 4, TypeName="замена картриджа" },
            //new Models.ClaimType{Id = 5, TypeName="update cratridJ" },

            //} );
            //DB.DEContext.GetInstance().SaveChanges();
        }

     
    }
}
