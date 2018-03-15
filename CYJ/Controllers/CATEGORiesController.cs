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
    public class CATEGORiesController : Controller
    {
        private UNFCYJEntities db = new UNFCYJEntities();

        // GET: CATEGORies
        public ActionResult Index()
        {
            return View(db.CATEGORies.ToList());
        }

        // GET: CATEGORies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CATEGORies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Create([Bind(Include = "categoryID,categoryName")] CATEGORY cATEGORY)
        {
                db.CATEGORies.Add(cATEGORY);
                db.SaveChanges();
                return RedirectToAction("Index");
        }

        // GET: CATEGORies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CATEGORY cATEGORY = db.CATEGORies.Find(id);
            if (cATEGORY == null)
            {
                return HttpNotFound();
            }
            return View(cATEGORY);
        }

        // POST: CATEGORies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Edit([Bind(Include = "categoryID,categoryName")] CATEGORY cATEGORY)
        {
                db.Entry(cATEGORY).State = EntityState.Modified;
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
