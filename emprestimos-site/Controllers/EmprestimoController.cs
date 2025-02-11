using Microsoft.AspNetCore.Mvc;
using emprestimos_site.Data;
using emprestimos_site.Models;

namespace emprestimos_site.Controllers
{
    public class EmprestimoController : Controller
    {

        readonly private ApplicationDbContext _db;

        public EmprestimoController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Emprestimo()
        {
            IEnumerable<EmprestimoModel> emprestimos = _db.Emprestimo;
            return View(emprestimos);
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Editar(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            EmprestimoModel emprestimo = _db.Emprestimo.FirstOrDefault(x => x.Id == id);

            if (emprestimo == null)
            {
                return NotFound();
            }

            return View(emprestimo);
        }

        [HttpGet]
        public IActionResult Excluir(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            EmprestimoModel emprestimo = _db.Emprestimo.FirstOrDefault(x => x.Id == id);

            if (emprestimo == null)
            {
                return NotFound();
            }

            return View(emprestimo);
        }

        [HttpPost]
        public IActionResult Cadastrar(EmprestimoModel emprestimo)
        {
            if (ModelState.IsValid)
            {
                _db.Emprestimo.Add(emprestimo);
                _db.SaveChanges();

                return RedirectToAction("Emprestimo");
            }

            return View();
        }

        [HttpPost]
        public IActionResult Editar(EmprestimoModel emprestimo)
        {
            if (ModelState.IsValid)
            {
                _db.Emprestimo.Update(emprestimo);
                _db.SaveChanges();
                return RedirectToAction("Emprestimo");
            }

            return View(emprestimo);
        }

        [HttpPost]
        public IActionResult Excluir(EmprestimoModel emprestimo)
        {
            if (emprestimo == null)
            {
                return NotFound();
            }

            _db.Emprestimo.Remove(emprestimo);
            _db.SaveChanges();

            return RedirectToAction("Emprestimo");
        }
    }
}   
