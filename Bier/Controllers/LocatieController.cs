using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Microsoft.AspNet.Identity;


using System.Data.Entity;

using Bier.Model;
using Bier.Service;
using System.Net;

namespace Bier.Controllers
{
    public class LocatieController : Controller
    {
        private LocatieService locatieService;
        private Locatie locatie;

        public LocatieController()
        {
        }

        // GET: Locatie
        public ActionResult Index()
        {
            locatieService = new LocatieService();
            var userId = User.Identity.GetUserId();
            bool showPublicLocatie = UserService.GetShowPublicLocatie(userId);

            var locationList = new List<Locatie>();

            if (showPublicLocatie) locationList = locatieService.GetAllLocationsPerUser(null).ToList();

            locationList.AddRange(locatieService.GetAllLocationsPerUser(userId).ToList());

            return View(locationList);
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
                locatieService = new LocatieService();

                locatie.AspNetUsersId = User.Identity.GetUserId();
                locatie.Naam = collection["Naam"];
                locatie.Temperatuur = Convert.ToDouble(collection["Temperatuur"]);

                locatieService.VoegLocatieToe(locatie);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Locatie/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        
            locatie = new Locatie();
            locatieService = new LocatieService();

            locatie = locatieService.GetLocatiePerId(Convert.ToInt32(id));

            // Is locatie niet gevonden? heeft geen userID en dus openbaar? of is userID van andere persoon?
            if (locatie == null || locatie.AspNetUsersId == (null) || !(locatie.AspNetUsersId.Equals(User.Identity.GetUserId())))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            return View(locatie);
        }

        // POST: Locatie/Edit/5
        [HttpPost]
        public ActionResult Edit(int? id, FormCollection collection)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                //TODO: is locatie volgens ID weldegelijk an deze gebruiker gelinkt?
                locatieService = new LocatieService();
                locatie = new Locatie();

                locatie.Id = Convert.ToInt32(id);
                locatie.AspNetUsersId = User.Identity.GetUserId();
                locatie.Naam = collection["Naam"];
                locatie.Temperatuur = Convert.ToDouble(collection["Temperatuur"]);

                locatieService.Update(locatie);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Locatie/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            locatie = new Locatie();
            locatieService = new LocatieService();

            locatie = locatieService.GetLocatiePerId(Convert.ToInt32(id));

            // Is locatie niet gevonden? heeft geen userID en dus openbaar? of is userID van andere persoon?
            if (locatie == null || locatie.AspNetUsersId == (null) || !(locatie.AspNetUsersId.Equals(User.Identity.GetUserId())))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            locatieService.RemoveLocatie(id);

            return RedirectToAction("Index", "Locatie");
        }

        // POST: Locatie/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
