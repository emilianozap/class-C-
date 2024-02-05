using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using entrega1.modelo;

namespace entrega1.dataBase
{
    public class UsuarioData
    {
        private string stringConnection;

        public UsuarioData()
        {
            this.stringConnection = "Server=ZAPATA;Database=coderhouse;Trusted_Connection=True;";
        }


        public Usuario ObtenerUsuario(int id)
        {
            using (SqlConnection connection = new SqlConnection(this.stringConnection))
            {

                string query = "SELECT * FROM Usuario where id = @id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("id", id);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    int idObtenido = Convert.ToInt32(reader["id"]);
                    string nombre = reader.GetString(1);
                    string apellido = reader.GetString(2);
                    string nombreUsuario = reader.GetString(3);
                    string contrasena = reader.GetString(4);
                    string email = reader.GetString(5);

                    Usuario usuario = new Usuario(id, nombre, apellido, nombreUsuario, contrasena, email);

                    return usuario;
                }

                throw new Exception("Id no econtrado");


            }


        }
        public bool CrearUsuario(Usuario usuario)
        {
            using (SqlConnection connection = new SqlConnection(this.stringConnection))
            {
                string query = "INSERT INTO Usuario (Nombre,Apellido,NombreUsuario,Contraseña,Mail) values (@nombre,@apellido,@nombreUsuario,@password,@email); select @@IDENTITY as ID";

                SqlCommand command = new SqlCommand(query, connection);


                command.Parameters.AddWithValue("nombre", usuario.Nombre);
                command.Parameters.AddWithValue("apellido", usuario.Apellido);
                command.Parameters.AddWithValue("nombreUsuario", usuario.NombreUsuario);
                command.Parameters.AddWithValue("password", usuario.Contrasena);
                command.Parameters.AddWithValue("email", usuario.Mail);
                connection.Open();

                return command.ExecuteNonQuery() > 0;


            }

        }


        public bool EliminarUsuario(int id)
        {
            using (SqlConnection connection = new SqlConnection(this.stringConnection))
            {
                string query = "DELETE FROM Usuario WHERE id = @id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("id", id);

                connection.Open();
                return command.ExecuteNonQuery() > 0;

            }

        }

        public bool ModificarUsuario(int id, Usuario usuario)
        {
            using (SqlConnection connection = new SqlConnection(this.stringConnection))
            {
                string query = "UPDATE Usuario SET Nombre = @nombre,Apellido = @apellido,NombreUsuario = @nombreUsuario,Contraseña= @contrasena,Mail=@mail WHERE id = @id ";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("id", id);
                command.Parameters.AddWithValue("nombre", usuario.Nombre);
                command.Parameters.AddWithValue("apellido", usuario.Apellido);
                command.Parameters.AddWithValue("nombreUsuario", usuario.NombreUsuario);
                command.Parameters.AddWithValue("contrasena", usuario.Contrasena);
                command.Parameters.AddWithValue("mail", usuario.Mail);
                connection.Open();
                return command.ExecuteNonQuery() > 0;

            }

        }


    }
}
