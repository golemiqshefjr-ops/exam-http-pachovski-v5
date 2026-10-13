using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using ExamMvc.Models;

namespace ExamMvc.Controllers
{
    // Вариант 5: Места за настаняване
    public class HotelsController : Controller
    {
        private readonly ExamContext db = new ExamContext();

        [HttpGet]
        public ActionResult Index(string search, string category)
        {
            var hotels = db.Hotels.AsQueryable();
            if (!string.IsNullOrWhiteSpace(search))
            {
                hotels = hotels.Where(x => x.Name.Contains(search) || x.City.Contains(search));
            }
            if (!string.IsNullOrWhiteSpace(category))
            {
                hotels = hotels.Where(x => x.Type == category);
            }

            ViewBag.Categories = db.Hotels.Select(x => x.Type).Distinct().OrderBy(x => x).ToList();
            ViewBag.Search = search;
            ViewBag.Category = category;
            return View(hotels.OrderBy(x => x.Name).ToList());
        }

        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (!id.HasValue)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var hotel = db.Hotels.Find(id.Value);
            if (hotel == null)
                return HttpNotFound();

            return View(hotel);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name,City,Type,Rooms,PricePerNight")] Hotel item)
        {
            if (!ModelState.IsValid)
                return View(item);

            db.Hotels.Add(item);
            db.SaveChanges();
            TempData["Message"] = "Мястото за настаняване е добавено успешно.";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (!id.HasValue)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var hotel = db.Hotels.Find(id.Value);
            if (hotel == null)
                return HttpNotFound();

            return View(hotel);
        }

        [HttpPut]
        [ValidateAntiForgeryToken]
        [ActionName("Edit")]
        public ActionResult EditConfirmed([Bind(Include = "Id,Name,City,Type,Rooms,PricePerNight")] Hotel item)
        {
            var hotel = db.Hotels.Find(item.Id);
            if (hotel == null)
                return HttpNotFound();

            if (!ModelState.IsValid)
                return View("Edit", item);

            hotel.Name = item.Name;
            hotel.City = item.City;
            hotel.Type = item.Type;
            hotel.Rooms = item.Rooms;
            hotel.PricePerNight = item.PricePerNight;
            db.SaveChanges();
            TempData["Message"] = "Промените са записани успешно.";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (!id.HasValue)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var hotel = db.Hotels.Find(id.Value);
            if (hotel == null)
                return HttpNotFound();

            return View(hotel);
        }

        [HttpDelete]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var hotel = db.Hotels.Find(id);
            if (hotel == null)
                return HttpNotFound();

            db.Hotels.Remove(hotel);
            db.SaveChanges();
            TempData["Message"] = "Записът е изтрит успешно.";
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                db.Dispose();
            base.Dispose(disposing);
        }
    }
}
