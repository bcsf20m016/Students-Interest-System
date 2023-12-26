using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StudentsInterestSystem.Data;
using StudentsInterestSystem.Models;
using StudentsInterestSystem.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StudentsInterestSystem.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudentRepo stdRepo;
        public readonly ActionsLoggerRepo actionRepo;

        public StudentController(StudentRepo stdRepo, ActionsLoggerRepo actionRepo)
        {
            this.stdRepo = stdRepo;
            this.actionRepo = actionRepo;
        }

        [HttpGet]
        public IActionResult AddStudent()
        {
            //recording action
            actionRepo.saveRecord(DateTime.Now, "Requested AddStudent Screen");
            //action recorded

            var allInterests = stdRepo.getAllInterests();
            ViewBag.Interests = allInterests;
            return View();
        }

        [HttpPost]
        public IActionResult AddStudent(AddStudentViewModel std)
        {
            var student = new Student
            {
                Name = std.Name,
                RollNo = std.RollNo,
                Email = std.Email,
                Gender = std.Gender,
                DOB = std.DOB,
                City = std.City,
                Interest = std.Interest == "other" ? std.stdInterest : std.Interest,
                Department = std.Department,
                DegreeTitle = std.DegreeTitle,
                Subject = std.Subject,
                StartDate = std.StartDate,
                EndDate = std.EndDate
            };
            
            var result = stdRepo.AddStudent(student);
            if(result is true)
            {
                //recording action
                actionRepo.saveRecord(DateTime.Now, "Student added successfully");
                //action recorded
                TempData["StudentExists"] = "false";
                return RedirectToAction("AddStudent");
            }
            else
            {
                //recording action
                actionRepo.saveRecord(DateTime.Now, "Student failed to add because it exists already");
                //action recorded
                TempData["StudentExists"] = "true";
                return RedirectToAction("AddStudent");
            }

        }

        [HttpGet]
        public IActionResult AllStudents()
        {
            //recording action
            actionRepo.saveRecord(DateTime.Now, "Requested AllStudents Screen");
            //action recorded
            var studentsList = stdRepo.getAllStudents();
            return View(studentsList);
        }

        [HttpGet]
        public IActionResult EditStudent(int id)
        {
            //recording action
            actionRepo.saveRecord(DateTime.Now, "Requested EditStudent Screen");
            //action recorded
            var std = stdRepo.getStudentById(id);
            if(std != null)
            {
                var student = new EditStudentViewModel
                {
                    Id = std.Id,
                    Name = std.Name,
                    RollNo = std.RollNo,
                    Email = std.Email,
                    Gender = std.Gender,
                    DOB = std.DOB,
                    City = std.City,
                    Interest = std.Interest,
                    Department = std.Department,
                    DegreeTitle = std.DegreeTitle,
                    Subject = std.Subject,
                    StartDate = std.StartDate,
                    EndDate = std.EndDate
                };
                var allInterests = stdRepo.getAllInterests();
                ViewBag.Interests = allInterests;
                ViewBag.StudentExists = false;
                return View(student);
            }
            else
            {
                ViewBag.StudentExists = true;
                return View();
            }
        }

        [HttpPost]
        public IActionResult EditStudent(EditStudentViewModel student)
        {
            var result = stdRepo.editStudent(student);
            if(result is true)
            {
                //recording action
                actionRepo.saveRecord(DateTime.Now, "Student updated successfully");
                //action recorded
                TempData["StudentUpdated"] = "true";
                return RedirectToAction("AddStudent");
            }
            else
            {
                //recording action
                actionRepo.saveRecord(DateTime.Now, "Student not found for updation");
                //action recorded
                TempData["StudentUpdated"] = "false";
                return RedirectToAction("AddStudent");
            }
        }

        [HttpGet]
        public IActionResult DeleteStudent(int id)
        {
            var result = stdRepo.deleteStudent(id);
            if(result==true)
            {
                //recording action
                actionRepo.saveRecord(DateTime.Now, "Student deleted successfully");
                //action recorded
            }
            else
            {
                //recording action
                actionRepo.saveRecord(DateTime.Now, "Student not found for deletion");
                //action recorded
            }
            return RedirectToAction("AllStudents");
        }

        [HttpGet]
        public IActionResult ViewStudent(int id)
        {
            //recording action
            actionRepo.saveRecord(DateTime.Now, "Requested ViewStudent Screen");
            //action recorded
            var student = stdRepo.getStudentById(id);
            return View(student);
        }

        [HttpGet]
        public IActionResult delAll()
        {
            //recording action
            actionRepo.saveRecord(DateTime.Now, "All Students have been deleted");
            //action recorded
            stdRepo.delAll();
            return RedirectToAction("AllStudents");
        }

        [HttpGet]
        public IActionResult Dashboard()
        {
            //recording action
            actionRepo.saveRecord(DateTime.Now, "Requested Dashboard Screen");
            //action recorded
            var dashboardData = new DashboardViewModel();
            var interests = stdRepo.InterestsStats();
            dashboardData.TopInterests = interests[0];
            dashboardData.BottomInterests = interests[1];
            dashboardData.DistinctInterests = stdRepo.getAllInterests().Count;
            dashboardData.Ages = stdRepo.getAges();
            dashboardData.students = stdRepo.getAllStudents();
            dashboardData.StudentStats = stdRepo.calculateStudentsStatus();
            dashboardData.Submissions = actionRepo.calculateSubmissions();
            dashboardData.Actions = actionRepo.calculateActions();
            dashboardData.ActionsByHour = actionRepo.calculateLastDaysActivities();
            var activeLeastHours = actionRepo.calculateMostLeastHours();
            dashboardData.MostActiveHours = activeLeastHours[0];
            dashboardData.LeastActiveHours = activeLeastHours[1];
            return View(dashboardData);
        }
    }
}

