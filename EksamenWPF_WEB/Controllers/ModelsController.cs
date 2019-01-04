using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EksamenWPF_WEB.Models;
using Microsoft.AspNetCore.Identity;

namespace EksamenWPF_WEB.Controllers
{
    public class ModelsController : Controller
    {
        private readonly EksamenWPF_WEBContext _context;

        public ModelsController(EksamenWPF_WEBContext context)
        {
            _context = context;
        }

        // GET: Models
        public async Task<IActionResult> Index()
        {
            return View(await _context.Models.ToListAsync());
        }

        public async Task<IActionResult> UpComing()
        {
            var emailOfLoggedInUser = User.Identity.Name;    // we first find email
            var phoneNumberOfLoggedInUser = _context.Users.Where(users => users.Email == emailOfLoggedInUser)
                .Select(p => p.TelephoneNumber).FirstOrDefault();   // then our phonenumber

            string fetchedModelName = _context.Models.Where(p => p.TelephoneNumber == phoneNumberOfLoggedInUser)
                .Select(t => t.Name).FirstOrDefault();  //Then we via matching phone numbers from our user and model, we fetch the specifikname

            List<string> compayNames = _context.Assignments.Where(p => p.ModelName == fetchedModelName)
                .Select(t => t.Customer).ToList();

            List<Job> jobs = new List<Job>();

            foreach (var item in compayNames)
            {
                var jobHolder = _context.Jobs.Where(p => p.Customer == item).FirstOrDefault();
                if((DateTime.Parse(jobHolder.StartDate) > DateTime.Today))
                {
                    jobs.Add(jobHolder);
                }
                
            }

            return View(jobs);

        }



        public async Task<IActionResult> previous()
        {
            var emailOfLoggedInUser = User.Identity.Name;    // we first find email
            var phoneNumberOfLoggedInUser = _context.Users.Where(users => users.Email == emailOfLoggedInUser)
                .Select(p => p.TelephoneNumber).FirstOrDefault();   // then our phonenumber

            string fetchedModelName = _context.Models.Where(p => p.TelephoneNumber == phoneNumberOfLoggedInUser)
                .Select(t => t.Name).FirstOrDefault();  //Then we via matching phone numbers from our user and model, we fetch the specifikname

            List<string> compayNames = _context.Assignments.Where(p => p.ModelName == fetchedModelName)
                .Select(t => t.Customer).ToList();

            List<Job> jobs = new List<Job>();

            foreach (var item in compayNames)
            {
                var jobHolder = _context.Jobs.Where(p => p.Customer == item).FirstOrDefault();
                if ((DateTime.Parse(jobHolder.StartDate) < DateTime.Today))
                {
                    jobs.Add(jobHolder);
                }

            }

            return View(jobs);

        }

        public async Task<IActionResult> expenses()
        {
            var emailOfLoggedInUser = User.Identity.Name;    // we first find email
            var phoneNumberOfLoggedInUser = _context.Users.Where(users => users.Email == emailOfLoggedInUser)
                .Select(p => p.TelephoneNumber).FirstOrDefault();   // then our phonenumber

            string fetchedModelName = _context.Models.Where(p => p.TelephoneNumber == phoneNumberOfLoggedInUser)
                .Select(t => t.Name).FirstOrDefault();  //Then we via matching phone numbers from our user and model, we fetch the specifikname

            List<string> compayNames = _context.Assignments.Where(p => p.ModelName == fetchedModelName)
                .Select(t => t.Customer).ToList();

            List<Job> jobs = new List<Job>();

            foreach (var item in compayNames)
            {
                var jobHolder = _context.Jobs.Where(p => p.Customer == item).FirstOrDefault();
                if ((DateTime.Parse(jobHolder.StartDate) < DateTime.Today))
                {
                    jobs.Add(jobHolder);
                }

            }

            return View(jobs);

        }



        // GET: Models/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var model = await _context.Models
                .FirstOrDefaultAsync(m => m.ModelId == id);
            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        // GET: Models/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Models/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ModelId,Name,TelephoneNumber,Address,Height,Weight,HairColor,Comments")] Model model)
        {
            if (ModelState.IsValid)
            {
                _context.Add(model);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: Models/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var model = await _context.Models.FindAsync(id);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        // POST: Models/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ModelId,Name,TelephoneNumber,Address,Height,Weight,HairColor,Comments")] Model model)
        {
            if (id != model.ModelId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(model);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ModelExists(model.ModelId))
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
            return View(model);
        }

        // GET: Models/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var model = await _context.Models
                .FirstOrDefaultAsync(m => m.ModelId == id);
            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        // POST: Models/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var model = await _context.Models.FindAsync(id);
            _context.Models.Remove(model);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ModelExists(int id)
        {
            return _context.Models.Any(e => e.ModelId == id);
        }
    }
}
