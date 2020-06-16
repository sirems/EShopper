using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Web.ViewModels
{
    public class HomeIndexViewModel
    {
        public List<ProductViewModel> Products { get; set; }
        public List<SelectListItem> Categories { get; set; }
        public List<SelectListItem> Brands { get; set; }
        public int? CategoryId { get; set; }
        public int? BrandId { get; set; }   

        public PaginationInfoViewModel PaginationInfo { get; set; }    
    }   
}
    