using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Beer.Model;
using Beer.Service;
using Microsoft.AspNet.Identity;
using System.Net;

namespace Beer.Controllers
{
    public class BierController : Controller
    {
        Bier bier;
        BierService bierService;
        UserService userService;

        // GET: Bier
        public ActionResult Index()
        {
            List<Bier> bier = new List<Bier>();
            bierService = new BierService();

            if (UserService.GetShowPublicBier(User.Identity.GetUserId())) bier.AddRange(bierService.GetPublicBier());

            bier.AddRange(bierService.GetBierPerUserId(User.Identity.GetUserId()));

            return View(bier);
        }

        // GET: Bier/Details/5
        public ActionResult Details(int? id)
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
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            bierService = new BierService();
            bier = new Bier();

            bier = bierService.GetBierPerId(id);

            if (bier == null || bier.AspNetUsersId == null || bier.AspNetUsersId != User.Identity.GetUserId())
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            return View(bier);
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
