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
        //new EfRepository(dbcontext)


        public TestController(IAsyncRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }   
        public async Task<IActionResult> Index()
        {
            return View(await _categoryRepository.ListAllAsync());
        }
    }
}
