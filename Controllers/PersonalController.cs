using trabalho.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using X.PagedList;

namespace trabalho.Controllers
{
    public class PersonalController : Controller
    {
        public Context context { get; set; }
        public PersonalController(Context ctx)
        {
            context = ctx;
        }

        public IActionResult Index(int pag = 1)
        {
            return View((context.Personals).ToPagedList(pag, 3));
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create (Personal personal)
        {
            context.Add(personal);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var personal = context.Personals.FirstOrDefault(p => p.PersonalId == id);
            return View(personal);
        }

        public IActionResult Edit(int id)
        {
            var personal = context.Personals.Find(id);
            return View(personal);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Personal personal)
        {
            context.Entry(personal).State = EntityState.Modified;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var personal = context.Personals.FirstOrDefault(p => p.PersonalId == id);
            return View(personal);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Personal personal)
        {
            context.Remove(personal);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
