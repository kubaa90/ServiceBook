using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceBook.Models.ViewModels
{
    public class FaultViewModel
    {
        public Fault Fault { get; set; }
        public IEnumerable<SelectListItem> VehicleList { get; set; }
    }
}
