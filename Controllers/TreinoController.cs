using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using trabalho.Models;
using X.PagedList;

namespace trabalho.Controllers
{
    public class TreinoController : Controller
    {
        public Context context { get; set; }
        public TreinoController(Context ctx)
        {
            context = ctx;
        }

        public IActionResult Index(int pag = 1)
        {
            return View(context.Treinos.Include(a => a.Aluno).Include(r => r.TreinoExercicio).ToPagedList(pag, 3));
        }

        public IActionResult Create()
        {
            ViewBag.AlunoId = new SelectList(context.Alunos.OrderBy(p => p.Nome), "AlunoId", "Nome");
            ViewBag.ExercicioId = new SelectList(context.Exercicios.OrderBy(p => p.Nome), "ExercicioId", "Nome");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Treino treino)
        {
            context.Add(treino);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Details(int id)
        {
            var treino = context.Treinos.Include(f => f.Aluno).Include(r => r.TreinoExercicio).FirstOrDefault(p => p.TreinoId == id);
            return View(treino);
        }

        public IActionResult Edit(int id)
        {
            var treino = context.Treinos.Find(id);
            ViewBag.AlunoId = new SelectList(context.Alunos.OrderBy(p => p.Nome), "AlunoId", "Nome");
            ViewBag.ExercicioId = new SelectList(context.Exercicios.OrderBy(p => p.Nome), "ExercicioId", "Nome");
            return View(treino);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Treino treino)
        {
            context.Entry(treino).State = EntityState.Modified;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var treino = context.Treinos.Include(f => f.Aluno).Include(r => r.TreinoExercicio).FirstOrDefault(p => p.TreinoId == id);
            return View(treino);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Treino treino)
        {
            context.Remove(treino);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
