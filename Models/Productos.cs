public class Productos
{
    private int iDProductos;
    private string descripcion;
    private int precio;
    public Productos(){}

    public Productos(int id, string nombre, int precio){
        IDProductos = id;
        Descripcion = nombre;
        this.precio = precio;
    }

    public int IDProductos { get => iDProductos; set => iDProductos = value; }
    public string Descripcion { get => descripcion; set => descripcion = value; }
    public int Precio { get => precio; set => precio = value; }
}