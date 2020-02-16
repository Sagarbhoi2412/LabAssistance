using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VGEC.Models;

namespace VGEC.ViewModel
{
    public class FacultyViewModel : IFacultyViewModel
    {
        VgecDbContext db;
        public FacultyViewModel(VgecDbContext vgecDbContext)
        {
            this.db = vgecDbContext;
        }
        public bool Authenticate()
        {
            return true;
        }
    }
}