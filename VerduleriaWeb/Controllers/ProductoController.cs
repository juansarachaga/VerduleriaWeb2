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
        public ActionResult Details(int id)
        {
            return View();
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
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProductoController/Edit/5
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

        // GET: ProductoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductoController/Delete/5
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
