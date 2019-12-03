using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCFlowerShop.Models;

namespace MVCFlowerShop.Views.Flowers
{
    public class FlowersController : Controller
    {
        private readonly MVCFlowerShopContext _context;

        public FlowersController(MVCFlowerShopContext context)
        {
            _context = context;
        }

        public IList<Flower> Flower { get; set; }

        // GET: Flowers //modify here - Index() method
        public async Task<IActionResult> Index(string SearchString, string FlowerType)
        {
            //to select all the flower from the table
            var flowers = from m in _context.Flower
                          select m;

            //this used to add the type inside the dropdownlist in index page
            IQueryable<string> TypeQuery = from m in _context.Flower
                                           orderby m.Type
                                           select m.Type;
            IEnumerable<SelectListItem> items =
                new SelectList(await TypeQuery.Distinct().ToListAsync());

            ViewBag.FlowerType = items;

            //filter the listing from the flower list
            if(!String.IsNullOrEmpty(SearchString)) // if got any search word
            {
                flowers = flowers.Where(s => s.FlowerName.Contains(SearchString));
            }
            if (!String.IsNullOrEmpty(FlowerType)) // if got any search word
            {
                flowers = flowers.Where(s => s.Type == FlowerType);
            }
            //then final send the flower list to the index page
            return View(await flowers.ToListAsync());
        }

        // GET: Flowers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flower = await _context.Flower
                .FirstOrDefaultAsync(m => m.ID == id);
            if (flower == null)
            {
                return NotFound();
            }

            return View(flower);
        }

        // GET: Flowers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Flowers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,FlowerName,FlowerProducedDate,Type,Price,Rating")] Flower flower)
        {
            if (ModelState.IsValid)
            {
                _context.Add(flower);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(flower);
        }

        // GET: Flowers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flower = await _context.Flower.FindAsync(id);
            if (flower == null)
            {
                return NotFound();
            }
            return View(flower);
        }

        // POST: Flowers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,[Bind("ID,FlowerName,FlowerProducedDate,Type,Price,Rating")] Flower flower)
        {
            if (id != flower.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(flower);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FlowerExists(flower.ID))
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
            return View(flower);
        }

        // GET: Flowers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flower = await _context.Flower
                .FirstOrDefaultAsync(m => m.ID == id);
            if (flower == null)
            {
                return NotFound();
            }

            return View(flower);
        }

        // POST: Flowers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var flower = await _context.Flower.FindAsync(id);
            _context.Flower.Remove(flower);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FlowerExists(int id)
        {
            return _context.Flower.Any(e => e.ID == id);
        }
    }
}
