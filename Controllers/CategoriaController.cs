using trabalho.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace trabalho.Controllers
{
    public class CategoriaController : Controller
    {
        public Context context { get; set; }
        public CategoriaController(Context ctx)
        {
            context = ctx;
        }
        public IActionResult Index(int pag = 1)
        {
            return View(context.Categorias.ToPagedList(pag, 3));
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Categoria categoria)
        {
            context.Add(categoria);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var categoria = context.Categorias.FirstOrDefault(p => p.CategoriaID == id);
            return View(categoria);
        }

        public IActionResult Edit(int id)
        {
            var categoria = context.Categorias.Find(id);
            return View(categoria);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Categoria categoria)
        {
            context.Entry(categoria).State = EntityState.Modified;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var categoria = context.Categorias.FirstOrDefault(p => p.CategoriaID == id);
            return View(categoria);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Categoria categoria)
        {
            context.Remove(categoria);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
