public interface IUserRepository
{
    public User getUsuario(string usuario, string contrasenia);
    public void crearUsuario(User usuario);
}