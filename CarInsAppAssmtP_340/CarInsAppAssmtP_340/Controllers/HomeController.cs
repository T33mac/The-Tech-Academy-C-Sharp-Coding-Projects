using CarInsAppAssmtP_340.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarInsAppAssmtP_340.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Driver(string firstName, string lastName, string emailAddress,
                                     string dateOfBirth, string yearOfCar, string makeOfCar, string modelOfCar, 
                                    string dui, string speedingTickets, string coverage)
        {
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) ||
                string.IsNullOrEmpty(emailAddress) || string.IsNullOrEmpty(dateOfBirth) ||
                string.IsNullOrEmpty(yearOfCar) || string.IsNullOrEmpty(makeOfCar) ||
                string.IsNullOrEmpty(modelOfCar) || string.IsNullOrEmpty(dui) ||
                string.IsNullOrEmpty(speedingTickets) || string.IsNullOrEmpty(coverage))
            {
                return View("~/Views/Shared/Error.cshtml");
            }
            else
            {
                int rate = 50;

                int yearItIs = DateTime.Now.Year;
                int dob = Convert.ToDateTime(dateOfBirth).Year;
                int age = yearItIs - dob;

                bool isUnder18 = age < 18;
                int rate18 = (isUnder18 ? 100 : 0);
                bool isUnder25 = age < 25 && age > 18;
                int rate25 = (isUnder25 ? 25 : 0);
                bool isOver100 = age >= 100;
                int rate100 = (isOver100 ? 25 : 0);

                bool carIsOld = Convert.ToInt32(yearOfCar) < 2000;
                int rateOldCar = (carIsOld ? 25 : 0);
                bool carIsNew = Convert.ToInt32(yearOfCar) > 2015;
                int rateNewCar = (carIsNew ? 25 : 0);
                bool carIsPorsche = makeOfCar.ToLower() == "porsche";
                int porscheRate = (carIsPorsche ? 25 : 0);
                bool carIsCarrera = modelOfCar.ToLower().Contains("carrera");
                int carreraRate = (carIsPorsche && carIsCarrera ? 25 : 0);
                int tickets = Convert.ToInt32(speedingTickets);
                int tickRate = tickets * 10;

                int addedRate = rate + rate18 + rate25 + rate100
                                + rateOldCar + rateNewCar + porscheRate
                                + carreraRate + tickRate;

                int duiCalc = addedRate / 4;
                bool hasDui = dui.ToLower() == "yes";
                int duiRate = (hasDui ? duiCalc : 0);

                int adjustedDui = addedRate + duiRate;

                int coverageCalc = adjustedDui / 2;
                bool fullCov = coverage.ToLower() == "full";
                int fullRate = (fullCov ? coverageCalc : 0);

                int newRate = adjustedDui + fullRate;

                ViewBag.Message = newRate;

                using (CarInsuranceEntities db = new CarInsuranceEntities())
                {
                    var quote = new Driver();
                    quote.FirstName = firstName;
                    quote.LastName = lastName;
                    quote.EmailAddress = emailAddress;
                    quote.DateOfBirth = Convert.ToDateTime(dateOfBirth);
                    quote.YearOfCar = yearOfCar;
                    quote.MakeOfCar = makeOfCar;
                    quote.ModelOfCar = modelOfCar;
                    quote.Dui = dui;
                    quote.SpeedingTickets = speedingTickets;
                    quote.Coverage = coverage;
                    quote.Quote = newRate;

                    db.Drivers.Add(quote);
                    db.SaveChanges();
                }

                return View();
            }
        }

        public ActionResult Admin()
        {
            return View();
        }
    }
}