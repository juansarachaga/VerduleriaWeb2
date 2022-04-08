using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using VerduleriaWeb.Entidades;
using VerduleriaWeb.EntityFramework;

namespace VerduleriaWeb.Controllers
{
    public class ClienteController : Controller

        
    {

        private ApplicationDbContext dbContext;
        public ClienteController(ApplicationDbContext applicationDbContext)
        {
            dbContext = applicationDbContext;
        }
        
        // GET: ClienteController
        public async Task<ActionResult> Index()
        {
            //var cliente1 = new Cliente { Id = 1, Nombre = "Gaston", Telefono = "1234" };
            //var cliente2 = new Cliente { Id = 2, Nombre = "JuanPablo", Telefono = "1234" };
            //var lista = new List<Cliente>();
            //lista.Add(cliente1);
            //lista.Add(cliente2);


            var lista = await dbContext.Clientes.ToListAsync();
            return View(lista);
        }

        // GET: ClienteController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            Cliente persona = await dbContext.Clientes.FindAsync(id);
            return View(persona);
        }

        // GET: ClienteController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClienteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Cliente cliente)
        {
            try
            {
                dbContext.Add(cliente);
                await dbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ClienteController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var cliente = await dbContext.Clientes.FindAsync(id);   
            
            return View(cliente);
        }

        // POST: ClienteController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Cliente cliente)
        {
            try
            {
                if (id != cliente.Id)
                {
                    new Exception("Los id no coinciden");
                }
                dbContext.Update(cliente);
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
            var cliente = await dbContext.Clientes.FindAsync(id);
            return View();
        }

        // POST: ClienteController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, Cliente cliente)
        {
            try
            {
                dbContext.Remove(cliente);
                await dbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
