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
    public class SUBCATEGORiesController : Controller
    {
        private UNFCYJEntities db = new UNFCYJEntities();

        // GET: SUBCATEGORies
        public ActionResult Index()
        {
            return View(db.SUBCATEGORies.ToList());
        }

        // GET: SUBCATEGORies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SUBCATEGORies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Create([Bind(Include = "subcategoryID,subcategoryName")] SUBCATEGORY sUBCATEGORY)
        {
                db.SUBCATEGORies.Add(sUBCATEGORY);
                db.SaveChanges();
                return RedirectToAction("Index");
        }

        // GET: SUBCATEGORies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SUBCATEGORY sUBCATEGORY = db.SUBCATEGORies.Find(id);
            if (sUBCATEGORY == null)
            {
                return HttpNotFound();
            }
            return View(sUBCATEGORY);
        }

        // POST: SUBCATEGORies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Edit([Bind(Include = "subcategoryID,subcategoryName")] SUBCATEGORY sUBCATEGORY)
        {
                db.Entry(sUBCATEGORY).State = EntityState.Modified;
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
