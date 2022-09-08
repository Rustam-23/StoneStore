using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using StoneStore.Data;
using StoneStore.Models;

namespace StoneStore.Controllers
{
    public class ApplicationTypeController : Controller
    {
        private readonly StoneDbContext _db;

        public ApplicationTypeController(StoneDbContext db)
        {
            _db = db;
        }
        
        public IActionResult Index()
        {
            IEnumerable<ApplicationType> objList = _db.ApplicationType;
            return View(objList);
        }
        
        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ApplicationType obj)
        {
            _db.ApplicationType.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        
        //GET - EDIT
        public IActionResult Edit(int id)
        {
            if (id == null || id == null)
            {
                return NotFound();
            }

            var obj = _db.ApplicationType.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            
            return View(obj);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ApplicationType obj)
        {
            if (ModelState.IsValid)
            {
                _db.ApplicationType.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        
        //GET - DELETE
        public IActionResult Delete(int? id)
        {
            if (id == null || id == null)
            {
                return NotFound();
            }

            var obj = _db.ApplicationType.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            
            return View(obj);
        }
        
        //POST - DELETE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.ApplicationType.Find(id);

            if (obj == null)
            {
                return NotFound();
            }

            _db.ApplicationType.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}