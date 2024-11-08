using Microsoft.AspNetCore.Mvc;
namespace tl2_tp6_2024_RojasG98.Controllers;

public class PresupuestoController : Controller
{
    private IPresupuestoRepository _presupuestoRepository;

    public PresupuestoController(IPresupuestoRepository presupuestoRepository)
    {
        _presupuestoRepository = presupuestoRepository;
    }

    [HttpGet]
    public ActionResult<List<Presupuestos>> ListarPresupuestos()
    {
        var lista = _presupuestoRepository.listarPresupuestos();
        return View(lista);
    }
    [HttpGet]
    public ActionResult<Presupuestos> VerDetalle(int idPresupuesto)
    {
        var presupuesto = _presupuestoRepository.presupuestoPorId(idPresupuesto);
        return View(presupuesto);
    }
    [HttpGet]
    public IActionResult CrearPresupuesto()
    {
        return View(new Presupuestos());
    }
    [HttpPost]
    public IActionResult CrearPresupuesto(Presupuestos presupuesto)
    {
        _presupuestoRepository.CrearPresupuesto(presupuesto);
        return RedirectToAction("ListarPresupuestos");
    }
    [HttpGet]
    public IActionResult EliminarPresupuesto(int idPresupuesto)
    {
        _presupuestoRepository.eliminarPresupuesto(idPresupuesto);
        return RedirectToAction("ListarPresupuestos");
    }

}