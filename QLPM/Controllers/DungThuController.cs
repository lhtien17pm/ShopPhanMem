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
    public class DungThuController : Controller
    {
        private readonly QLPhanMemContext _context;

        public DungThuController(QLPhanMemContext context)
        {
            _context = context;
        }

        // GET: DungThu
        public async Task<IActionResult> Index()
        {
            var qLPhanMemContext = _context.DungThus.Include(d => d.SanPham);
            return View(await qLPhanMemContext.ToListAsync());
        }

        // GET: DungThu/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dungThu = await _context.DungThus
                .Include(d => d.SanPham)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dungThu == null)
            {
                return NotFound();
            }

            return View(dungThu);
        }

        // GET: DungThu/Create
        public IActionResult Create()
        {
            ViewData["SanPhamId"] = new SelectList(_context.SanPhams, "Id", "Id");
            return View();
        }

        // POST: DungThu/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SanPhamId,ThoiGianDungThu")] DungThu dungThu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dungThu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SanPhamId"] = new SelectList(_context.SanPhams, "Id", "Id", dungThu.SanPhamId);
            return View(dungThu);
        }

        // GET: DungThu/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dungThu = await _context.DungThus.FindAsync(id);
            if (dungThu == null)
            {
                return NotFound();
            }
            ViewData["SanPhamId"] = new SelectList(_context.SanPhams, "Id", "Id", dungThu.SanPhamId);
            return View(dungThu);
        }

        // POST: DungThu/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SanPhamId,ThoiGianDungThu")] DungThu dungThu)
        {
            if (id != dungThu.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dungThu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DungThuExists(dungThu.Id))
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
            ViewData["SanPhamId"] = new SelectList(_context.SanPhams, "Id", "Id", dungThu.SanPhamId);
            return View(dungThu);
        }

        // GET: DungThu/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dungThu = await _context.DungThus
                .Include(d => d.SanPham)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dungThu == null)
            {
                return NotFound();
            }

            return View(dungThu);
        }

        // POST: DungThu/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dungThu = await _context.DungThus.FindAsync(id);
            _context.DungThus.Remove(dungThu);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DungThuExists(int id)
        {
            return _context.DungThus.Any(e => e.Id == id);
        }
    }
}
