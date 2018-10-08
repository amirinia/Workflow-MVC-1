using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Workflow_MVC_1.Models;
using Workflow_MVC_1.ViewModels;

namespace Workflow_MVC_1.Controllers
{
    [Authorize]
    public class MyWorkflowController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult CreateWorkflowModelView()
        {
            var viewModel = new WorkflowFormViewModel
            {
                TargetUsers = db.Users.ToList()
            };

            return View(viewModel);
        }

        // GET: MyWorkflow
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserName();
            var list = db.workflows
                .Where(c => c.TargetUser == userId)
                .Where(c => c.StartDate > DateTime.Now)
                .Where(c => c.MyState.ToString()!="Done").ToList();

            return View(list);
        }


        // GET: Workflows/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Workflow workflow = db.workflows.Find(id);
            if (workflow == null)
            {
                return HttpNotFound();
            }
            return View(workflow);
        }

        // POST: Workflows/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,OwnerUser,Name,Context,StartDate,TargetUser,MyState")] Workflow workflow)
        {
            if (ModelState.IsValid)
            {
                db.Entry(workflow).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(workflow);
        }

        // GET: Workflows/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Workflows/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,OwnerUser,Name,Context,StartDate,TargetUser,MyState")] Workflow workflow)
        {
            if (ModelState.IsValid)
            {
                db.workflows.Add(workflow);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(workflow);
        }

    }
}