namespace MovieTutorial.Controllers
{
    using System.Data.Entity;
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;

    using Microsoft.Ajax.Utilities;

    using MovieTutorial.Models;

    public class MovieController : Controller
    {
        private readonly MovieDbContext db = new MovieDbContext();

        // GET: /Movie/
        public ActionResult Index(string genreFilter, string filterString)
        {
            var genreList = from genre in db.MovieBase orderby genre.Genre select genre.Genre;

            ViewBag.genreFilter = new SelectList(genreList.Distinct());

            var movieList = from movie in db.MovieBase select movie;

            if (!filterString.IsNullOrWhiteSpace())
            {
                movieList = movieList.Where((col) => col.Title.Contains(filterString));
            }

            if (!genreFilter.IsNullOrWhiteSpace())
            {
                movieList = movieList.Where((col) => col.Genre.Equals(genreFilter));
            }

            return this.View(movieList.ToList());
        }

        // GET: /Movie/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MovieEntity movieEntity = db.MovieBase.Find(id);
            if (movieEntity == null)
            {
                return this.HttpNotFound();
            }
            return this.View(movieEntity);
        }

        // GET: /Movie/Create
        public ActionResult Create()
        {
            return this.View();
        }

        // POST: /Movie/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Title,releaseDate,Genre,Price,Rating")] MovieEntity movieEntity)
        {
            if (ModelState.IsValid)
            {
                db.MovieBase.Add(movieEntity);
                db.SaveChanges();
                return this.RedirectToAction("Index");
            }

            return this.View(movieEntity);
        }

        // GET: /Movie/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MovieEntity movieentity = db.MovieBase.Find(id);
            if (movieentity == null)
            {
                return this.HttpNotFound();
            }
            return this.View(movieentity);
        }

        // POST: /Movie/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title,releaseDate,Genre,Price,Rating")] MovieEntity movieentity)
        {
            if (ModelState.IsValid)
            {
                db.Entry(movieentity).State = EntityState.Modified;
                db.SaveChanges();
                return this.RedirectToAction("Index");
            }
            return this.View(movieentity);
        }

        // GET: /Movie/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MovieEntity movieentity = db.MovieBase.Find(id);
            if (movieentity == null)
            {
                return this.HttpNotFound();
            }
            return this.View(movieentity);
        }

        // POST: /Movie/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MovieEntity movieentity = db.MovieBase.Find(id);
            db.MovieBase.Remove(movieentity);
            db.SaveChanges();
            return this.RedirectToAction("Index");
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
