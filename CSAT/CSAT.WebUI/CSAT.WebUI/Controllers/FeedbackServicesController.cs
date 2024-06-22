using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CSAT.WebUI.Controllers
{
    public class FeedbackServicesController : Controller
    {
        // GET: FeedbckServices
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Details(string shortkey)
        {
            ViewBag.ShortURL = shortkey;
            return View(nameof(Survey));
        }
        // GET: FeedbckServices/Create
        public ActionResult Survey()
        {
            return View();
        }

        // GET: FeedbckServices/Complaint/Create
        public ActionResult Complaint()
        {
            return View();
        }

        public ActionResult QRCodePrint()
        {
            return View();
        }
    }
}
