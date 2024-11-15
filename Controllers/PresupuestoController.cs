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
        var clientes = _clienteRepository.listarClientes();
        var presupuesto = new Presupuestos(idPresupuesto);
        var presupuestoViewModel = new CrearPresupuestoViewModel(presupuesto,clientes);
        return View(presupuestoViewModel);
    }
    [HttpPost]
    public IActionResult CrearPresupuesto(Presupuestos presupuesto,int idCliente)
    {
        _presupuestoRepository.CrearPresupuesto(presupuesto,idCliente);
        return RedirectToAction("ListarPresupuestos");
    }
    [HttpGet]
    public IActionResult EliminarPresupuesto(int idPresupuesto)
    {
        _presupuestoRepository.eliminarPresupuesto(idPresupuesto);
        return RedirectToAction("ListarPresupuestos");
    }
    [HttpGet]
    public IActionResult AgregarProducto(int idPresupuesto)
    {
        var listaProductos = _productoRepository.listarProductos();
        var agregarProducto = new AgregarProductoViewModel(idPresupuesto,listaProductos);
        return View(agregarProducto);
    }
    [HttpPost]
    public IActionResult AgregarProducto(int idPresupuesto, int idProducto, int cantidad)
    {
        _presupuestoRepository.agregarProducto(idPresupuesto,idProducto,cantidad);
        return RedirectToAction("VerDetalle",new{idPresupuesto = idPresupuesto});
    }

}