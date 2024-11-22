using Microsoft.AspNetCore.Mvc;
namespace tl2_tp6_2024_RojasG98.Controllers;

public class PresupuestoController : Controller
{
    private IPresupuestoRepository _presupuestoRepository;
    private readonly IClienteRepository _clienteRepository;
    private readonly IProductoRepository _productoRepository;

    public PresupuestoController(IPresupuestoRepository presupuestoRepository, IClienteRepository clienteRepository, IProductoRepository productoRepository)
    {
        _presupuestoRepository = presupuestoRepository;
        _clienteRepository = clienteRepository;
        _productoRepository = productoRepository;
    }

    [HttpGet]
    public ActionResult<List<Presupuestos>> ListarPresupuestos()
    {
        ViewData["AccessLevels"] = HttpContext.Session.GetString("AccessLevels");
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
    public IActionResult CrearPresupuesto(int idPresupuesto)
    {
        if (HttpContext.Session.GetString("AccessLevels") == "Administrador")
        {
            var clientes = _clienteRepository.listarClientes();
            var presupuesto = new Presupuestos(idPresupuesto);
            var presupuestoViewModel = new CrearPresupuestoViewModel(presupuesto, clientes);
            return View(presupuestoViewModel);
        }
        return RedirectToAction("Index", "Home");
    }
    [HttpPost]
    public IActionResult CrearPresupuesto(Presupuestos presupuesto, int idCliente)
    {
        if (HttpContext.Session.GetString("AccessLevels") == "Administrador")
        {
            _presupuestoRepository.CrearPresupuesto(presupuesto, idCliente);
            return RedirectToAction("ListarPresupuestos");
        }
        return RedirectToAction("Index", "Home");
    }
    [HttpGet]
    public IActionResult EliminarPresupuesto(int idPresupuesto)
    {
        if (HttpContext.Session.GetString("AccessLevels") == "Administrador")
        {
        _presupuestoRepository.eliminarPresupuesto(idPresupuesto);
        return RedirectToAction("ListarPresupuestos");
        }
        return RedirectToAction("Index", "Home");
    }
    [HttpGet]
    public IActionResult AgregarProducto(int idPresupuesto)
    {
        if (HttpContext.Session.GetString("AccessLevels") == "Administrador")
        {
        var listaProductos = _productoRepository.listarProductos();
        var agregarProducto = new AgregarProductoViewModel(idPresupuesto, listaProductos);
        return View(agregarProducto);
        }
        return RedirectToAction("Index", "Home");
    }
    [HttpPost]
    public IActionResult AgregarProducto(int idPresupuesto, int idProducto, int cantidad)
    {
        if (HttpContext.Session.GetString("AccessLevels") == "Administrador")
        {
        _presupuestoRepository.agregarProducto(idPresupuesto, idProducto, cantidad);
        return RedirectToAction("VerDetalle", new { idPresupuesto = idPresupuesto });
        }
        return RedirectToAction("Index", "Home");
    }

}