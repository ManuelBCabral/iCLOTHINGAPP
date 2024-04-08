using Group12_iCLOTHINGAPP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Group12_iCLOTHINGAPP.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "About Us";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Conract";

            return View();
        }
        public ActionResult Login()
        {
            ViewBag.Message = "Login";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(USERPASSWORD objUser)
        {
            if (ModelState.IsValid)
            {
                using (Group12_iCLOTHINGDBEntities2 db = new Group12_iCLOTHINGDBEntities2())
                {
                    var obj = db.USERPASSWORD.Where(a => a.ACCNAME.Equals(objUser.ACCNAME) && a.ENCRYPTPASS.Equals(objUser.ENCRYPTPASS)).FirstOrDefault();
                    if (obj != null)
                    {
                        //Session["UserID"] = obj.UserId.ToString();
                        Session["UserName"] = obj.ACCNAME.ToString();
                        return RedirectToAction("UserDashBoard");
                    }
                }
            }
            return View(objUser);
        }
        public ActionResult UserDashboard()
        {
            {
                if (Session["UserName"] != null)
                {
                    return View();
                }
                else
                {
                    Console.WriteLine("Error");
                    return RedirectToAction("Login");
                }
            }
        }
        public ActionResult AdminLogin()
        {
            ViewBag.Message = "Login";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AdminLogin(ADMINISTRATOR objUser)
        {
            if (ModelState.IsValid)
            {
                using (Group12_iCLOTHINGDBEntities2 db = new Group12_iCLOTHINGDBEntities2())
                {
                    var obj = db.ADMINISTRATOR.Where(a => a.ADMINID.Equals(objUser.ADMINID)).FirstOrDefault();
                    if (obj != null)
                    {
                        //Session["UserID"] = obj.UserId.ToString();
                        Session["UserName"] = obj.ADMINNAME.ToString();
                        return RedirectToAction("AdminDashBoard");
                    }
                }
            }
            return View(objUser);
        }
        public ActionResult PreLogin()
        {
            ViewBag.Message = "PreLogin";
            return View();
        }
        public ActionResult AdminDashboard()
        {
            ViewBag.Message = "AdminDashboard";
            return View();
        }
        public ActionResult ShoppingCartView(string CustID)
        {
            using (Group12_iCLOTHINGDBEntities2 db = new Group12_iCLOTHINGDBEntities2())
            {
                SHOPPINGCART newshopp = new SHOPPINGCART();
                var Shopping = db.SHOPPINGCART.Where(c => c.CUSTID == CustID).ToList();
                return View(Shopping);
            }
            //return View(db.SHOPPINGCART.ToList());

        }
    }

}