using BulkyWeb.Data;
using BulkyWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BulkyWeb.Controllers
{
    public class BookController : Controller
    {
        private readonly ApplicationDbContext _db;

        public BookController(ApplicationDbContext db)
        {
            _db = db;
        }


        public IActionResult Index()
        {

            return View(_db.Books.Include(u=>u.Category).ToList() );
        }



        public IActionResult Create()
        {
            ViewData["catDisplayOrder"] = new SelectList(_db.Categories.ToList(),"Id", "DisplayOrder");
            ViewData["catName"] = new SelectList(_db.Categories.ToList(), "Name", "Name");

            return View();
        }


        [HttpPost]
        public IActionResult Create(Book obj)
        {
          

            if (ModelState.IsValid)
            {
                _db.Books.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }




        // Edit Action Method

        public IActionResult Edit(int? id)
        {
            if (id == 0 || id == null)
                return NotFound();

            Book? obj = _db.Books.FirstOrDefault(u => u.Id == id);
            if (obj == null)
                return NotFound();
            ViewData["catDisplayOrder"] = new SelectList(_db.Categories.ToList(), "Id", "DisplayOrder");
            ViewData["catName"] = new SelectList(_db.Categories, "Name", "Name");

            return View(obj);
        }

        [HttpPost]

        public IActionResult Edit(Book obj)
        {
            if(ModelState.IsValid)
            {
                _db.Books.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }




        //Detete Action Method

        public IActionResult Delete(int? id)
        {
            if (id == 0 || id == null)
                return NotFound();

            Book? obj = _db.Books.FirstOrDefault(u => u.Id == id);
            if (obj == null)
                return NotFound();

            ViewData["catDisplayOrder"] = new SelectList(_db.Categories.ToList(), "Id", "DisplayOrder");
            ViewData["catName"] = new SelectList(_db.Categories, "Name", "Name");
            return View(obj);
        }


        [HttpPost,ActionName("Delete")]
    
        public IActionResult DeletePOST(int id)
        {
            Book? obj = _db.Books.FirstOrDefault(u => u.Id == id);
            if (obj == null)
                return NotFound();

            _db.Books.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}
