using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using covid_19.Models;
using Microsoft.AspNetCore.Authorization;

namespace covid_19.Controllers
{
    public class PeopleWithCovidsController : Controller
    {
        private readonly IdentityCovidContext _context;

        public PeopleWithCovidsController(IdentityCovidContext context)
        {
            _context = context;
        }

        // GET: PeopleWithCovids
        public async Task<IActionResult> Index(string searchString)
        {
            var people = from s in _context.PeopleWithCovids
                         select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                people = people.Where(p => p.Country.Contains(searchString));
            }
            return View(await people.ToListAsync());
        }

        // GET: PeopleWithCovids/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var peopleWithCovid = await _context.PeopleWithCovids
                .FirstOrDefaultAsync(m => m.Id == id);
            if (peopleWithCovid == null)
            {
                return NotFound();
            }

            return View(peopleWithCovid);
        }
        // GET: PeopleWithCovids/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PeopleWithCovids/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Country,TotalCases,NewCases,TotalDeaths,TotalRecovered,ActiveCases,SeriousCritical")] PeopleWithCovid peopleWithCovid)
        {
            peopleWithCovid.Id = Guid.NewGuid();
            _context.Add(peopleWithCovid);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        // GET: PeopleWithCovids/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var peopleWithCovid = await _context.PeopleWithCovids.FindAsync(id);
            if (peopleWithCovid == null)
            {
                return NotFound();
            }
            return View(peopleWithCovid);
        }

        // POST: PeopleWithCovids/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Country,TotalCases,NewCases,TotalDeaths,TotalRecovered,ActiveCases,SeriousCritical")] PeopleWithCovid peopleWithCovid)
        {
            if (id != peopleWithCovid.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(peopleWithCovid);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PeopleWithCovidExists(peopleWithCovid.Id))
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
            return View(peopleWithCovid);
        }
        // GET: PeopleWithCovids/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var peopleWithCovid = await _context.PeopleWithCovids
                .FirstOrDefaultAsync(m => m.Id == id);
            if (peopleWithCovid == null)
            {
                return NotFound();
            }

            return View(peopleWithCovid);
        }
        // POST: PeopleWithCovids/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var peopleWithCovid = await _context.PeopleWithCovids.FindAsync(id);
            _context.PeopleWithCovids.Remove(peopleWithCovid);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PeopleWithCovidExists(Guid id)
        {
            return _context.PeopleWithCovids.Any(e => e.Id == id);
        }
    }
}
