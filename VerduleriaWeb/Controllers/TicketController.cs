using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VerduleriaWeb.EntityFramework;
using VerduleriaWeb.Entidades;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace VerduleriaWeb.Controllers
{





    public class TicketController : Controller
    {
        private readonly ApplicationDbContext applicationDbContext;


        public TicketController(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;


        }
        // GET: TicketController
        public async Task<ActionResult> Index()
        {


            var tickets = await applicationDbContext.Tickets.Include(x => x.Venta).Include(x => x.Producto).ToListAsync();
            return View(tickets);
        }

        // GET: TicketController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TicketController/Create
        public async Task<ActionResult> Create()
        {
            ViewBag.VentaId = new SelectList(await applicationDbContext.Ventas.ToListAsync(), "Id", "Id");
            ViewBag.ProductoId = new SelectList(await applicationDbContext.Productos.ToListAsync(), "Id", "Nombre");
            return View();
        }

        // POST: TicketController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Ticket ticket)
        {
            try
            {
                applicationDbContext.Add(ticket);
                await applicationDbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TicketController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var ticket = await applicationDbContext.Tickets.FindAsync(id);
            ViewBag.TicketId = new SelectList(await applicationDbContext.Tickets.ToListAsync(), "Id", "Venta.Id");
            return View(ticket);
           
        }

        // POST: TicketController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, IFormCollection collection)
        {
            try
            {
                if (id != collection.Id)
                {
                    new Exception("Los id no coinciden");
                }
                applicationDbContext.Update(collection);
                await applicationDbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        // GET: TicketController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var ticket = await applicationDbContext.Tickets.Include(x => x.Venta).Include(x => x.Producto).SingleOrDefaultAsync(x => x.Id == id);
            return View(ticket);
        }

        // POST: TicketController/Delete/5
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
