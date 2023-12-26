using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StudentsInterestSystem.Data;
using StudentsInterestSystem.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StudentsInterestSystem.Controllers
{
    public class ActionLoggerController : Controller
    {
        public readonly ActionsLoggerRepo actionRepo;

        public ActionLoggerController(ActionsLoggerRepo actionRepo)
        {
            this.actionRepo = actionRepo;
        }

        [HttpPost]
        public ActionResult LogDataTableActivity(string activity)
        {
            actionRepo.saveRecord(DateTime.Now, activity);
            return Json(new { success = true });
        }
    }
}

