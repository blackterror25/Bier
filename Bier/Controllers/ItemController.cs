using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Beer.Model;
using Beer.Service;

using Microsoft.AspNet.Identity;
using System.Net;
using Aspose.BarCode.BarCodeRecognition;
using System.IO;

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
            var bierFix = bierList.Select(b => new { BId = b.Id, Name = (b.Naam + " " + b.Inhoud.Capaciteit + b.Inhoud.Eenheid) });

            ViewBag.BierLijst = new SelectList(bierFix, "BId", "Name");


            if (UserService.GetShowPublicLocatie(User.Identity.GetUserId())) locatieList.AddRange(locatieService.GetPublicLocatie());
            locatieList.AddRange(locatieService.GetAllLocationsPerUser(User.Identity.GetUserId()));
            var locatieFix = locatieList.Select(l => new { LId = l.Id, Name = l.Naam });

            ViewBag.LocatieLijst = new SelectList(locatieFix, "LId", "Name");


            return View();
        }

        // POST: Item/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                item = new Item();
                itemService = new ItemService();

                item.Bierid = Convert.ToInt32(collection["BId"]);
                item.LocatieId = Convert.ToInt32(collection["LId"]);
                item.AspNetUsersId = User.Identity.GetUserId();
                item.Aantal = Convert.ToInt32(collection["Aantal"]);
                //item.Openbaar = Convert.ToBoolean(collection["Openbaar"]);
                item.Openbaar = true;
                item.HoudsbaarheidDatum = Convert.ToDateTime(collection["HoudsbaarheidDatum"]);

                itemService.AddNewItem(item);

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

        public JsonResult Scan(HttpPostedFileBase file)
        {
            var f = file;

            return null;
        }
    }

}
