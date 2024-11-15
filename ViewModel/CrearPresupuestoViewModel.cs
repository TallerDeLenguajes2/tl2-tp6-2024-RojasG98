public class CrearPresupuestoViewModel
{
    private Presupuestos presupuesto;
    private List<Clientes> clientes;
    private int idCliente;
    public CrearPresupuestoViewModel(Presupuestos presupuesto, List<Clientes> listaClientes)
    {
        this.presupuesto = presupuesto;
        this.clientes = listaClientes;
    }

    public List<Clientes> Clientes { get => clientes; set => clientes = value; }
    public Presupuestos Presupuesto { get => presupuesto; set => presupuesto = value; }
    public int IdCliente { get => idCliente; set => idCliente = value; }
}