using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class TestController : Controller
    {
        private readonly IAsyncRepository<Category> _categoryRepository;

        private readonly ShopContext _db;
        //new EfRepository(dbcontext)

            
        public TestController(IAsyncRepository<Category> categoryRepository, ShopContext db)
        {
            _categoryRepository = categoryRepository;
            _db = db;
        }   
        public async Task<IActionResult> Index()
        {
            // Expression<Func<Product,bool>> predicate  seçim ölçütü
            var urunler = _db.Products.Where(x => x.CategoryId == 3);
            return View(await _categoryRepository.ListAllAsync());
        }
    }
}
