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
    public class GOALs1Controller : Controller
    {
        private UNFCYJEntities db = new UNFCYJEntities();

        // GET: GOALs1
        public ActionResult Index()
        {
            return View(db.GOALS.ToList());
        }

        // GET: GOALs1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GOAL gOAL = db.GOALS.Find(id);
            if (gOAL == null)
            {
                return HttpNotFound();
            }
            return View(gOAL);
        }

        // GET: GOALs1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GOALs1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Create([Bind(Include = "goalID,period,actualValue,goalValue,fiscalYear,subcategory,category,workstream,team")] GOAL gOAL)
        {
                db.GOALS.Add(gOAL);
                db.SaveChanges();
                return RedirectToAction("Index");
        }

        // GET: GOALs1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GOAL gOAL = db.GOALS.Find(id);
            if (gOAL == null)
            {
                return HttpNotFound();
            }
            return View(gOAL);
        }

        // POST: GOALs1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Edit([Bind(Include = "goalID,period,actualValue,goalValue,fiscalYear,subcategory,category,workstream,team")] GOAL gOAL)
        {
                db.Entry(gOAL).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
        }

        // GET: GOALs1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GOAL gOAL = db.GOALS.Find(id);
            if (gOAL == null)
            {
                return HttpNotFound();
            }
            return View(gOAL);
        }

        // POST: GOALs1/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            GOAL gOAL = db.GOALS.Find(id);
            db.GOALS.Remove(gOAL);
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
