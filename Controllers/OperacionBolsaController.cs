using Microsoft.AspNetCore.Mvc;
using PC1_TEO_PROGRA_CHAVEZMELI.Models;

namespace PC1_TEO_PROGRA_CHAVEZMELI.Controllers
{
    public class OperacionBolsaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(OperacionBolsa operacion)
        {
            if (ModelState.IsValid)
            {
                // Calcular IGV
                operacion.IGV = 0.18m;

                // Calcular comisión
                operacion.Comision = operacion.MontoAbonar > 300 ? 1 : 3;

                // Calcular Total a Pagar
                decimal totalInstrumentos = 0;
                if (operacion.SP500) totalInstrumentos += 500;
                if (operacion.DowJones) totalInstrumentos += 300;
                if (operacion.BonosUS) totalInstrumentos += 120;

                operacion.TotalPagar = totalInstrumentos + (totalInstrumentos * operacion.IGV) + operacion.Comision;

                // Redirigir a una vista de confirmación o mostrar resultado en la misma página
                return View("Resultado", operacion);
            }

            return View(operacion);
        }
    }
}
