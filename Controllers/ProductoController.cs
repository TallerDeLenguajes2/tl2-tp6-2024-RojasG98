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
        int ultimoId = _productoRepository.listarProductos().Last().IDProductos;
        return View(new ProductoViewModel(ultimoId));
    }
    [HttpPost]
    public IActionResult CrearProducto(ProductoViewModel ProductoVM)
    {
        if(!ModelState.IsValid) return RedirectToAction("CrearProducto");
        var nuevoProducto = new Productos(ProductoVM.idProducto,ProductoVM.descripcion,ProductoVM.precio);
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
    public IActionResult ModificarProducto(Productos productoModificado)
    {
        _productoRepository.ModificarProducto(productoModificado.IDProductos,productoModificado);
        return RedirectToAction("ListaProductos");

    }
    [HttpGet]
    public IActionResult EliminarProducto(int idProducto)
    {
        _productoRepository.eliminarProducto(idProducto);
        return RedirectToAction("ListaProductos");
    }
}