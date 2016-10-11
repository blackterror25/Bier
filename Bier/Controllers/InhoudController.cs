using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bier.Controllers
{
    public class InhoudController : Controller
    {
        // GET: Inhoud
        public ActionResult Index()
        {
            return View();
        }

        // GET: Inhoud/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Inhoud/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Inhoud/Create
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

        // GET: Inhoud/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Inhoud/Edit/5
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

        // GET: Inhoud/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Inhoud/Delete/5
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
