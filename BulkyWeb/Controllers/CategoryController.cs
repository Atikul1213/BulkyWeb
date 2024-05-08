using BulkyWeb.Data;
using BulkyWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext db)
        {

            _db = db;
        }

        public IActionResult Index()
        {
            List<Category> objCategoryList = _db.Categories.ToList();
            return View(objCategoryList);
        }






        // Create 
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Create(Category obj)
        {
            //if( obj.Name != null && obj.Name == obj.DisplayOrder.ToString())
            //{
            //    ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name");
            //}


            if(ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();

        }





        // Edit

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
                return NotFound();


            Category? catobj = _db.Categories.FirstOrDefault(u => u.Id == id);
            if (catobj == null)
                return NotFound();

            return View(catobj);
        }



        [HttpPost]
        public IActionResult Edit(Category obj)
        {

            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj); 
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }




        // Delete

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
                return NotFound();

            Category? obj = _db.Categories.FirstOrDefault(u => u.Id == id);

            if (obj == null)
                return NotFound();

            return View(obj);
        }


        [HttpPost,ActionName("Delete")]

        public IActionResult DeletePOST(int? id)
        {
            Category? obj = _db.Categories.FirstOrDefault(u => u.Id == id);
            if (obj == null)
                return NotFound();
            _db.Categories.Remove(obj);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }




    }
}
