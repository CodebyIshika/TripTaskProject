using ITBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TripTaskEF.Controllers
{
    public class TripController : Controller
    {
        // GET: Trip
        public ActionResult Index()
        {
            TripService tripService = new TripService();
            var trips = tripService.GetTrips();
            return View(trips);
        }
    }
}