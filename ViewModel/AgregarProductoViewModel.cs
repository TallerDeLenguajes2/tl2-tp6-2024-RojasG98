public class AgregarProductoViewModel
{
    private int idProducto;
    private int idPresupuesto;
    private int cantidad;
    public AgregarProductoViewModel(){}
    public AgregarProductoViewModel(int idPresupuesto)
    {
        this.idPresupuesto = idPresupuesto;
    }
    public AgregarProductoViewModel(Presupuestos presupuesto, PresupuestosDetalle detalle)
    {
        idPresupuesto = presupuesto.IdPresupuesto;
        idProducto = detalle.Producto.IDProductos;
        cantidad = detalle.Cantidad;
    }

    public int IdProducto { get => idProducto; set => idProducto = value; }
    public int IdPresupuesto { get => idPresupuesto; set => idPresupuesto = value; }
    public int Cantidad { get => cantidad; set => cantidad = value; }
}