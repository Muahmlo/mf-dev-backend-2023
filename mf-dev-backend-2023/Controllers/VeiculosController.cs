using mf_dev_backend_2023.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace mf_dev_backend_2023.Controllers
{
    public class VeiculosController : Controller
    {
        private readonly AppDbContext _context;
        public VeiculosController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var dados = await _context.Veiculos.ToListAsync();

            return View(dados);
        }

        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IAsyncResult> Create(Veiculo veiculo)
        {

            if (ModelState.IsValid)
            {
                _context.Veiculos. Add(veiculo);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");


            }

            return View(veiculo);
        }   
        
    }
}
