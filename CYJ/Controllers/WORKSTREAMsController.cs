using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CYJ.Models;

namespace CYJ.Controllers
{
    [Authorize]
    public class WORKSTREAMsController : Controller
    {
        private UNFCYJEntities db = new UNFCYJEntities();

        // GET: WORKSTREAMs
        public ActionResult Index()
        {
            return View(db.WORKSTREAMs.ToList());
        }
        // GET: WORKSTREAMs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WORKSTREAMs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Create([Bind(Include = "workstreamID,workstreamName")] WORKSTREAM wORKSTREAM)
        {
                db.WORKSTREAMs.Add(wORKSTREAM);
                db.SaveChanges();
                return RedirectToAction("Index");
        }

        // GET: WORKSTREAMs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WORKSTREAM wORKSTREAM = db.WORKSTREAMs.Find(id);
            if (wORKSTREAM == null)
            {
                return HttpNotFound();
            }
            return View(wORKSTREAM);
        }

        // POST: WORKSTREAMs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Edit([Bind(Include = "workstreamID,workstreamName")] WORKSTREAM wORKSTREAM)
        {
                db.Entry(wORKSTREAM).State = EntityState.Modified;
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
