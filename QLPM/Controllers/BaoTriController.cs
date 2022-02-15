using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QLPM.Data;
using QLPM.Models;

namespace QLPM.Controllers
{
    public class BaoTriController : Controller
    {
        private readonly QLPhanMemContext _context;

        public BaoTriController(QLPhanMemContext context)
        {
            _context = context;
        }

        // GET: BaoTri
        public async Task<IActionResult> Index()
        {
            return View(await _context.BaoTris.ToListAsync());
        }

        // GET: BaoTri/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var baoTri = await _context.BaoTris
                .FirstOrDefaultAsync(m => m.Id == id);
            if (baoTri == null)
            {
                return NotFound();
            }

            return View(baoTri);
        }

        // GET: BaoTri/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BaoTri/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ThoiGianBt")] BaoTri baoTri)
        {
            if (ModelState.IsValid)
            {
                _context.Add(baoTri);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(baoTri);
        }

        // GET: BaoTri/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var baoTri = await _context.BaoTris.FindAsync(id);
            if (baoTri == null)
            {
                return NotFound();
            }
            return View(baoTri);
        }

        // POST: BaoTri/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ThoiGianBt")] BaoTri baoTri)
        {
            if (id != baoTri.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(baoTri);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BaoTriExists(baoTri.Id))
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
            return View(baoTri);
        }

        // GET: BaoTri/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var baoTri = await _context.BaoTris
                .FirstOrDefaultAsync(m => m.Id == id);
            if (baoTri == null)
            {
                return NotFound();
            }

            return View(baoTri);
        }

        // POST: BaoTri/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var baoTri = await _context.BaoTris.FindAsync(id);
            _context.BaoTris.Remove(baoTri);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BaoTriExists(int id)
        {
            return _context.BaoTris.Any(e => e.Id == id);
        }
    }
}
