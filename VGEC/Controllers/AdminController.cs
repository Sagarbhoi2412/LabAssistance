using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VGEC.Models;
using VGEC.ViewModel;

namespace VGEC.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAdminViewModel adminviewmodal;
        public AdminController(IAdminViewModel avm)
        {
            this.adminviewmodal = avm;
        }
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(VGEC.Models.Admin admin)
        {
            if(adminviewmodal.Authenticate(admin))
            {
                Session["user"] = admin.UserName;
                return View("Home",admin);
            }
            else
            {
                TempData["error"] = "Wrong Credential";
                return View();

            }
        }
        public ActionResult Home()
        {   if (Session["user"] != null)
            {
                return View();
            }
            else
            {
                return View("Index");
            }
        }
        public ActionResult Logout()
        {
            Session.Remove("user");
            return View("Index");
        }
        public ActionResult AddSubject()
        {
            return View(adminviewmodal.GetAllSubject()) ;
        }
        [HttpPost]
        public ActionResult AddSubject(Subject sub)
        {
            adminviewmodal.AddSubject(sub);
            TempData["add"] = "Subject Added Sucessfully";
            return View(adminviewmodal.GetAllSubject());
        }
        public ActionResult AddFaculty()
        {
            return View(adminviewmodal.GetAllFacuilty());
        }
        [HttpPost]
        public ActionResult AddFaculty(Faculty f)
        {
            TempData["add"] = "Faculty Added Sucessfully";
            adminviewmodal.AddFaculty(f);
            return View(adminviewmodal.GetAllFacuilty());
        }
        public ActionResult AssignMentor()
        {
            return View(adminviewmodal.GetAssignMentor());
        }
        [HttpPost]
        public ActionResult AssignMentor(Mentor m)
        {
            TempData["add"] = "Mentor Assign Sucessfully";
            adminviewmodal.AssignMentor(m);
            return View(adminviewmodal.GetAssignMentor());
        }

        public ActionResult Edit(int id)
        {
            return View(adminviewmodal.GetFaculty(id));
        }
        [HttpPost]
        public ActionResult Edit(Faculty f)
        {
            if(adminviewmodal.EditDetails(f))
            {
                TempData["add"] = "Edited Sucessfully";
                return RedirectToAction("AddFaculty");
            }
            TempData["add"] = "Something Wrong..Try Again";
            return View("AddFaculty");
        }
        public ActionResult Delete(int id)
        {
            if (adminviewmodal.DeleteFaculty(id))
            {
                TempData["add"] = "Deleted Sucessfully";
                return RedirectToAction("AddFaculty");
            }
            TempData["add"] = "Something Wrong..Try Again";
            return View("AddFaculty");
        }
        
    }
}