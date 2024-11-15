using Microsoft.AspNetCore.Mvc;
namespace tl2_tp6_2024_RojasG98.Controllers;
public class ClienteController : Controller
{
    private readonly IClienteRepository _clienteRepository;

    public ClienteController(IClienteRepository clienteRepository)
    {
        _clienteRepository = clienteRepository;
    }
    [HttpGet]
    public ActionResult<List<Clientes>> listarClientes()
    {
        var clientes = _clienteRepository.listarClientes();
        return View(clientes);
    }
    [HttpGet]
    public ActionResult altaCliente()
    {
        return View(new Clientes());
    }
    [HttpPost]
    public ActionResult altaCliente(Clientes nuevoCliente)
    {
        _clienteRepository.altaCliente(nuevoCliente);
        return RedirectToAction("ListaClientes");
    }
    [HttpGet]
    public ActionResult modificarCliente(int idCliente)
    {
        var clienteModificar = _clienteRepository.clientePorId(idCliente);
        return View(clienteModificar);
    }
    [HttpPost]
    public ActionResult modificarCliente(Clientes clienteModificar)
    {
        _clienteRepository.modificarCliente(clienteModificar.IdCliente, clienteModificar);
        return RedirectToAction("ListaClientes");
    }
    [HttpGet]
    public ActionResult eliminarCliente(int idCliente)
    {
        _clienteRepository.eliminarCliente(idCliente);
        return RedirectToAction("ListaClientes");
    }
}