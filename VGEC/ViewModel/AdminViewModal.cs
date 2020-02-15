using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using VGEC.Models;

namespace VGEC.ViewModel
{
    public class AdminViewModal :IAdminViewModel
    {
        private readonly VgecDbContext db;
        public AdminViewModal(VgecDbContext db)
        {
            this.db = db;
        }

        public void AddFaculty(Faculty faculty)
        {
            db.faculties.Add(faculty);
            db.SaveChanges();
        }

        public void AddSubject(Subject sub)
        {
            db.subjects.Add(sub);
            db.SaveChanges();
        }

        public bool AssignMentor(Mentor m)
        {
            var fac = GetFaculty(m.Fac_Id);
            m.UserName = fac.UserName;
            try
            {
                db.mentors.Add(m);
                db.SaveChanges();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool Authenticate(IPerson person) 
        {
          var check=  db.admins.FirstOrDefault(x=>x.UserName.Equals(person.UserName) && x.Password.Equals(person.Password));
            if (check == null)
                return false;
            return true;
        }

        public bool DeleteFaculty(int fac_id)
        {
            try
            {
                db.faculties.Remove(GetFaculty(fac_id));
                db.mentors.Remove(db.mentors.Find(fac_id));
                db.SaveChanges();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool EditDetails(Faculty faculty)
        {
            try
            {
                db.faculties.Attach(faculty);
                db.Entry(faculty).State = EntityState.Modified;
                db.SaveChanges();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public IEnumerable<Faculty> GetAllFacuilty()
        {
            return db.faculties.OrderBy(x=>x.UserName).ToList();
        }
        public IEnumerable<Subject> GetAllSubject()
        {
            return db.subjects.OrderBy(x => x.Subject_Name).ToList();
        }

        public FacMentor GetAssignMentor()
        {
            var fac = db.faculties.ToList();
            var men = db.mentors.ToList();
            //var assing = new List<Faculty>();
            foreach(var item in men)
            {
                fac.Remove(db.faculties.FirstOrDefault(x=>x.Fac_Id==item.Fac_Id));
            }
            FacMentor facMentor = new FacMentor();
            facMentor.faculties = fac;
            facMentor.mentors = men;
            return facMentor;
        }

        public Faculty GetFaculty(int fac_id)
        {
            return db.faculties.FirstOrDefault(x=>x.Fac_Id==fac_id);
        }
    }
}