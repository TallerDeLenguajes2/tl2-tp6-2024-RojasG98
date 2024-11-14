public interface IClienteRepository
{
    public Clientes clientePorId(int idCliente);
    public List<Clientes> listarClientes();
    public void altaCliente(Clientes clienteNuevo);
    public void eliminarCliente(int idCliente);
    public void modificarCliente(int idCliente, Clientes cliente);
}