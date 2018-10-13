using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Workflow_MVC_1.Models;
using Workflow_MVC_1.ViewModels;

namespace Workflow_MVC_1.Controllers
{
    public class WorkflowVController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: WorkflowFormViewModels
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserName();
            var list = db.WorkflowVs
                .Where(c => c.TargetUser == userId)
                .Where(c => c.Date > DateTime.Now)
                .Where(c => c.MyState.ToString() != "Done").ToList();

            return View(list);
        }

        // GET: Workflows
        [Authorize(Roles = "Admin")]
        public ActionResult IndexAdmin()
        {
            return View(db.WorkflowVs.ToList());
        }

        // GET: WorkflowFormViewModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewModels.WorkflowV workflowFormViewModel = db.WorkflowVs.Find(id);
            if (workflowFormViewModel == null)
            {
                return HttpNotFound();
            }
            return View(workflowFormViewModel);
        }

        // GET: WorkflowFormViewModels/Create
        public ActionResult Create()
        {
            var viewModel = new ViewModels.WorkflowV
            {
                TargetUsers = db.Users.ToList()
            };

            return View(viewModel);
        }

        // POST: WorkflowFormViewModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,OwnerUser,Date,Time,Name,Context,TargetUser,ImageUrl,MyState")] ViewModels.WorkflowV workflowV)
        {
            if (ModelState.IsValid)
            {
                db.WorkflowVs.Add(workflowV);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(workflowV);
        }

        // GET: WorkflowFormViewModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewModels.WorkflowV workflowFormViewModel = db.WorkflowVs.Find(id);
            if (workflowFormViewModel == null)
            {
                return HttpNotFound();
            }
            return View(workflowFormViewModel);
        }

        // POST: WorkflowFormViewModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,OwnerUser,Date,Time,Name,Context,TargetUser,ImageUrl,MyState")] ViewModels.WorkflowV workflowFormViewModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(workflowFormViewModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(workflowFormViewModel);
        }

        // GET: WorkflowFormViewModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewModels.WorkflowV workflowFormViewModel = db.WorkflowVs.Find(id);
            if (workflowFormViewModel == null)
            {
                return HttpNotFound();
            }
            return View(workflowFormViewModel);
        }

        // POST: WorkflowFormViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ViewModels.WorkflowV workflowFormViewModel = db.WorkflowVs.Find(id);
            db.WorkflowVs.Remove(workflowFormViewModel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        //[HttpPost]
        //public ActionResult CreateWorkflowModelView(ViewModels.WorkflowV viewModel)
        //{
        //    //var targetUser = db.Users.Single(a => a.Id == viewModel.TargetUser);
        //    var Workflow = new Workflow
        //    {
        //        OwnerUser = viewModel.OwnerUser,
        //        Name = viewModel.Name,
        //        Context = viewModel.Context,
        //        StartDate = DateTime.Parse(string.Format("{0} {1}", viewModel.Date,viewModel.Time)),
        //        TargetUserId = viewModel.TargetUser,
        //        ImageUrl = viewModel.ImageUrl,
        //        MyState = (Models.State)viewModel.MyState
        //    };

        //    db.Workflows.Add(Workflow);
        //    db.SaveChanges();

        //    return View();
        //}
    }
}
