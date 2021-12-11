using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC_Music.Models;

namespace MVC_Music.Controllers
{
    public class SpotifyController : Controller
    {
        private DB_128040_practiceEntities db = new DB_128040_practiceEntities();

        // GET: Spotify
        public ActionResult Index()
        {
            var popular = db.Spotifies.OrderByDescending(x => x.Popularity);
            return View(popular);
        }

        public ActionResult Artist()
        {
            var artist = db.Spotifies.OrderBy(x => x.Artist);
            return View(artist);
            //return View(db.Spotifies.ToList());
        }

        // GET: Spotify/Details/5
        public ActionResult Songs(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Spotify spot = (Spotify)db.Spotifies.Where(x => x.Artist == id);
            List<Spotify> art = new List<Spotify>();
            art.Add(spot);
            //Spotify spotify = db.Spotifies.Find(id);
            if (spot == null)
            {
                return HttpNotFound();
            }
            return View();
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
