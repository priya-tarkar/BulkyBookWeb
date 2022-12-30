using BulkyBookWeb.Data;
using BulkyBookWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBookWeb.Controllers
{
    public class CategoryController : Controller
    {
        private ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult IndexDetails()
        {
            IEnumerable<Category> dataget = _db.categories1;
            return View(dataget);
        }
       //get
        public IActionResult Create()
        {


            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category cat)
        {
            if(cat.Name==cat.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "please eneter correct value");
            }
            if (ModelState.IsValid)
            {
                _db.Add(cat);
                TempData["suc"] = "data created successfully";
                _db.SaveChanges();
                return RedirectToAction("IndexDetails","Category");
            }
            return View(cat);

        }

        public IActionResult Edit(int?id)
        {
            if(id==null || id==0)
            {
                return NotFound();
            }
            var categoryFromDb = _db.categories1.FirstOrDefault(x => x.Id == id);
            if(categoryFromDb==null)
            {
                return NotFound();
            }




            return View(categoryFromDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category cat)
        {
            if (cat.Name == cat.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "please eneter correct value");
            }
            if (ModelState.IsValid)
            {
                _db.categories1.Update(cat);
                TempData["suc"] = "data updated successfully";
                _db.SaveChanges();
                return View(cat);
            }
            return View(cat);

        }
        public IActionResult Delete(int id)
        {
            var categoryFromDb = _db.categories1.FirstOrDefault(x => x.Id == id);


            return View(categoryFromDb);
            
        }

        
        [HttpPost,ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            if (id == 0  || id==null)
            {
                Console.WriteLine("hello");
            }
            else
            {
                var categoryFromDb = _db.categories1.FirstOrDefault(x => x.Id == id);

                if (ModelState.IsValid)
                {
                    _db.categories1.Remove(categoryFromDb);
                    TempData["suc"] = "data deleted successfully";
                    _db.SaveChanges();

                }
            }

            return RedirectToAction("IndexDetails", "category");


        }



    }
}
