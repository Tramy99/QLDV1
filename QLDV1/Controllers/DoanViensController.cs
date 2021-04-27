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
    public class DoanViensController : Controller
    {
        private QLDVConnect db = new QLDVConnect();

        // GET: DoanViens
        public ActionResult Index()
        {
            var doanViens = db.DoanViens.Include(d => d.ChiDoans);
            return View(doanViens.ToList());
        }

        // GET: DoanViens/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DoanVien doanVien = db.DoanViens.Find(id);
            if (doanVien == null)
            {
                return HttpNotFound();
            }
            return View(doanVien);
        }
        // [Authorize(Roles = "admin")]
        // GET: DoanViens/Create
        public ActionResult Create()
        {
            ViewBag.macd = new SelectList(db.ChiDoans, "macd", "tencd");
            return View();
        }

        // POST: DoanViens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "madv,tendv,ns,gioitinh,quequan,ngayvd,dantoc,macd")] DoanVien doanVien)
        {
            if (ModelState.IsValid)
            {
                db.DoanViens.Add(doanVien);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.macd = new SelectList(db.ChiDoans, "macd", "tencd", doanVien.macd);
            return View(doanVien);
        }
        // [Authorize(Roles = "admin")]
        // GET: DoanViens/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DoanVien doanVien = db.DoanViens.Find(id);
            if (doanVien == null)
            {
                return HttpNotFound();
            }
            ViewBag.macd = new SelectList(db.ChiDoans, "macd", "tencd", doanVien.macd);
            return View(doanVien);
        }

        // POST: DoanViens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "madv,tendv,ns,gioitinh,quequan,ngayvd,dantoc,macd")] DoanVien doanVien)
        {
            if (ModelState.IsValid)
            {
                db.Entry(doanVien).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.macd = new SelectList(db.ChiDoans, "macd", "tencd", doanVien.macd);
            return View(doanVien);
        }
        // [Authorize(Roles = "admin")]
        // GET: DoanViens/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DoanVien doanVien = db.DoanViens.Find(id);
            if (doanVien == null)
            {
                return HttpNotFound();
            }
            return View(doanVien);
        }

        // POST: DoanViens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            DoanVien doanVien = db.DoanViens.Find(id);
            db.DoanViens.Remove(doanVien);
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
