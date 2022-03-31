using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using VerduleriaWeb.Entidades;
using VerduleriaWeb.Models;

namespace VerduleriaWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var cliente1 = new Cliente { Id = 1, Nombre = "Gaston", Telefono = "1234" };
            var cliente2 = new Cliente { Id = 2, Nombre = "JuanPablo", Telefono = "1234" };
            var lista = new List<Cliente>();
            lista.Add(cliente1);
            lista.Add(cliente2);
            ViewBag.Cliente = cliente2;
            ViewBag.ListaCliente = lista;

            var producto1 = new Producto { Id = 1, Nombre = "Naranja", Precio = 2, Cantidad = 5, Disponible = true };
            var producto2 = new Producto { Id = 2, Nombre = "Manzana", Precio = 3, Cantidad = 10, Disponible = true };
            var lista2 = new List<Producto>();
            lista2.Add(producto1);
            lista2.Add(producto2);
            ViewBag.Producto = producto2;
            ViewBag.ListaProducto = lista2;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}