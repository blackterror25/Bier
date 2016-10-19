using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Microsoft.AspNet.Identity;

using Beer.Model;
using Beer.Service;
using System.Net;

namespace Beer.Controllers
{
    public class InhoudController : Controller
    {
        Inhoud inhoud;
        InhoudService inhoudService;

        // GET: Inhoud
        public ActionResult Index()
        {
            inhoudService = new InhoudService();

            List<Inhoud> inhoud = new List<Inhoud>();

            if (UserService.GetShowPublicInhoud(User.Identity.GetUserId())) inhoud.AddRange(inhoudService.GetPublicInhoud());

            inhoud.AddRange(inhoudService.GetInhoudPerUserId(User.Identity.GetUserId()));

            return View(inhoud);
        }

        //// GET: Inhoud/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

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
                inhoud = new Inhoud();
                inhoudService = new InhoudService();

                inhoud.AspNetUsersId = User.Identity.GetUserId();
                inhoud.Capaciteit = Convert.ToDouble(collection["Capaciteit"]);
                inhoud.Eenheid = collection["Eenheid"];

                inhoudService.VoegInhoudToe(inhoud);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Inhoud/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            inhoud = new Inhoud();
            inhoudService = new InhoudService();

            inhoud = inhoudService.GetInhoudPerId(Convert.ToInt32(id));


            // Is inhoud niet gevonden? heeft geen userID en dus openbaar? of is userID van andere persoon?
            if (inhoud == null || inhoud.AspNetUsersId == (null) || !(inhoud.AspNetUsersId.Equals(User.Identity.GetUserId())))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            return View(inhoud);
        }

        // POST: Inhoud/Edit/5
        [HttpPost]
        public ActionResult Edit(int? id, FormCollection collection)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                inhoud = new Inhoud();
                inhoudService = new InhoudService();

                inhoud = inhoudService.GetInhoudPerId(Convert.ToInt32(id));
                if (inhoud.AspNetUsersId != User.Identity.GetUserId())
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                inhoud = new Inhoud();
                inhoud.Id = Convert.ToInt32(id);
                inhoud.AspNetUsersId = User.Identity.GetUserId();
                inhoud.Capaciteit = Convert.ToDouble(collection["Capaciteit"]);
                inhoud.Eenheid = collection["Eenheid"];

                inhoudService.Update(inhoud);

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
