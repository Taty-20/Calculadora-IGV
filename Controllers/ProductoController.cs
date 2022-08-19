using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using tarea1.Models;


namespace tarea1.Controllers
{
    
    public class ProductoController : Controller
    {
        private readonly ILogger<ProductoController> _logger;

        public ProductoController(ILogger<ProductoController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult resultado(Producto objProducto)
        {
            double IGV;
            double peso,costoTotal,costo;
            String descripcion;

//nombre,peso,unidad,precio

            descripcion=objProducto.descripcion;
            peso=objProducto.peso;
            costo=Math.Round((objProducto.precioU*objProducto.cantidad),2);
            IGV=Math.Round((costo*0.18),2);
            costoTotal=Math.Round((costo+IGV),2);
           

            ViewData["Message"]="⇛ Descripcion del Producto: "+descripcion;
            ViewData["Message1"]="⇛ Peso:"+peso;
            ViewData["Message2"]="⇛ Costo:"+" S/"+costo+" soles";
            ViewData["Message3"]="⇛ IGV: "+" S/"+IGV+" soles";
            ViewData["Message4"]="⇛ Costo Total: "+" S/"+costoTotal+" soles";
            

            return View("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}