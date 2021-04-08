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
    [Authorize]
    public class XepLoaisController : Controller
    {
        private QLDVConnect db = new QLDVConnect();

        // GET: XepLoais
        public ActionResult Index()
        {
            var xepLoais = db.XepLoais.Include(x => x.DoanViens).Include(x => x.HoatDongs);
            return View(xepLoais.ToList());
        }

        // GET: XepLoais/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            XepLoai xepLoai = db.XepLoais.Find(id);
            if (xepLoai == null)
            {
                return HttpNotFound();
            }
            return View(xepLoai);
        }

        // GET: XepLoais/Create
        public ActionResult Create()
        {
            ViewBag.madv = new SelectList(db.DoanViens, "madv", "tendv");
            ViewBag.mahd = new SelectList(db.HoatDongs, "mahd", "tenhd");
            return View();
        }

        // POST: XepLoais/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,madv,namhoc,nhanxet,xeploai,mahd")] XepLoai xepLoai)
        {
            if (ModelState.IsValid)
            {
                db.XepLoais.Add(xepLoai);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.madv = new SelectList(db.DoanViens, "madv", "tendv", xepLoai.madv);
            ViewBag.mahd = new SelectList(db.HoatDongs, "mahd", "tenhd", xepLoai.mahd);
            return View(xepLoai);
        }

        // GET: XepLoais/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            XepLoai xepLoai = db.XepLoais.Find(id);
            if (xepLoai == null)
            {
                return HttpNotFound();
            }
            ViewBag.madv = new SelectList(db.DoanViens, "madv", "tendv", xepLoai.madv);
            ViewBag.mahd = new SelectList(db.HoatDongs, "mahd", "tenhd", xepLoai.mahd);
            return View(xepLoai);
        }

        // POST: XepLoais/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,madv,namhoc,nhanxet,xeploai,mahd")] XepLoai xepLoai)
        {
            if (ModelState.IsValid)
            {
                db.Entry(xepLoai).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.madv = new SelectList(db.DoanViens, "madv", "tendv", xepLoai.madv);
            ViewBag.mahd = new SelectList(db.HoatDongs, "mahd", "tenhd", xepLoai.mahd);
            return View(xepLoai);
        }

        // GET: XepLoais/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            XepLoai xepLoai = db.XepLoais.Find(id);
            if (xepLoai == null)
            {
                return HttpNotFound();
            }
            return View(xepLoai);
        }

        // POST: XepLoais/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            XepLoai xepLoai = db.XepLoais.Find(id);
            db.XepLoais.Remove(xepLoai);
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
