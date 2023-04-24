using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using X.PagedList;
using trabalho.Models;

namespace trabalho.Controllers
{
    public class ExercicioController : Controller
    {
        public Context context { get; set; }
        public ExercicioController(Context ctx)
        {
            context = ctx;
        }

        public IActionResult Index(int pag = 1)
        {
            return View(context.Exercicios.Include(a => a.Categoria).ToPagedList(pag, 3));
        }

        public IActionResult Create()
        {
            ViewBag.CategoriaID = new SelectList(context.Categorias.OrderBy(p => p.Nome),"CategoriaID", "Nome");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Exercicio exercicio)
        {
            context.Add(exercicio);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Details(int id)
        {
            var exercicio = context.Exercicios.Include(f => f.Categoria).FirstOrDefault(p => p.ExercicioId == id);
            return View(exercicio);
        }

        public IActionResult Edit(int id)
        {
            var exercicio = context.Exercicios.Find(id);
            ViewBag.CategoriaID = new SelectList(context.Categorias.OrderBy(p => p.Nome), "CategoriaID", "Nome");
            return View(exercicio);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Exercicio exercicio)
        {
            context.Entry(exercicio).State = EntityState.Modified;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var exercicio = context.Exercicios.Include(f => f.Categoria).FirstOrDefault(p => p.ExercicioId == id);
            return View(exercicio);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Exercicio exercicio)
        {
            context.Remove(exercicio);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}