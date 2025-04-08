using System;
using System.Linq;
using System.Web.Mvc;
using Car_insurance.Models;


namespace CarInsurance.Controllers
{
    public class InsureeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Insuree/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Insuree/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,EmailAddress,DateOfBirth,CarYear,CarMake,CarModel,SpeedingTickets,HasDui,CoverageType")] Insuree insuree)
        {
            if (ModelState.IsValid)
            {
                // Start with base quote
                decimal quote = 50m;

                // Calculate age
                var today = DateTime.Today;
                var age = today.Year - insuree.DateOfBirth.Year;
                if (insuree.DateOfBirth > today.AddYears(-age)) age--;

                // Age-based additions
                if (age <= 18)
                    quote += 100;
                else if (age >= 19 && age <= 25)
                    quote += 50;
                else
                    quote += 25;

                // Car year
                if (insuree.CarYear < 2000)
                    quote += 25;
                if (insuree.CarYear > 2015)
                    quote += 25;

                // Car make and model
                if (insuree.CarMake?.ToLower() == "porsche")
                {
                    quote += 25;
                    if (insuree.CarModel?.ToLower() == "911 carrera")
                        quote += 25;
                }

                // Speeding tickets
                quote += insuree.SpeedingTickets * 10;

                // DUI
                if (insuree.HasDui)
                    quote += quote * 0.25m;

                // Full coverage
                if (insuree.CoverageType)
                    quote += quote * 0.50m;

                // Assign final quote to model
                insuree.Quote = quote;

               
                return RedirectToAction("Index");
            }

            return View(insuree);
        }

        // GET: Insuree/Admin
        public ActionResult Admin()
        {
            var insurees = db.Insurees. ToList();
            return View(insurees);
        }
  
public ActionResult Admin()
{
    var insurees = db.Insurees.ToList();
    return View(insurees);



