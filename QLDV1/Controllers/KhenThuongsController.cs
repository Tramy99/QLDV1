﻿using System;
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
    public class KhenThuongsController : Controller
    {
        private QLDVConnect db = new QLDVConnect();

        // GET: KhenThuongs
        public ActionResult Index()
        {
            var khenThuongs = db.KhenThuongs.Include(k => k.DoanViens);
            return View(khenThuongs.ToList());
        }

        // GET: KhenThuongs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KhenThuong khenThuong = db.KhenThuongs.Find(id);
            if (khenThuong == null)
            {
                return HttpNotFound();
            }
            return View(khenThuong);
        }
        [Authorize(Roles = "admin")]
        // GET: KhenThuongs/Create
        public ActionResult Create()
        {
            ViewBag.madv = new SelectList(db.DoanViens, "madv", "tendv");
            return View();
        }

        // POST: KhenThuongs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "makt,tenkt,madv,thanhtich,namhoc")] KhenThuong khenThuong)
        {
            if (ModelState.IsValid)
            {
                db.KhenThuongs.Add(khenThuong);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.madv = new SelectList(db.DoanViens, "madv", "tendv", khenThuong.madv);
            return View(khenThuong);
        }
        [Authorize(Roles = "admin")]
        // GET: KhenThuongs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KhenThuong khenThuong = db.KhenThuongs.Find(id);
            if (khenThuong == null)
            {
                return HttpNotFound();
            }
            ViewBag.madv = new SelectList(db.DoanViens, "madv", "tendv", khenThuong.madv);
            return View(khenThuong);
        }

        // POST: KhenThuongs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "makt,tenkt,madv,thanhtich,namhoc")] KhenThuong khenThuong)
        {
            if (ModelState.IsValid)
            {
                db.Entry(khenThuong).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.madv = new SelectList(db.DoanViens, "madv", "tendv", khenThuong.madv);
            return View(khenThuong);
        }
        [Authorize(Roles = "admin")]
        // GET: KhenThuongs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KhenThuong khenThuong = db.KhenThuongs.Find(id);
            if (khenThuong == null)
            {
                return HttpNotFound();
            }
            return View(khenThuong);
        }

        // POST: KhenThuongs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            KhenThuong khenThuong = db.KhenThuongs.Find(id);
            db.KhenThuongs.Remove(khenThuong);
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
