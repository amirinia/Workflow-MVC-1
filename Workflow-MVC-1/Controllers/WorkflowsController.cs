using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Workflow_MVC_1.Models;

namespace Workflow_MVC_1.Controllers
{
    public class WorkflowsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Workflows
        public ActionResult Index()
        {
            return View(db.workflows.ToList());
        }

        // GET: Workflows/Details/5
        public ActionResult Details(int? id)
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
        public ActionResult Create([Bind(Include = "Id,OwnerUser,Name,Context,StartDate,TargetUser,ImageUrl,MyState")] Workflow workflow )
        {
            if (ModelState.IsValid)
            {
 
                db.workflows.Add(workflow);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(workflow);
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
        public ActionResult Edit([Bind(Include = "Id,OwnerUser,Name,Context,StartDate,TargetUser,ImageUrl,MyState")] Workflow workflow)
        {
            if (ModelState.IsValid)
            {
                db.Entry(workflow).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(workflow);
        }

        // GET: Workflows/Delete/5
        public ActionResult Delete(int? id)
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

        // POST: Workflows/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Workflow workflow = db.workflows.Find(id);
            db.workflows.Remove(workflow);
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
    }
}
