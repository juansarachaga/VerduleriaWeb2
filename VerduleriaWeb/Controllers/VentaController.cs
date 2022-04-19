using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VerduleriaWeb.Entidades;
using VerduleriaWeb.EntityFramework;
using VerduleriaWeb.Migrations;

namespace VerduleriaWeb.Controllers
{
    public class VentaController : Controller
    {
        private readonly ApplicationDbContext applicationDbContext;
        private object dbContext;

        public VentaController(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }
        // GET: VentaController
        public async Task<ActionResult> Index()
        {
            var ventas = await applicationDbContext.Ventas.Include(x=>x.Cliente).ToListAsync();
            return View(ventas);
        }

        // GET: VentaController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var venta = await applicationDbContext.Ventas.FindAsync(id);
            return View(venta);
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
        public async Task<ActionResult> Create(Venta venta)
        {
            try
            {
                applicationDbContext.Add(venta);
                await applicationDbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: VentaController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {

            var venta = await applicationDbContext.Ventas.FindAsync(id);
            ViewBag.ClienteId = new SelectList(await applicationDbContext.Clientes.ToListAsync(), "Id", "Nombre", venta.ClienteId); 
            return View(venta);
        }

        // POST: VentaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, venta collection)
        {
            try
            {
                if (id != venta.Id)
                {
                    new Exception("Los id no coinciden");
                }
                 dbContext.Update(venta);
                await dbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ClienteController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            //var venta = await dbContext.Ventas.FindAsync(id);
            return View();
        }

        // POST: ClienteController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, Venta venta)
        {
            try
            {
                //dbContext.Remove(venta);
                //await dbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
