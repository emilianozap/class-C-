using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using entrega1.modelo;

namespace entrega1.dataBase
{
    public class ProductoData
    {
        private string stringConnection;

        public ProductoData()
        {
            this.stringConnection = "Server=ZAPATA;Database=coderhouse;Trusted_Connection=True;";
        }


        public ProductoVendido ObtenerProducto(int id)
        {
            using (SqlConnection connection = new SqlConnection(this.stringConnection))
            {
                string query = "SELECT * FROM Producto where id = @id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", id);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    int idObtenido = Convert.ToInt32(reader["id"]);
                    string descripcion = Convert.ToString(reader["descripcion"]);
                    double costo = Convert.ToInt32(reader["costo"]);
                    double precioVenta = Convert.ToInt32(reader["precioVenta"]);
                    int stock = Convert.ToInt32(reader["stock"]);
                    int idUsuario = Convert.ToInt32(reader["idUsuario"]);

                    Producto producto = new Producto(idObtenido, descripcion, costo, precioVenta, stock, idUsuario);

                    return producto;
                }

                throw new Exception("Id no encontrado");
            }
        }



        public bool CrearProducto(Producto producto)
        {
            using (SqlConnection connection = new SqlConnection(this.stringConnection))
            {
                string query = "INSERT INTO Producto (id, idProducto, stock,idVenta) values (@id,@idProducto,@stock,@idVenta); select @@IDENTITY as ID";

                SqlCommand command = new SqlCommand(query, connection);


                command.Parameters.AddWithValue("idObtenido", productoVendido.Id);
                command.Parameters.AddWithValue("idProducto", productoVendido.IdProducto);
                command.Parameters.AddWithValue("stock", productoVendido.Stock);
                command.Parameters.AddWithValue("idVenta", productoVendido.IdVenta);

                connection.Open();

                return command.ExecuteNonQuery() > 0;


            }

        }


        public bool EliminarProductoVendido(int id)
        {
            using (SqlConnection connection = new SqlConnection(this.stringConnection))
            {
                string query = "DELETE FROM ProductoVendido WHERE id = @id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("id", id);

                connection.Open();
                return command.ExecuteNonQuery() > 0;

            }

        }


        public bool ModificarProductoVendido(int id, ProductoVendido productoVendido)
        {
            using (SqlConnection connection = new SqlConnection(this.stringConnection))
            {
                string query = "UPDATE ProductoVendido SET idProducto = @idProducto, stock = @stock, idVenta = @idVenta WHERE id = @id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", id); // Parámetro para el ID actual
                command.Parameters.AddWithValue("@idProducto", productoVendido.IdProducto);
                command.Parameters.AddWithValue("@stock", productoVendido.Stock);
                command.Parameters.AddWithValue("@idVenta", productoVendido.IdVenta);

                connection.Open();
                return command.ExecuteNonQuery() > 0;
            }
        }




    }
}
