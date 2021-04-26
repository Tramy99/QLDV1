using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QLDV1.Models;

namespace QLDV1.Controllers
{
    public class DiemDanhsController : Controller
    {
        private QLDVConnect db = new QLDVConnect();

        // GET: DiemDanhs
        public ActionResult Index()
        {
            var diemDanhs = db.DiemDanhs.Include(d => d.DoanViens).Include(d => d.HoatDongs);
            return View(diemDanhs.ToList());
        }

        // GET: DiemDanhs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DiemDanh diemDanh = db.DiemDanhs.Find(id);
            if (diemDanh == null)
            {
                return HttpNotFound();
            }
            return View(diemDanh);
        }
        [Authorize(Roles = "admin")]
        // GET: DiemDanhs/Create
        public ActionResult Create()
        {
            ViewBag.madv = new SelectList(db.DoanViens, "madv", "tendv");
            ViewBag.mahd = new SelectList(db.HoatDongs, "mahd", "tenhd");
            return View();
        }

        // POST: DiemDanhs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,madv,mahd,ghichu")] DiemDanh diemDanh)
        {
            if (ModelState.IsValid)
            {
                db.DiemDanhs.Add(diemDanh);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.madv = new SelectList(db.DoanViens, "madv", "tendv", diemDanh.madv);
            ViewBag.mahd = new SelectList(db.HoatDongs, "mahd", "tenhd", diemDanh.mahd);
            return View(diemDanh);
        }
        [Authorize(Roles = "admin")]
        // GET: DiemDanhs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DiemDanh diemDanh = db.DiemDanhs.Find(id);
            if (diemDanh == null)
            {
                return HttpNotFound();
            }
            ViewBag.madv = new SelectList(db.DoanViens, "madv", "tendv", diemDanh.madv);
            ViewBag.mahd = new SelectList(db.HoatDongs, "mahd", "tenhd", diemDanh.mahd);
            return View(diemDanh);
        }

        // POST: DiemDanhs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,madv,mahd,ghichu")] DiemDanh diemDanh)
        {
            if (ModelState.IsValid)
            {
                db.Entry(diemDanh).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.madv = new SelectList(db.DoanViens, "madv", "tendv", diemDanh.madv);
            ViewBag.mahd = new SelectList(db.HoatDongs, "mahd", "tenhd", diemDanh.mahd);
            return View(diemDanh);
        }
        [Authorize(Roles = "admin")]
        // GET: DiemDanhs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DiemDanh diemDanh = db.DiemDanhs.Find(id);
            if (diemDanh == null)
            {
                return HttpNotFound();
            }
            return View(diemDanh);
        }

        // POST: DiemDanhs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DiemDanh diemDanh = db.DiemDanhs.Find(id);
            db.DiemDanhs.Remove(diemDanh);
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
