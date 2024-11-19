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
    public ActionResult altaCliente(int idCliente)
    {
        return View(new ClienteViewModel(idCliente));
    }
    [HttpPost]
    public ActionResult altaCliente(ClienteViewModel clienteVM)
    {
        if(!ModelState.IsValid) return RedirectToAction("altaCliente");
        var nuevoCliente = new Clientes(clienteVM.IdCliente,clienteVM.Nombre,clienteVM.Email,clienteVM.Telefono);
        _clienteRepository.altaCliente(nuevoCliente);
        return RedirectToAction("listarClientes");
    }
    [HttpGet]
    public ActionResult modificarCliente(int idCliente)
    {
        var clienteModificar = _clienteRepository.clientePorId(idCliente);
        return View(new ClienteViewModel(clienteModificar.IdCliente,clienteModificar.Nombre,clienteModificar.Email,clienteModificar.Telefono));
    }
    [HttpPost]
    public ActionResult modificarCliente(ClienteViewModel cliente)
    {
        var clienteModificar = new Clientes(cliente.IdCliente,cliente.Nombre,cliente.Email,cliente.Telefono); 
        _clienteRepository.modificarCliente(clienteModificar.IdCliente, clienteModificar);
        return RedirectToAction("listarClientes");
    }
    [HttpGet]
    public ActionResult eliminarCliente(int idCliente)
    {
        _clienteRepository.eliminarCliente(idCliente);
        return RedirectToAction("ListaClientes");
    }
}