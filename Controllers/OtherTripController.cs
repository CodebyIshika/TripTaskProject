using AutoMapper;
using IPDAL;
using ITBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TripTaskEF.Models;

namespace TripTaskEF.Controllers
{
    public class OtherTripController : Controller
    {
        // GET: OtherTrip
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetTrip()
        {
            TripService ts = new TripService();
            var trips = ts.GetTrips();

            List<TripVM> tripVMs = new List<TripVM>();

            // Mapper.Initialize(x => x.CreateMap<Trip, TripVM>());
            tripVMs = Mapper.Map<List<Trip>, List<TripVM>>(trips);

            // Mapper.Map(trips, tripVMs);

            return Json(tripVMs, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetTripById(int id)
        {
            TripService ts = new TripService();
            var trip = ts.GetTrip(id);
            return Json(trip, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public JsonResult AddTrip(Trip trip)
        {
            TripService ts = new TripService();
            var tripAdded = ts.AddTrip(trip);
            return Json(tripAdded, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult UpdateTrip(Trip trip)
        {
            TripService ts = new TripService();
            var tripUpdated = ts.UpdateTrip(trip);
            return Json(tripUpdated, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult DeleteTrip(int id)
        {
            TripService ts = new TripService();
            if(ts.DeleteTrip(id))
            {
                return Json(JsonRequestBehavior.AllowGet);
            }
            return null;
        }
    }
}