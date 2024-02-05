using entrega1.dataBase;
using entrega1.modelo;

namespace entrega1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UsuarioData usuario = new UsuarioData();
            try
            {

                //Usuario usuarioObtenido = usuario.ObtenerUsuario(1);
                //Console.WriteLine(usuarioObtenido.ToString());

                //Usuario usuarioNuevo = new Usuario(12, "pepe", "papo", "pp", "asaddf", "pp@gmail.com");
                //if (usuario.CrearUsuario(usuarioNuevo))
                //{
                //    Console.WriteLine("usuario agregado");

                //}

                //if (usuario.EliminarUsuario(2))
                //{
                //    Console.WriteLine("usuario eliminado");
                //}



                Usuario usuarioModificado = new Usuario(4, "alex", "suarez", "Asiarez ", "123456", "alex@mail.com");
                if (usuario.ModificarUsuario(4, usuarioModificado))
                {
                    Console.WriteLine("usuario modificado");
                }




            }

            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }




            Console.WriteLine("Hello, World!");
        }

    }
}
