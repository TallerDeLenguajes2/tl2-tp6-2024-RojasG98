

public interface IProductoRepository
{
    public Productos productoPorId(int idProducto);
    public List<Productos> listarProductos();
    public void CrearProducto(Productos producto);
    public void eliminarProducto(int idProducto);
    public void ModificarProducto(int idProducto, Productos productos);
}