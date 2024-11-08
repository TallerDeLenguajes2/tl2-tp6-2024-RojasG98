

using Microsoft.Data.Sqlite;

public class PresupuestoRepository : IPresupuestoRepository
{
    private string connectionString = "Data Source=dataBase/Tienda.db;Cache=Shared";

    public void CrearPresupuesto(Presupuestos presupuesto)
    {
        var queryString = $"INSERT INTO Presupuestos (idPresupuesto,NombreDestinatario,FechaCreacion) VALUES (@id,@nombre,@fecha);";
        using (SqliteConnection connection = new SqliteConnection(connectionString))
        {
            connection.Open();
            var command = new SqliteCommand(queryString, connection);
            command.Parameters.Add(new SqliteParameter("@id", presupuesto.IdPresupuesto));
            command.Parameters.Add(new SqliteParameter("@nombre", presupuesto.NombreDestinatario));
            command.Parameters.Add(new SqliteParameter("@fecha", DateTime.Now.ToString("yyyy-M-d")));
            command.ExecuteNonQuery();
            connection.Close();
        }
    }

    public void eliminarPresupuesto(int idPresupuesto)
    {
        SqliteConnection connection = new SqliteConnection(connectionString);
        SqliteCommand command = connection.CreateCommand();
        command.CommandText = $"DELETE FROM PresupuestosDetalle WHERE idPresupuesto = @idSolicitado;";
        command.Parameters.Add(new SqliteParameter("@idSolicitado", idPresupuesto));
        connection.Open();
        command.ExecuteNonQuery();
        connection.Close();
        command.CommandText = $"DELETE FROM Presupuestos WHERE idPresupuesto = @idSolicitado;";
        connection.Open();
        command.ExecuteNonQuery();
        connection.Close();
    }

    public List<Presupuestos> listarPresupuestos()
    {
        SqliteConnection connection = new SqliteConnection(connectionString);
        var presupuestos = new List<Presupuestos>();
        SqliteCommand command = connection.CreateCommand();
        command.CommandText = "SELECT * FROM Presupuestos LEFT JOIN (PresupuestosDetalle INNER JOIN Productos USING(idProducto))USING(idPresupuesto)";
        connection.Open();
        using (SqliteDataReader reader = command.ExecuteReader())
        {
            while (reader.Read())
            {
                var presupuesto = new Presupuestos();

                presupuesto.IdPresupuesto = Convert.ToInt32(reader["idPresupuesto"]);
                presupuesto.NombreDestinatario = reader["NombreDestinatario"].ToString();

                var detalle = new PresupuestosDetalle();
                if (reader["Cantidad"] != DBNull.Value && reader["idProducto"] != DBNull.Value)
                {
                    detalle.Cantidad = Convert.ToInt32(reader["Cantidad"]);
                    detalle.Producto = new Productos(Convert.ToInt32(reader["idProducto"]),reader["Descripcion"].ToString(),Convert.ToInt32(reader["Precio"])); 
                }

                var presupuestoExiste = presupuestos.Find(x => x.IdPresupuesto == Convert.ToInt32(reader["idPresupuesto"]));
                if (presupuestoExiste != null)
                {
                    presupuestoExiste.Detalle.Add(detalle);
                }
                else
                {
                    if (detalle != null)
                    {
                        presupuesto.Detalle = new List<PresupuestosDetalle>();
                        presupuesto.Detalle.Add(detalle);
                    }
                    presupuestos.Add(presupuesto);
                }
            }
        }
        connection.Close();
        return presupuestos;
    }

    public void agregarProducto(int idPresupuesto, int idProducto, int cantidad)
    {
        SqliteConnection connection = new SqliteConnection(connectionString);
        SqliteCommand command = connection.CreateCommand();
        command.CommandText = $"INSERT INTO PresupuestosDetalle (idPresupuesto,idProducto,Cantidad) VALUES (@idPresupuesto,@idProducto,@Cantidad);";
        command.Parameters.Add(new SqliteParameter("@idPresupuesto", idPresupuesto));
        command.Parameters.Add(new SqliteParameter("@idProducto", idProducto));
        command.Parameters.Add(new SqliteParameter("@Cantidad", cantidad));
        connection.Open();
        command.ExecuteNonQuery();
        connection.Close();
    }

    public Presupuestos presupuestoPorId(int idPresupuesto)
    {
        SqliteConnection connection = new SqliteConnection(connectionString);
        var presupuesto = new Presupuestos();
        SqliteCommand command = connection.CreateCommand();
        command.CommandText = "SELECT * FROM Presupuestos AS p INNER JOIN (PresupuestosDetalle as pd INNER JOIN Productos as pr USING(idProducto))USING(idPresupuesto)WHERE idPresupuesto = @idPresupuesto;";
        command.Parameters.Add(new SqliteParameter("@idPresupuesto", idPresupuesto));
        connection.Open();
        using (SqliteDataReader reader = command.ExecuteReader())
        {
            var detalles = new List<PresupuestosDetalle>();
            while (reader.Read())
            {
                presupuesto.IdPresupuesto = Convert.ToInt32(reader["idPresupuesto"]);
                presupuesto.NombreDestinatario = reader["NombreDestinatario"].ToString();
                var detalle = new PresupuestosDetalle();
                var producto = new Productos();
                producto.IDProductos = Convert.ToInt32(reader["idProducto"]);
                producto.Descripcion = reader["Descripcion"].ToString();
                producto.Precio = Convert.ToInt32(reader["Precio"]);
                detalle.Producto = producto;
                detalle.Cantidad = Convert.ToInt32(reader["Cantidad"]);
                detalles.Add(detalle);
            }
            presupuesto.Detalle = detalles;
        }
        connection.Close();
        return presupuesto;
    }
}