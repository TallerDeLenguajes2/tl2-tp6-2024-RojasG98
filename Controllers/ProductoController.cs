using Microsoft.AspNetCore.Mvc;
namespace tl2_tp6_2024_RojasG98.Controllers;

public class ProductoController : Controller
{
    private IProductoRepository _productoRepository;

    public ProductoController(IProductoRepository productoRepository)
    {
        _productoRepository = productoRepository;
    }
    [HttpGet]
    public ActionResult<List<Productos>> ListaProductos()
    {
        var lista = _productoRepository.listarProductos();
        return View(lista);
    }
    [HttpGet]
    public IActionResult CrearProducto()
    {
        return View(new Productos());
    }
    [HttpPost]
    public IActionResult CrearProducto(Productos nuevoProducto)
    {
        _productoRepository.CrearProducto(nuevoProducto);
        return RedirectToAction("ListaProductos");
    }
    [HttpGet]
    public IActionResult ModificarProducto(int idProducto)
    {
        var producto = _productoRepository.productoPorId(idProducto);
        return View(producto);
    }
    [HttpPost]
    public IActionResult ModificarProducto(int idProducto,Productos productoModificado)
    {
        _productoRepository.ModificarProducto(idProducto,productoModificado);
        return RedirectToAction("ListaProductos");

    }
    [HttpGet]
    public IActionResult EliminarProducto(int idProducto)
    {
        _productoRepository.eliminarProducto(idProducto);
        return RedirectToAction("ListaProductos");
    }
}