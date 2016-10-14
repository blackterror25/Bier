using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Microsoft.AspNet.Identity;


using System.Data.Entity;

using Bier.Model;
using Bier.Service;

namespace Bier.Controllers
{
    public class LocatieController : Controller
    {
        private LocatieService locatieService;
        private Locatie locatie;

        public LocatieController()
        {
            locatieService = new LocatieService();
        }

        // GET: Locatie
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var locationList = locatieService.getAllLocationsPerUser(userId);

            return View(locationList);
        }

        // GET: Locatie/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Locatie/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Locatie/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                locatie = new Locatie();


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Locatie/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Locatie/Edit/5
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

        // GET: Locatie/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Locatie/Delete/5
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
