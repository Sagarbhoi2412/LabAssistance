using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VGEC.ViewModel;

namespace VGEC.Controllers
{
    public class FacultyController : Controller
    {
        IFacultyViewModel facultyViewModel;
        public FacultyController(IFacultyViewModel facultyViewModel)
        {
            this.facultyViewModel = facultyViewModel;
        }
        // GET: Faculty
        public ActionResult Index()
        {
            return View();
        }
    }
}