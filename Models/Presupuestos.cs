public class Presupuestos
{
    private const double IVA = 0.21;
    private int idPresupuesto;
    private Clientes cliente;
    private List<PresupuestosDetalle> detalle;

    public int IdPresupuesto { get => idPresupuesto; set => idPresupuesto = value; }
    public List<PresupuestosDetalle> Detalle { get => detalle; set => detalle = value; }
    public Clientes Cliente { get => cliente; set => cliente = value; }

    public Presupuestos(){}
    public Presupuestos(int idPresupuesto){ this.idPresupuesto = idPresupuesto;}

    public double MontoPresupuesto(){
        double monto = 0;
        foreach (var producto in Detalle)
        {
            monto += producto.Producto.Precio * producto.Cantidad;
        }
        return monto;
    }
    public double MontoPresupuestoConIva(){
        return MontoPresupuesto()*IVA;
    }
    public int CantidadProductos(){
        int cant = 0;
        foreach (var producto in Detalle)
        {
            cant += producto.Cantidad;
        }
        return cant;
    }
}