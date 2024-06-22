using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CSAT.WebUI.Controllers.SparepartMst
{
    public class SparepartMstController : Controller
    {
        // GET: SparepartMst
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Add()
        {
            ViewBag.ActionType = "Add";
            return View("Details");
        }

        public ActionResult Edit(int id)
        {
            ViewBag.ActionType = "Edit";
            ViewBag.Id = id;
            return View("Details");
        }
    }
}