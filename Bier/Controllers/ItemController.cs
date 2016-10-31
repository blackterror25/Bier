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
    public class ItemController : Controller
    {
        Item item;
        ItemService itemService;

        // GET: Item
        public ActionResult Index()
        {
            item = new Item();
            itemService = new ItemService();

            List<Item> itemList = itemService.GetAllItemsPerUser(User.Identity.GetUserId());

            return View(itemList);
        }

        // GET: Item/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Item/Create
        public ActionResult Create()
        {
            BierService bierService = new BierService();
            List<Bier> bierList = new List<Bier>();

            LocatieService locatieService = new LocatieService();
            List<Locatie> locatieList = new List<Locatie>();

            if (UserService.GetShowPublicBier(User.Identity.GetUserId())) bierList.AddRange(bierService.GetPublicBier());
            bierList.AddRange(bierService.GetBierPerUserId(User.Identity.GetUserId()));
            var bierFix = bierList.Select(b => new { Id = b.Id, Name = (b.Naam + " "+ b.Inhoud.Capaciteit + b.Inhoud.Eenheid) });

            ViewBag.BierLijst = new SelectList(bierFix, "Id", "Name");


            if (UserService.GetShowPublicLocatie(User.Identity.GetUserId())) locatieList.AddRange(locatieService.GetPublicLocatie());
            locatieList.AddRange(locatieService.GetAllLocationsPerUser(User.Identity.GetUserId()));
            var locatieFix = locatieList.Select(l => new { Id = l.Id, Name = l.Naam });

            ViewBag.LocatieLijst = new SelectList(locatieFix, "Id", "Name");


            return View();
        }

        // POST: Item/Create
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

        // GET: Item/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Item/Edit/5
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

        // GET: Item/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Item/Delete/5
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
