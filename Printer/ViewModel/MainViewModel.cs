using Printer.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using Printer.View;
using Printer.Models;

namespace Printer.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        public ViewCommand ListPage { get; set; }
        public ViewCommand DevicePage { get; set; }
        public ViewCommand ClaimPage { get; set; }
        private Page currentPage;
        private Device edit;
        private readonly MainViewModel mainViewModel;

        public Page CurrentPage
        {
            get => currentPage;
            set
            {
                currentPage = value;
                SignalChanged();
            }
        }


        public MainViewModel()
        {
            CurrentPage = new ListPage(mainViewModel);

            ListPage = new ViewCommand(() => {
                CurrentPage = new ListPage(mainViewModel);
            });
            DevicePage = new ViewCommand(() => {
                CurrentPage = new DevicePage(new Device(), mainViewModel);
            });
            ClaimPage = new ViewCommand(() => {
                CurrentPage = new ClaimPage( new Claim(), mainViewModel);
            });
        }
    }
}
