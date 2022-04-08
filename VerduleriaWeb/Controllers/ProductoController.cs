using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VerduleriaWeb.Entidades;
using VerduleriaWeb.EntityFramework;

namespace VerduleriaWeb.Controllers
{
    public class ProductoController : Controller


    {

        private ApplicationDbContext dbContext;
        public ProductoController(ApplicationDbContext applicationDbContext)
        {
            dbContext = applicationDbContext;
        }
        // GET: ProductoController
        public async Task<ActionResult> Index()
        {
        //   lista de clientes comentados cargados en la memoria
        //    var producto1 = new Producto { Id = 1, Nombre = "Naranja", Precio = 2, Cantidad = 5, Disponible = true };
        //    var producto2 = new Producto { Id = 2, Nombre = "Manzana", Precio = 3, Cantidad = 10, Disponible = true };
        //    var lista2 = new List<Producto>();
        //    lista2.Add(producto1);
        //    lista2.Add(producto2);

            var lista2 = await dbContext.Productos.ToListAsync();
            return View(lista2);
        }

        // GET: ProductoController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            Producto material = await dbContext.Productos.FindAsync(id);
            return View(material);
        }

        // GET: ProductoController/Create
        
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Producto producto)
        {
            try
            {
                dbContext.Add(producto);
                await dbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductoController/Edit/5
        public async Task<ActionResult> Edit (int id)
        {
            var producto = await dbContext.Productos.FindAsync(id);
            return View(producto);
        }

        // POST: ProductoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Producto producto)
        {
            try
            {
                if (id != producto.Id)
                {
                    new Exception("Los id no coinciden");
                }
                dbContext.Update(producto);
                await dbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductoController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var producto = await dbContext.Productos.FindAsync(id);
            return View();
        }

        // POST: ProductoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, Producto producto)
        {
            try
            {
                dbContext.Remove(producto);
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
