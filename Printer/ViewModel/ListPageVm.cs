using Microsoft.EntityFrameworkCore;
using Printer.DB;
using Printer.Models;
using Printer.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Printer.ViewModel
{
    public class ListPageVm : BaseViewModel
    {
        private MainViewModel mainViewModel;
       
        public List<Cabinet> cabinets;
        private List<ClaimType> claimTypes;
        public List<Claim> claims;
        public List<Claim> Claims
        {
            get => claims;
            set
            {
                claims = value;
                SignalChanged();
            }
        }

        public List<Cabinet> Cabinets
        {
            get => cabinets;
            set
            {
                cabinets = value;
                SignalChanged();
            }
        }

        public List<ClaimType> ClaimTypes
        {
            get => claimTypes;
            set
            {
                claimTypes = value;
                SignalChanged();
            }
        }

        public ListPageVm(MainViewModel mainViewModel)
        {
            Claims = DEContext.GetInstance().Claims.Include(s=>s.IdcabinetNavigation).Include(s=>s.IdcalimTypeNavigation).ToList();
            //Cabinets = DEContext.GetInstance().Cabinets.ToList();
            //ClaimTypes = DEContext.GetInstance().ClaimTypes.ToList();            
            //this.mainViewModel = mainViewModel;
        }
    }
}
