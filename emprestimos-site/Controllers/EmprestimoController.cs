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

        public IActionResult Cadastrar() 
        {
            return View();
        }
    }
}
