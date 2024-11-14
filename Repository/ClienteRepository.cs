
using Microsoft.Data.Sqlite;

class ClienteRepository : IClienteRepository
{
    private string connectionString = "Data Source=dataBase/Tienda.db;Cache=Shared";
    public void altaCliente(Clientes clienteNuevo)
    {
        var queryString = $"INSERT INTO Clientes (idCliente,Nombre,Email,Telefono) VALUES (@id,@nombre,@mail,@telefono);";
        using (SqliteConnection connection = new SqliteConnection(connectionString))
        {
            connection.Open();
            var command = new SqliteCommand(queryString, connection);
            command.Parameters.Add(new SqliteParameter("@id", clienteNuevo.IdCliente));
            command.Parameters.Add(new SqliteParameter("@nombre", clienteNuevo.Nombre));
            command.Parameters.Add(new SqliteParameter("@mail",clienteNuevo.Email));
            command.Parameters.Add(new SqliteParameter("@telefono",clienteNuevo.Telefono));
            command.ExecuteNonQuery();
            connection.Close();
        }
    }

    public Clientes clientePorId(int idCliente)
    {
        SqliteConnection connection = new SqliteConnection(connectionString);
        var cliente = new Clientes();
        SqliteCommand command = connection.CreateCommand();
        command.CommandText = @"
        SELECT *
        FROM Clientes
        WHERE idCliente = @idClienteBuscado;
        ";
        command.Parameters.Add(new SqliteParameter("@idClienteBuscado", idCliente));
        connection.Open();
        using (SqliteDataReader reader = command.ExecuteReader())
        {
            while (reader.Read())
            {
                if (reader["idCliente"] != DBNull.Value)
                {
                    cliente.IdCliente = Convert.ToInt32(reader["idCliente"]);
                    cliente.Nombre = reader["Nombre"].ToString();
                    cliente.Email = reader["Email"].ToString();
                    cliente.Telefono = reader["Telefono"].ToString();
                }

            }
        }
        connection.Close();
        return cliente;
    }

    public void eliminarCliente(int idCliente)
    {
        SqliteConnection connection = new SqliteConnection(connectionString);
        SqliteCommand command = connection.CreateCommand();
        command.CommandText = $"DELETE FROM Presupuestos WHERE idClientes = @idClienteEliminar;";
        command.Parameters.Add(new SqliteParameter("@idClienteElimar", idCliente));
        connection.Open();
        command.ExecuteNonQuery();
        connection.Close();
        command.CommandText = $"DELETE FROM Clientes WHERE idCliente = @idClienteEliminar;";
        connection.Open();
        command.ExecuteNonQuery();
        connection.Close();
    }

    public List<Clientes> listarClientes()
    {
        SqliteConnection connection = new SqliteConnection(connectionString);
        var clientes = new List<Clientes>();
        SqliteCommand command = connection.CreateCommand();
        command.CommandText = "SELECT * FROM Clientes;";
        connection.Open();
        using (SqliteDataReader reader = command.ExecuteReader())
        {
            while (reader.Read())
            {
                var cliente = new Clientes();
                cliente.IdCliente = Convert.ToInt32(reader["idCliente"]);
                cliente.Nombre = reader["Nombre"].ToString();
                cliente.Email = reader["Email"].ToString();
                cliente.Telefono = reader["Telefono"].ToString();
                clientes.Add(cliente);
            }
        }
        connection.Close();
        return clientes;
    }

    public void modificarCliente(int idCliente, Clientes cliente)
    {
        SqliteConnection connection = new SqliteConnection(connectionString);
        SqliteCommand command = connection.CreateCommand();
        command.CommandText = @"UPDATE Productos 
                                SET Nombre = @nombre, Email = @Email, Telefono = @Telefono 
                                WHERE idCliente = @idClienteModificar;";
        command.Parameters.Add(new SqliteParameter("@idClienteModificar", idCliente));
        command.Parameters.Add(new SqliteParameter("@nombre", cliente.Nombre));
        command.Parameters.Add(new SqliteParameter("@Email", cliente.Email));
        command.Parameters.Add(new SqliteParameter("@Telefono", cliente.Telefono));
        connection.Open();
        command.ExecuteNonQuery();
        connection.Close();
    }
}