using Printer.DB;
using Printer.Models;
using Printer.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Printer.ViewModel
{
    internal class DevicePageVm : BaseViewModel
    {
        private readonly MainViewModel mainViewModel;

        public ViewCommand Save { get; set; }

        public Models.Type SelectedType { get; set; }
        public Device Devices { get; set; }
        public List<Models.Type> Types { get; set; }

        Device original;
        public DevicePageVm(Device edit, MainViewModel mainViewModel)
        {
            original = edit;
            var db = DEContext.GetInstance();
            Types = db.Types.ToList();
            this.Devices = new Device
            {
                Id = edit.Id,
                NameDevice = edit.NameDevice,
                ModelDevice = edit.ModelDevice,
                IdtypeName = edit.IdtypeName
            };
           
            this.mainViewModel = mainViewModel;
            Save = new ViewCommand(() =>
            {
                if (SelectedType == null)
                {
                    MessageBox.Show("где типок???");
                    return;
                }
                Devices.IdtypeName = SelectedType.Id;
                if (Devices.Id != 0)
                    DEContext.GetInstance().Entry<Device>(original).
                        CurrentValues.SetValues(Devices);
                else
                    DEContext.GetInstance().Devices.Add(Devices);
                DEContext.GetInstance().SaveChanges();
               
            });
    }   }
}
