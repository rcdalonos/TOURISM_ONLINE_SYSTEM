using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using STANDARDS_AND_SERVICES_DB_SYSTEM.Models;

namespace STANDARDS_AND_SERVICES_DB_SYSTEM.Controllers
{
    public class businessprofilesController : Controller
    {
        private readonly StandardsDBContext _context;

        public businessprofilesController(StandardsDBContext context)
        {
            _context = context;
        }

        // GET: businessprofiles
        public async Task<IActionResult> Index()
        {
            return View(await _context.businessprofiles.ToListAsync());
        }

        // GET: businessprofiles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var businessprofile = await _context.businessprofiles
                .FirstOrDefaultAsync(m => m.id == id);
            if (businessprofile == null)
            {
                return NotFound();
            }

            return View(businessprofile);
        }

        // GET: businessprofiles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: businessprofiles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,businessname,businessaddress,telephoneno,mobileno,emailaddress,businessowner,owneraddress,typeid,classificationid")] businessprofile businessprofile)
        {
            if (ModelState.IsValid)
            {
                _context.Add(businessprofile);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(businessprofile);
        }

        // GET: businessprofiles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var businessprofile = await _context.businessprofiles.FindAsync(id);
            if (businessprofile == null)
            {
                return NotFound();
            }
            return View(businessprofile);
        }

        // POST: businessprofiles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,businessname,businessaddress,telephoneno,mobileno,emailaddress,businessowner,owneraddress,typeid,classificationid")] businessprofile businessprofile)
        {
            if (id != businessprofile.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(businessprofile);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!businessprofileExists(businessprofile.id))
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
            return View(businessprofile);
        }

        // GET: businessprofiles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var businessprofile = await _context.businessprofiles
                .FirstOrDefaultAsync(m => m.id == id);
            if (businessprofile == null)
            {
                return NotFound();
            }

            return View(businessprofile);
        }

        // POST: businessprofiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var businessprofile = await _context.businessprofiles.FindAsync(id);
            if (businessprofile != null)
            {
                _context.businessprofiles.Remove(businessprofile);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool businessprofileExists(int id)
        {
            return _context.businessprofiles.Any(e => e.id == id);
        }
    }
}
