using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HotelEntity;
using HotelService;
using System.IO;
using System.IO.Ports;
using System.Threading;
using System.Threading.Tasks;


namespace HotelMSystem.Controllers
{
    public class HomeController : Controller
    {
        IhotelS hs = servicefactory.gethotelService();
        IloginS ils = servicefactory.getloginService();
        IbookingS ibs = servicefactory.getbookingService();
        SerialPort sp = new SerialPort();
        Random rand = new Random();


        public ActionResult Index(string search)
        {
            return View(hs.Getall(search));
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Detail(int id)
        {
            return View(hs.Detail(id));
        }

        [HttpPost]
        public ActionResult Login(Login l)
        { 

            if (ModelState.IsValid)
            {

                if (ils.logincheck(l))
                {
                    Session["login"] = "on";
                    return RedirectToAction("Index", "Admin");
                }
                else
                {
                    ViewData["error"] = "User/Password not matched !!!";
                    return View();
                }
            }
            else
            {
                return View();
            }

        }

        [HttpGet]
        public ActionResult Booking(int id)
        {
            int random = rand.Next(1111, 9999);
            Hotelinfo H = hs.Detail(id);
            Session["H_name"] = H.hotelName;
            Session["R_price"] = H.roomprice;
            Session["V_code"] = random;
            return View();
        }

        [HttpPost]
        public ActionResult Booking(Booking B,string payment,string tamount)
        {
             
            if (ModelState.IsValid)
            {
                int Payment = Convert.ToInt32(payment);
                int Tamount = Convert.ToInt32(tamount);
                if (Payment<Tamount/2) { 
                    ViewData["error"] = "Payment less than 50% of Total amount !!!"; 
                    return View(B); 
                }
                else {
                    
                   /* string m = "01744666587";
                    sp.PortName = "COM14";
                    sp.Open();
                    sp.WriteLine("AT" + Environment.NewLine);      //this using to control modem
                    Thread.Sleep(100);
                    sp.WriteLine("AT+CMGF=1" + Environment.NewLine);   // set the gsm modem in sms text mode
                    Thread.Sleep(100);
                    sp.WriteLine("AT+CSCS=\"GSM\"" + Environment.NewLine); //selects the character set of the mobile equipment
                    Thread.Sleep(100);
                    sp.WriteLine("AT+CMGS=\"" + m + "\"" + Environment.NewLine);  //sends an SMS message to a GSM phone
                    Thread.Sleep(100);
                    sp.WriteLine("Booking Successful." + "   Varfication code : " + B.code + "   Hotel : " + B.hotelname + "            Total room : " + B.totalrooms + "         Total Day : " + B.totaldays + "            Due Amount : " + B.dueamount + " BDT          Booking date : " + B.bookingdate + Environment.NewLine);  // take message from textbox2
                    Thread.Sleep(100);
                    sp.Write(new byte[] { 26 }, 0, 1);   // to send hex code to serial port
                    Thread.Sleep(100);
                    var rep = sp.ReadExisting();
                    sp.Close();*/

                    ibs.create(B);
                    Hotelinfo H = hs.UpdateRoom(B.hotelname);
                    H.totalrooms -= B.totalrooms;
                    hs.UpdateRoomConfirm(H);
                    Session.Clear();
                    return RedirectToAction("Index"); 
                }
            }
            else {
                return View();
            }
        }

        public ActionResult Contacts()
        {
            return View();
        }

    }
}