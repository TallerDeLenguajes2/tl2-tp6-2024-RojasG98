using System.ComponentModel.DataAnnotations;
public class ClienteViewModel
{
    public ClienteViewModel(int IdCliente,string Nombre,string Email,string Telefono)
    {
        this.IdCliente = IdCliente;
        this.Nombre = Nombre;
        this.Email = Email;
        this.Telefono = Telefono;
    }

    public ClienteViewModel(int ultimoId)
    {
        IdCliente = ultimoId;
    }

    public ClienteViewModel()
    {
    }

    public int IdCliente { get; set; }
    [Required][StringLength(100)]
    public string Nombre { get; set; }
    [EmailAddress]
    public string Email { get; set; }
    [Phone]
    public string Telefono { get; set; }
}