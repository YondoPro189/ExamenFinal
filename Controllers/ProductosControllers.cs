using ExamenFinal.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExamenFinal.Controllers
{
    public class ProductosController : Controller
    {
        // Inventario dentro del controlador
        private static List<Producto> productos = new List<Producto>()
        {
            new Producto("Monitor", 3000),
            new Producto("Mouse", 250),
            new Producto("Laptop", 15000),
            new Producto("Teclado", 1000),
            new Producto("Hub USB", 150)
        };

        public IActionResult Index()
        {
            ViewBag.ProductoMasCaro = ObtenerProductoMasCaro();
            return View(productos);
        }

        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Crear(Producto model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            productos.Add(model);
            return RedirectToAction("Index");
        }

        private Producto ObtenerProductoMasCaro()
        {
            if (productos == null || productos.Count == 0)
                return null;

            //TODO implementar logica para regresar el producto mas mas Caro

            var masCaro = productos[0];

            return masCaro;
        }
    }
}
