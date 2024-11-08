public interface IPresupuestoRepository
{
    public Presupuestos presupuestoPorId(int idPresupuesto);
    public List<Presupuestos> listarPresupuestos();
    public void CrearPresupuesto(Presupuestos presupuesto);
    public void eliminarPresupuesto(int idPresupuesto);
    public void agregarProducto(int idPresupuesto, int idProducto, int cantidad);
}