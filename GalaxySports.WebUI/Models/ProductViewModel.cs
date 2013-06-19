using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GalaxySports.Domain.Entities;

namespace GalaxySports.WebUI.Models
{
    public class ProductViewModel
    {
        public Product Product { get; set; }
        public string Category { get; set; }
        public List<CommentViewModel> Comments { get; set; }
    }
}