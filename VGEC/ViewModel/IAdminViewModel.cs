using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VGEC.Models;

namespace VGEC.ViewModel
{
    public interface IAdminViewModel
    {
        bool Authenticate(IPerson person);
        IEnumerable<Faculty> GetAllFacuilty();

        void AddFaculty(Faculty faculty);
        IEnumerable<Subject> GetAllSubject();
        void AddSubject(Subject f);
        bool EditDetails(Faculty faculty);

        Faculty GetFaculty(int fac_id);

        bool DeleteFaculty(int fac_id);
        FacMentor GetAssignMentor();
        bool AssignMentor(Mentor m);
    }
}