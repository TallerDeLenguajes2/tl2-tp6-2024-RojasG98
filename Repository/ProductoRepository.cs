using Microsoft.Data.Sqlite;

public class ProductoRepository : IProductoRepository
{
    private string connectionString = "Data Source=dataBase/Tienda.db;Cache=Shared";
    public Productos productoPorId(int idProducto)
    {
        SqliteConnection connection = new SqliteConnection(connectionString);
        var producto = new Productos();
        SqliteCommand command = connection.CreateCommand();
        command.CommandText = "SELECT * FROM Productos WHERE idProducto = @idProducto;";
        command.Parameters.Add(new SqliteParameter("@idProducto", idProducto));
        connection.Open();
        using (SqliteDataReader reader = command.ExecuteReader())
        {
            while (reader.Read())
            {
                producto.IDProductos = Convert.ToInt32(reader["idProducto"]);
                producto.Descripcion = reader["Descripcion"].ToString();
                producto.Precio = Convert.ToInt32(reader["Precio"]);
            }
        }
        connection.Close();
        return producto;
    }
    public List<Productos> listarProductos()
    {
        SqliteConnection connection = new SqliteConnection(connectionString);
        var productos = new List<Productos>();
        SqliteCommand command = connection.CreateCommand();
        command.CommandText = "SELECT * FROM Productos;";
        connection.Open();
        using (SqliteDataReader reader = command.ExecuteReader())
        {
            while (reader.Read())
            {
                var producto = new Productos();
                producto.IDProductos = Convert.ToInt32(reader["idProducto"]);
                producto.Descripcion = reader["Descripcion"].ToString();
                producto.Precio = Convert.ToInt32(reader["Precio"]);
                productos.Add(producto);
            }
        }
        connection.Close();
        return productos;
    }
    public void CrearProducto(Productos producto)
    {
        var queryString = $"INSERT INTO Productos (idProducto,Descripcion,Precio) VALUES (@id,@descripcion,@precio);";
        using (SqliteConnection connection = new SqliteConnection(connectionString))
        {
            connection.Open();
            var command = new SqliteCommand(queryString, connection);
            command.Parameters.Add(new SqliteParameter("@id", producto.IDProductos));
            command.Parameters.Add(new SqliteParameter("@descripcion", producto.Descripcion));
            command.Parameters.Add(new SqliteParameter("@precio", producto.Precio));
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
    public void eliminarProducto(int idProducto)
    {
        SqliteConnection connection = new SqliteConnection(connectionString);
        SqliteCommand command = connection.CreateCommand();
        command.CommandText = $"DELETE FROM Productos WHERE idProducto = @idSolicitado;";
        command.Parameters.Add(new SqliteParameter("@idSolicitado", idProducto));
        connection.Open();
        command.ExecuteNonQuery();
        connection.Close();
    }
    public void ModificarProducto(int idProducto, Productos productos)
    {
        SqliteConnection connection = new SqliteConnection(connectionString);
        SqliteCommand command = connection.CreateCommand();
        command.CommandText = $"UPDATE Productos SET Descripcion = @descripcion, Precio = @precio WHERE idProducto = @idSolicitado;";
        command.Parameters.Add(new SqliteParameter("@idSolicitado", idProducto));
        command.Parameters.Add(new SqliteParameter("@descripcion", productos.Descripcion));
        command.Parameters.Add(new SqliteParameter("@precio", productos.Precio));
        connection.Open();
        command.ExecuteNonQuery();
        connection.Close();
    }
}