using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Web.ViewModels;

namespace Web.Interfaces
{
    public interface IHomeIndexViewModelService
    {
        Task<HomeIndexViewModel> GetHomeIndexViewModel();
        Task<List<SelectListItem>> GetCategories();
        Task<List<SelectListItem>> GetBrands();
    }
}
