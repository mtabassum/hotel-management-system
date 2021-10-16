using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HotelEntity;
using HotelService;

namespace HotelMSystem.Controllers
{
    public class AdminController : BaseController
    {
        IhotelS hs = servicefactory.gethotelService();
        IbookingS ibs = servicefactory.getbookingService();
        
        public ActionResult Index(string search)
        {
            return View(hs.Getall(search));
        }

        [HttpGet]
        public ActionResult Create() {

            return View();
        }

        [HttpPost]
        public ActionResult Create(Hotelinfo H)
        {
            if (ModelState.IsValid)
            {
                if (hs.check(H))
                {
                    ViewData["E"] = null;

                        hs.create(H);
                        return RedirectToAction("Index");

                }
                else
                {
                    ViewData["E"] = "This hotel is already exist";
                    return View(H);
                }
            }
            else {
                return View(H);
            }

        }
        
        public ActionResult Booking(string hanme, string bDate)
        {
            string s = null;
            IEnumerable<Hotelinfo> H = hs.Getall(s);
            var Hotellist =H.Select(x=>x.hotelName);
            SelectList list = new SelectList(Hotellist);
            ViewBag.Hotel = list;
            return View(ibs.Allbooking(hanme,bDate));
        }

        public ActionResult Verification(string search)
        {
            if (search != null)
            {
                int num;
                bool isnum = Int32.TryParse(search, out num);
                if (isnum)
                {
                    Booking V = ibs.verify(Convert.ToInt32(search));
                    if (V != null)
                    {
                        ViewData["Display"] = "true";
                        return View(V);
                    }
                    else
                    {
                        ViewData["Display"] = "false";
                        return View();
                    }
                }
                else {
                    return View();
                }
            }
            else {
                return View();
            }
            
        }

        [HttpGet]
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index","Home");
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(hs.Edit(id));
        }


        [HttpPost]
        public ActionResult Edit(Hotelinfo H)
        {
            if (ModelState.IsValid)
            {
                if (H.totalrooms == 0)
                {
                    H.status = "No";
                    hs.EditConfirm(H);
                    return RedirectToAction("Index");
                }
                else {
                    hs.EditConfirm(H);
                    return RedirectToAction("Index");
                }

            }
            else
            {
                return View(H);
            }
        }


        [HttpGet]
        public ActionResult Detail(int id)
        {
            return View(hs.Detail(id));
        }

        [HttpGet]
        public ActionResult BookingDetails(int id)
        {
            return View(ibs.Bdetails(id));
        }


        [HttpGet]
        public ActionResult Delete(int id)
        {
            return View(hs.Delete(id));
        }


        [HttpPost]
        public ActionResult Delete(Hotelinfo H)
        {
            hs.DeleteConfirm(H);
            return RedirectToAction("Index");
        }



    }
}