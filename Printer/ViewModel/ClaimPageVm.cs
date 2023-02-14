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
    public class ClaimPageVm : BaseViewModel
    {
        private readonly MainViewModel mainViewModel;

        public ViewCommand Save { get; set; }

        public Models.Device SelectedDevice { get; set; }
        public Models.Cabinet SelectedCabinet { get; set; }
        public Models.ClaimType SelectedTypeClaim { get; set; }
        public Claim Claims { get; set; }
        public List<Models.Device> Devices { get; set; }
        public List<Models.Type> Types { get; set; }
        public List<Models.Cabinet> Cabinets { get; set; }
        public List<Models.ClaimType> ClaimTypes { get; set; }

        Claim original;
        public ClaimPageVm(Claim edit, MainViewModel mainViewModel)
        {
            original = edit;
            var db = DEContext.GetInstance();
            Devices = db.Devices.ToList();
            Types = db.Types.ToList();
            Cabinets = db.Cabinets.ToList();
            ClaimTypes = db.ClaimTypes.ToList();
            this.Claims = new Claim
            {
                Id = edit.Id,
                Idcabinet = edit.Idcabinet,
                IdcalimType = edit.IdcalimType,
                IdclaimDevices = edit.IdclaimDevices,
                NameOfMatherial = edit.NameOfMatherial,
                AmountOfMatherial = edit.AmountOfMatherial,
                Cost = edit.Cost
            };

            this.mainViewModel = mainViewModel;
            Save = new ViewCommand(() =>
            {
                if (SelectedDevice == null || SelectedCabinet == null  || SelectedTypeClaim == null)
                {
                    MessageBox.Show("где типок???");
                    return;
                }
                Claims.IdcalimType = SelectedTypeClaim.Id;
                Claims.Idcabinet = SelectedCabinet.Id;
                Claims.IdclaimDevices = SelectedDevice.Id;
                if (Claims.Id != 0)
                    DEContext.GetInstance().Entry<Claim>(original).
                        CurrentValues.SetValues(Claims);
                else
                    DEContext.GetInstance().Claims.Add(Claims);
                DEContext.GetInstance().SaveChanges();

            });
        }
    }
}
