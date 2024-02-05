using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using entrega1.modelo;

namespace entrega1.dataBase
{
    public class ProductoVendidoData
    {
        private string stringConnection;

        public ProductoVendidoData()
        {
            this.stringConnection = "Server=ZAPATA;Database=coderhouse;Trusted_Connection=True;";
        }


        public ProductoVendido ObtenerProductoVendido(int id)
        {
            using (SqlConnection connection = new SqlConnection(this.stringConnection))
            {
                string query = "SELECT * FROM ProductoVendido where id = @id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", id);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    int idObtenido = Convert.ToInt32(reader["id"]);
                    int idProducto = Convert.ToInt32(reader["idProducto"]);
                    int stock = Convert.ToInt32(reader["stock"]);
                    int idVenta = Convert.ToInt32(reader["idVenta"]);

                    ProductoVendido productoVendido = new ProductoVendido(idObtenido, idProducto, stock, idVenta);

                    return productoVendido;
                }

                throw new Exception("Id no encontrado");
            }
        }



        public bool CrearProductoVendido(ProductoVendido productoVendido)
        {
            using (SqlConnection connection = new SqlConnection(this.stringConnection))
            {
                string query = "INSERT INTO ProductoVendido (id, idProducto, stock,idVenta) values (@id,@idProducto,@stock,@idVenta); select @@IDENTITY as ID";

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
