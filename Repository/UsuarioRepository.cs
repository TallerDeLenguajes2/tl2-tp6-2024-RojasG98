using Microsoft.Data.Sqlite;
public class UsuarioRepository : IUserRepository
{
    private string connectionString = "Data Source=dataBase/Tienda.db;Cache=Shared";

    public void crearUsuario(User usuario)
    {
        var queryString = $"INSERT INTO Usuarios (idUsuarios,Nombre,Usuario,Contrasenia,Rol) VALUES (@idUsuarios,@Nombre,@Usuario,@Contrasenia,@Rol);";
        using (SqliteConnection connection = new SqliteConnection(connectionString))
        {
            connection.Open();
            var command = new SqliteCommand(queryString, connection);
            command.Parameters.Add(new SqliteParameter("@idUsuarios",usuario.Id));
            command.Parameters.Add(new SqliteParameter("@Nombre",usuario.Name));
            command.Parameters.Add(new SqliteParameter("@Usuario",usuario.Username));
            command.Parameters.Add(new SqliteParameter("@Contrasenia",usuario.Password));
            command.Parameters.Add(new SqliteParameter("@Rol",usuario.AccessLevels));

            command.ExecuteNonQuery();
            connection.Close();
        }
    }

    public User getUsuario(string usuario, string contrasenia)
    {
                SqliteConnection connection = new SqliteConnection(connectionString);
        var user = new User();
        SqliteCommand command = connection.CreateCommand();
        command.CommandText = "SELECT * FROM Usuarios WHERE Usuario = @usuario AND Contrasenia =  @contrasenia;";
        command.Parameters.Add(new SqliteParameter("@usuario", usuario));
        command.Parameters.Add(new SqliteParameter("@contrasenia", contrasenia));
        connection.Open();
        using (SqliteDataReader reader = command.ExecuteReader())
        {
            if (reader.HasRows)
            {
                reader.Read();
                user.Id = Convert.ToInt32(reader["idUsuarios"]);
                user.Name = reader["Nombre"].ToString();
                user.Username = reader["Usuario"].ToString();
                user.Password = reader["Contrasenia"].ToString();
                user.AccessLevels = reader["Rol"].ToString();
            }
            
        }
        connection.Close();
        return user;
    }
}