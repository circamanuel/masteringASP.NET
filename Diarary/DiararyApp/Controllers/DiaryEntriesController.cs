using DiaryApp.Data;
using DiaryApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Eventing.Reader;

namespace DiaryApp.Controllers
{
    public class DiaryEntriesController : Controller
    {
        private readonly ApplicationDbContext _db;

        public DiaryEntriesController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            List<DiaryEntry> objDiaryEntryList = _db.DiaryEntries.ToList();
            return View(objDiaryEntryList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(DiaryEntry obj)
        {
            if (obj != null && obj.Title.Length < 3)
            {
                ModelState.AddModelError("Title", "Title too short");
            }
            else if (ModelState.IsValid)
            {
                _db.DiaryEntries.Add(obj); // Adds the new diary entry to the database
                _db.SaveChanges();         // Saves the changes to the database
                return RedirectToAction("Index");
            }

            return View(obj);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            DiaryEntry? diaryEntry = _db.DiaryEntries.Find(id);

            if(id == 0)  
            {
                return NotFound();
            }

            return View(diaryEntry);
        }


        [HttpPost]
        public IActionResult Edit(DiaryEntry obj)
        {
            if (obj != null && obj.Title.Length < 3)
            {
                ModelState.AddModelError("Title", "Title too short");
            }
            else if (ModelState.IsValid)
            {
                _db.DiaryEntries.Update(obj); // Adds the new diary entry to the database
                _db.SaveChanges();         // Saves the changes to the database
                return RedirectToAction("Index");
            }

            return View(obj);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            DiaryEntry? diaryEntry = _db.DiaryEntries.Find(id);

            if (id == 0)
            {
                return NotFound();
            }

            return View(diaryEntry);
        }

       
        [HttpPost]
        public IActionResult Delete(DiaryEntry obj)
        {
            if (obj != null && obj.Title.Length < 3)
            {
                ModelState.AddModelError("Title", "Title too short");
            }
            else if (ModelState.IsValid)
            {
                _db.DiaryEntries.Remove(obj); // Adds the new diary entry to the database
                _db.SaveChanges();         // Saves the changes to the database

                return RedirectToAction("Index");
            }

            return View(obj);
        }

    }
}
