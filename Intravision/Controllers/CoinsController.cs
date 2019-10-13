using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Intravision.DataAccess;
using Intravision.DataAccess.Dto;
using Intravision.Models;

namespace Intravision.Controllers
{
    public class CoinsController : Controller
    {
        private readonly IntravisionDbContext _context;

        public CoinsController(IntravisionDbContext context)
        {
            _context = context;
        }

        // GET: Coins
        public async Task<IActionResult> Index()
        {
            AdminViewModel model = new AdminViewModel
            {
                Coins = await _context.Coins.ToListAsync(),
                Products = await _context.Products.ToListAsync()
            };

            return View(await _context.Coins.ToListAsync());
        }

        // GET: Coins/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coin = await _context.Coins
                .FirstOrDefaultAsync(m => m.Id == id);
            if (coin == null)
            {
                return NotFound();
            }

            return View(coin);
        }

        // GET: Coins/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Coins/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ParValue,IsAvailable")] Coin coin)
        {
            if (ModelState.IsValid)
            {
                _context.Add(coin);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(coin);
        }

        // GET: Coins/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coin = await _context.Coins.FindAsync(id);
            if (coin == null)
            {
                return NotFound();
            }
            return View(coin);
        }

        // POST: Coins/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ParValue,IsAvailable")] Coin coin)
        {
            if (id != coin.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(coin);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CoinExists(coin.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(coin);
        }

        // GET: Coins/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coin = await _context.Coins
                .FirstOrDefaultAsync(m => m.Id == id);
            if (coin == null)
            {
                return NotFound();
            }

            return View(coin);
        }

        // POST: Coins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var coin = await _context.Coins.FindAsync(id);
            _context.Coins.Remove(coin);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CoinExists(int id)
        {
            return _context.Coins.Any(e => e.Id == id);
        }
    }
}
