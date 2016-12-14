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

        // GET: Bier
        public ActionResult Index()
        {
            if (User.Identity.GetUserId() == null) return RedirectToAction("Login", "Account");

            List<Bier> bier = new List<Bier>();
            bierService = new BierService();

            if (UserService.GetShowPublicBier(User.Identity.GetUserId())) bier.AddRange(bierService.GetPublicBier());

            bier.AddRange(bierService.GetBierPerUserId(User.Identity.GetUserId()));

            return View(bier);
        }

        // GET: Bier/Create
        public ActionResult Create()
        {
            if (User.Identity.GetUserId() == null) return RedirectToAction("Login", "Account");

            InhoudService inhoudService = new InhoudService();
            List<Inhoud> inhoudList = new List<Inhoud>();

            if (UserService.GetShowPublicInhoud(User.Identity.GetUserId()))
            {
                inhoudList.AddRange(inhoudService.GetPublicInhoud());
            }

            inhoudList.AddRange(inhoudService.GetInhoudPerUserId(User.Identity.GetUserId()));
            var inhFix = inhoudList.Select(i => new { Id = i.Id, Name = (i.Capaciteit + " " + i.Eenheid) });
            
            ViewBag.Inhoud = new SelectList(inhFix, "Id", "Name");
            
            
            return View();
        }

        // POST: Bier/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            if (User.Identity.GetUserId() == null) return RedirectToAction("Login", "Account");

            try
            {
                bier = new Bier();
                bierService = new BierService();

                bier.AspNetUsersId = User.Identity.GetUserId();
                bier.Naam = collection["Naam"];
                bier.Label = collection["Label"];
                bier.InhoudId = Convert.ToInt32(collection["Inhoud"]);
                bier.Temperatuur = Convert.ToInt32(collection["Temperatuur"]);
                bier.Barcode = collection["Barcode"];

                bierService.BierToevoegen(bier);

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
            if (User.Identity.GetUserId() == null) return RedirectToAction("Login", "Account");

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

            InhoudService inhoudService = new InhoudService();
            List<Inhoud> inhoudList = new List<Inhoud>();

            if (UserService.GetShowPublicInhoud(User.Identity.GetUserId()))
            {
                inhoudList.AddRange(inhoudService.GetPublicInhoud());
            }

            inhoudList.AddRange(inhoudService.GetInhoudPerUserId(User.Identity.GetUserId()));
            var inhFix = inhoudList.Select(i => new { Id = i.Id, Name = (i.Capaciteit + " " + i.Eenheid) });

            ViewBag.Inhoud = new SelectList(inhFix, "Id", "Name", bier.InhoudId);


            return View(bier);
        }

        // POST: Bier/Edit/5
        [HttpPost]
        public ActionResult Edit(int? id, FormCollection collection)
        {
            if (User.Identity.GetUserId() == null) return RedirectToAction("Login", "Account");

            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                bier = new Bier();
                bierService = new BierService();

                bier = bierService.GetBierPerId(Convert.ToInt32(id));
                
                if (bier.AspNetUsersId != User.Identity.GetUserId())
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                
                bier.Naam = collection["Naam"];
                bier.Label = collection["Label"];
                bier.InhoudId = Convert.ToInt32(collection["Inhoud"]);
                bier.Temperatuur = Convert.ToInt32(collection["Temperatuur"]);
                bier.Barcode = collection["Barcode"];

                bierService.BierUpdaten(bier);

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
            if (User.Identity.GetUserId() == null) return RedirectToAction("Login", "Account");

            return View();
        }
    }
}
