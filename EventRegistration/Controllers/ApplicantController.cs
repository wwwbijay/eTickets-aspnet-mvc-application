using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EventRegistration.Data;
using EventRegistration.Models;
using System.Reflection.Metadata;

namespace EventRegistration.Controllers
{
    public class ApplicantController : Controller
    {
        private readonly AppDbContext _context;
        private readonly Int32 order_id_constant = 1111111;

        public ApplicantController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Applicants
        public IActionResult Index()
        {
            
            var data = new string[7] {
                "Province 1", 
                "Madhesh Province", 
                "Bagmati Pradesh", 
                "Gandaki Province", 
                "Lumbini Province", 
                "Karnali Province", 
                "Sudurpashchim Province" 
            };

            ViewBag.Province = new List<string>(data);
            return View();
        }
        
        // POST: Applicants/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index([Bind("Id", "FullName,Phone,Email,Address,City,Province,PerformanceType,ParticipantName,Gender,Age,GroupName,NoOfMembers,AgeGroupRange,GroupType,Details,OrderId,TransactionId,PaymentStatus")] Applicant applicant)
        {
            if (ModelState.IsValid)
            {
                applicant.PaymentStatus = Data.Enums.PaymentStatus.Pending;
                _context.Add(applicant);
                await _context.SaveChangesAsync();
                var id = applicant.Id;
                applicant.OrderId = id + 1111111;
                _context.Update(applicant);
                await _context.SaveChangesAsync();

                TempData["ID"] = applicant.Id;
                TempData["ORDER_ID"] = applicant.OrderId;

                return RedirectToAction(nameof(Checkout));
            }
            var data = new string[7] {
                "Province 1",
                "Madhesh Province",
                "Bagmati Pradesh",
                "Gandaki Province",
                "Lumbini Province",
                "Karnali Province",
                "Sudurpashchim Province"
            };

            ViewBag.Province = new List<string>(data);

            return View(applicant);
        }

        // GET: Applicants/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicant = await _context.Applicants.FindAsync(id);
            if (applicant == null)
            {
                return NotFound();
            }
            return View(applicant);
        }

        // POST: Applicants/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FullName,Phone,Email,Address,City,Province,PerformanceType,ParticipantName,Gender,Age,GroupName,NoOfMembers,AgeGroupRange,GroupType,Details")] Applicant applicant)
        {
            if (id != applicant.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(applicant);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApplicantExists(applicant.Id))
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
            return View(applicant);
        }

        // GET: Applicants/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicant = await _context.Applicants
                .FirstOrDefaultAsync(m => m.Id == id);
            if (applicant == null)
            {
                return NotFound();
            }

            return View(applicant);
        }

        // POST: Applicants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var applicant = await _context.Applicants.FindAsync(id);
            _context.Applicants.Remove(applicant);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ApplicantExists(int id)
        {
            return _context.Applicants.Any(e => e.Id == id);
        }

        public IActionResult Checkout()
        {  
            ViewBag.applicant_Id = TempData["ID"];
            ViewBag.applicant_orderId = TempData["ORDER_ID"];
            return View();
        }
    }
}
