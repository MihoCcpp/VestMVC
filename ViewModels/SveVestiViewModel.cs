using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prodyna.ViewModels
{
    public class SveVestiViewModel
    {
        public List<VestiViewModel> SveVesti { get; set; }

        public SveVestiViewModel()
        {
            SveVesti = new List<VestiViewModel>();
        }
    }
}