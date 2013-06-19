using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GalaxySports.Domain.Entities;

namespace GalaxySports.WebUI.Models
{
    public class SearchResultsViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string TextForSearch { get; set; }
    }
}