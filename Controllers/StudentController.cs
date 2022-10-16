using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudentDetails.Models;

namespace StudentDetails.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult GetStudentDetails()
        {

            StudentModelManager studentModelManager = new StudentModelManager();
           List<StudentModel> studentModels =studentModelManager.GetStudentinfo();
            return View(studentModels);
        }
        [HttpGet]

        public ActionResult Ins_Update_Delete_Search()
        {
            StudentModel studentModel = new StudentModel();
            ViewResult vr = View("StudentRecord", studentModel);
            ActionResult ar = vr ;
            return vr; 
        }
        [HttpPost]

        public ActionResult Ins_Update_Delete_Search(StudentModel studentModel , string x)
        {
            if (x == "Insert")
            {
                StudentModelManager studentModelManager = new StudentModelManager();
                int conunt = studentModelManager.InsertStudentDetails(studentModel);

                if(conunt>0)
                {
                    RedirectToRouteResult rr = RedirectToAction("GetStudentDetails", "student");
                    ActionResult ar = rr;
                    return ar;
                }
            }
            else if (x == "Update")


            {
                StudentModelManager studentModelManager = new StudentModelManager();
                int conunt = studentModelManager.UpdateStudentDetails(studentModel);
                if (conunt > 0)
                {
                    RedirectToRouteResult rr = RedirectToAction("GetStudentDetails", "student");
                    ActionResult ar = rr;
                    return ar;
                }

            }
            else if (x == "Delete")
            {
                StudentModelManager studentModelManager = new StudentModelManager();
                int conunt = studentModelManager.DeleteStudentDetails(studentModel);
                if (conunt > 0)
                {
                    RedirectToRouteResult rr = RedirectToAction("GetStudentDetails", "student");
                    ActionResult ar = rr;
                    return ar;

                }
            }
            else if (x == "Search")
            {
                
                
               return RedirectToAction("SearchStudentData", "Student",studentModel);
                    

                
            }
            return null;




        }


        public ActionResult SearchStudentData(StudentModel student)
        {
            StudentModelManager studentModelManager = new StudentModelManager();
            StudentModel studentModel = studentModelManager.SearchStudentDetail(student);
            return View("StudentRecord", studentModel);
        }
    }
}