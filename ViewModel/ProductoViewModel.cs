using System.ComponentModel.DataAnnotations;
public class ProductoViewModel
{
    public ProductoViewModel()
    {
    }

    public ProductoViewModel(int idProducto)
    {
        this.idProducto = idProducto;
    }

    public int idProducto{get; set;}
    [Required] [StringLength(100)] 
    public string descripcion {get; set;}
    [Required][Range(0,999999.99)]
    public int precio {get; set;}
}