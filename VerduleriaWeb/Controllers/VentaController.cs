using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VerduleriaWeb.EntityFramework;

namespace VerduleriaWeb.Controllers
{
    public class VentaController : Controller
    {
        private readonly ApplicationDbContext applicationDbContext;

        public VentaController(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }
        // GET: VentaController
        public async Task<ActionResult> Index()
        {
            var ventas = await applicationDbContext.Ventas.ToListAsync();
            return View(ventas);
        }

        // GET: VentaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: VentaController/Create
        public async Task<ActionResult> Create()
        {
            ViewBag.ClienteId =  new SelectList(await applicationDbContext.Clientes.ToListAsync(),"Id","Nombre");
            return View();
        }

        // POST: VentaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: VentaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: VentaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: VentaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: VentaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
