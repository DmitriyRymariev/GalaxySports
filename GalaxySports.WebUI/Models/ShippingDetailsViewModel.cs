using GalaxySports.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GalaxySports.WebUI.Models
{
    public class ShippingDetailsViewModel
    {
        public ShippingDetails ShippingDetails { get; set; }
        public Cart Cart { get; set; }
    }
}