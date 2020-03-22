using CarInsAppAssmtP_340.Models;
using CarInsAppAssmtP_340.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarInsAppAssmtP_340.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            using (CarInsuranceEntities db = new CarInsuranceEntities())
            {
                var drivers = db.Drivers.ToList();
                var driverVms = new List<DriverVm>();
                foreach (var driver in drivers)
                {
                    var driverVm = new DriverVm();
                    driverVm.Id = driver.Id;
                    driverVm.FirstName = driver.FirstName;
                    driverVm.LastName = driver.LastName;
                    driverVm.EmailAddress = driver.EmailAddress;
                    driverVm.Quote = driver.Quote;
                    driverVms.Add(driverVm);
                }
                return View(driverVms);
            }

        }
    }
}