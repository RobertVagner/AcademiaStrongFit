using trabalho.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace trabalho.Controllers
{
    public class AlunoController : Controller
    {
        public Context context { get; set; }
        public AlunoController(Context ctx)
        {
            context = ctx;
        }

        public IActionResult Index(int pag = 1)
        {
            return View(context.Alunos.Include(p => p.Personal).ToPagedList(pag, 3));
        }

        public IActionResult Create() 
        {
            ViewBag.PersonalId = new SelectList(context.Personals.OrderBy(p => p.Nome), "PersonalId", "Nome");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Aluno aluno)
        {
            context.Add(aluno);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var aluno = context.Alunos.Include(f=>f.Personal).FirstOrDefault(p=>p.AlunoId == id);
            return View(aluno);
        }

        public IActionResult Edit(int id)
        {
            var aluno = context.Alunos.Find(id);
            ViewBag.PersonalId = new SelectList(context.Personals.OrderBy(f => f.Nome), "PersonalId", "Nome");
            return View(aluno);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Aluno aluno)
        {
            context.Entry(aluno).State = EntityState.Modified;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var aluno = context.Alunos.Include(f=>f.Personal).FirstOrDefault(p=>p.AlunoId==id);
            return View(aluno);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Aluno aluno)
        {
            context.Remove(aluno);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
