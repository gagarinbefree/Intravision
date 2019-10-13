using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Intravision.DataAccess;
using Intravision.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Intravision.Controllers
{
    public class AdminController : Controller
    {
        private readonly IntravisionDbContext _context;

        public AdminController(IntravisionDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            AdminViewModel model = new AdminViewModel
            {
                Coins = await _context.Coins.ToListAsync(),
                Products = await _context.Products.ToListAsync()
            };

            return View(model);           
        }
    }
}