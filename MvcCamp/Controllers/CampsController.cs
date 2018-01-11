using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcCamp.Models;


//Code below is based on "Create a web app with ASP.NET Core MVC using Visual Studio for Mac", www.microsoft.com, https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-mvc-app-mac/
namespace MvcCamp.Controllers
{
    public class CampsController : Controller
    {
        private readonly MvcCampContext _context;

        public CampsController(MvcCampContext context)
        {
            _context = context;
        }

        // Requires using Microsoft.AspNetCore.Mvc.Rendering;
        public async Task<IActionResult> Index(string campBeltGrade, string searchString)
        {
            // Use LINQ to get list of genres.
            IQueryable<string> genreQuery = from m in _context.Camp
                                                              orderby m.BeltGrade
                                                              select m.BeltGrade;

            var camps = from m in _context.Camp
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                camps = camps.Where(s => s.FullName.Contains(searchString));
            }

            if (!String.IsNullOrEmpty(campBeltGrade))
            {
                camps = camps.Where(x => x.BeltGrade == campBeltGrade);
            }

            var campBeltGradeVM = new CampBeltGradeModel();
            campBeltGradeVM.beltGrades = new SelectList(await genreQuery.Distinct().ToListAsync());
            campBeltGradeVM.camps = await camps.ToListAsync();

            return View(campBeltGradeVM);
        }

     
        // GET: Camps/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var camp = await _context.Camp
                .SingleOrDefaultAsync(m => m.ID == id);
            if (camp == null)
            {
                return NotFound();
            }

            return View(camp);
        }

        // GET: Camps/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Camps/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,FullName,DateRegistered,BeltGrade,ClubLocation,DepositPutDown")] Camp camp)
        {
            if (ModelState.IsValid)
            {
                _context.Add(camp);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(camp);
        }

        // GET: Camps/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var camp = await _context.Camp.SingleOrDefaultAsync(m => m.ID == id);
            if (camp == null)
            {
                return NotFound();
            }
            return View(camp);
        }

        // POST: Camps/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,FullName,DateRegistered,BeltGrade,ClubLocation,DepositPutDown")] Camp camp)
        {
            if (id != camp.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(camp);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CampExists(camp.ID))
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
            return View(camp);
        }

        // GET: Camps/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var camp = await _context.Camp
                .SingleOrDefaultAsync(m => m.ID == id);
            if (camp == null)
            {
                return NotFound();
            }

            return View(camp);
        }

        // POST: Camps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var camp = await _context.Camp.SingleOrDefaultAsync(m => m.ID == id);
            _context.Camp.Remove(camp);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CampExists(int id)
        {
            return _context.Camp.Any(e => e.ID == id);
        }
    }
}
