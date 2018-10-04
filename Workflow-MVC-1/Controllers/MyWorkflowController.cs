using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Workflow_MVC_1.Models;

namespace Workflow_MVC_1.Controllers
{
    public class MyWorkflowController : Controller
    {
        private ApplicationDbContext _context = new ApplicationDbContext();

        // GET: MyWorkflow
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserName();
            var list = _context.workflows
                .Where(c => c.TargetUser==userId)
                
                .ToList();

            return View(list);
        }
    }
}