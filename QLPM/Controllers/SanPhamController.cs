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
    public class SanPhamController : Controller
    {
        private readonly QLPhanMemContext _context;

        public SanPhamController(QLPhanMemContext context)
        {
            _context = context;
        }

        // GET: SanPham
        public async Task<IActionResult> Index()
        {
            var qLPhanMemContext = _context.SanPhams.Include(s => s.BaoTri).Include(s => s.DanhMuc).Include(s => s.HuongDan);
            return View(await qLPhanMemContext.ToListAsync());
        }

        // GET: SanPham/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sanPham = await _context.SanPhams
                .Include(s => s.BaoTri)
                .Include(s => s.DanhMuc)
                .Include(s => s.HuongDan)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sanPham == null)
            {
                return NotFound();
            }

            return View(sanPham);
        }

        // GET: SanPham/Create
        public IActionResult Create()
        {
            ViewData["BaoTriId"] = new SelectList(_context.BaoTris, "Id", "Id");
            ViewData["DanhMucId"] = new SelectList(_context.DanhMucs, "Id", "TenDanhMuc");
            ViewData["HuongDanId"] = new SelectList(_context.HuongDans, "Id", "Id");
            return View();
        }

        // POST: SanPham/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DanhMucId,TenPhanMem,NhaPhatHanh,MoTa,HuongDanId,BaoTriId")] SanPham sanPham)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sanPham);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BaoTriId"] = new SelectList(_context.BaoTris, "Id", "Id", sanPham.BaoTriId);
            ViewData["DanhMucId"] = new SelectList(_context.DanhMucs, "Id", "TenDanhMuc", sanPham.DanhMucId);
            ViewData["HuongDanId"] = new SelectList(_context.HuongDans, "Id", "Id", sanPham.HuongDanId);
            return View(sanPham);
        }

        // GET: SanPham/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sanPham = await _context.SanPhams.FindAsync(id);
            if (sanPham == null)
            {
                return NotFound();
            }
            ViewData["BaoTriId"] = new SelectList(_context.BaoTris, "Id", "Id", sanPham.BaoTriId);
            ViewData["DanhMucId"] = new SelectList(_context.DanhMucs, "Id", "TenDanhMuc", sanPham.DanhMucId);
            ViewData["HuongDanId"] = new SelectList(_context.HuongDans, "Id", "Id", sanPham.HuongDanId);
            return View(sanPham);
        }

        // POST: SanPham/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DanhMucId,TenPhanMem,NhaPhatHanh,MoTa,HuongDanId,BaoTriId")] SanPham sanPham)
        {
            if (id != sanPham.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sanPham);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SanPhamExists(sanPham.Id))
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
            ViewData["BaoTriId"] = new SelectList(_context.BaoTris, "Id", "Id", sanPham.BaoTriId);
            ViewData["DanhMucId"] = new SelectList(_context.DanhMucs, "Id", "TenDanhMuc", sanPham.DanhMucId);
            ViewData["HuongDanId"] = new SelectList(_context.HuongDans, "Id", "Id", sanPham.HuongDanId);
            return View(sanPham);
        }

        // GET: SanPham/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sanPham = await _context.SanPhams
                .Include(s => s.BaoTri)
                .Include(s => s.DanhMuc)
                .Include(s => s.HuongDan)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sanPham == null)
            {
                return NotFound();
            }

            return View(sanPham);
        }

        // POST: SanPham/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sanPham = await _context.SanPhams.FindAsync(id);
            _context.SanPhams.Remove(sanPham);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SanPhamExists(int id)
        {
            return _context.SanPhams.Any(e => e.Id == id);
        }
    }
}
