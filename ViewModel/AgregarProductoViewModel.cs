public class AgregarProductoViewModel
{
    private int idProducto;
    private int idPresupuesto;
    private int cantidad;
    private List<Productos> listaProductos;
    public AgregarProductoViewModel(){}
    public AgregarProductoViewModel(int idPresupuesto)
    {
        this.idPresupuesto = idPresupuesto;
    }
    public AgregarProductoViewModel(int idPresupuesto,List<Productos> listaProductos)
    {
        this.idPresupuesto = idPresupuesto;
        this.ListaProductos = listaProductos;

    }
    public AgregarProductoViewModel(Presupuestos presupuesto, PresupuestosDetalle detalle,List<Productos> listaProductos)
    {
        idPresupuesto = presupuesto.IdPresupuesto;
        idProducto = detalle.Producto.IDProductos;
        cantidad = detalle.Cantidad;
        this.ListaProductos = listaProductos;
    }

    public int IdProducto { get => idProducto; set => idProducto = value; }
    public int IdPresupuesto { get => idPresupuesto; set => idPresupuesto = value; }
    public int Cantidad { get => cantidad; set => cantidad = value; }
    public List<Productos> ListaProductos { get => listaProductos; set => listaProductos = value; }
}