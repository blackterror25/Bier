﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Beer.Model;
using Beer.Service;


namespace Beer.Controllers
{
    public class BierController : Controller
    {
        Bier bier;

        // GET: Bier
        public ActionResult Index()
        {
            bier = new Bier();
            return View();
        }

        // GET: Bier/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Bier/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bier/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Bier/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Bier/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Bier/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Bier/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
