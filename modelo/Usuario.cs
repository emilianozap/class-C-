using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entrega1.modelo
{
    public class Usuario
    {
        private int id;
        private string nombre;
        private string apellido;
        private string nombreUsuario;
        private string contrasena;
        private string mail;

        public Usuario() { }

        public Usuario(int id, string nombre, string apellido, string nombreUsuario, string contrasena, string mail)
        {
            this.id = id;
            this.nombre = nombre;
            this.apellido = apellido;
            this.nombreUsuario = nombreUsuario;
            this.contrasena = contrasena;
            this.mail = mail;
        }

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string NombreUsuario { get => nombreUsuario; set => nombreUsuario = value; }
        public string Contrasena { get => contrasena; set => contrasena = value; }
        public string Mail { get => mail; set => mail = value; }


        public override string ToString()
        {
            return $"nombre: {this.nombre}, apellido: {this.apellido}";
        }
    }


}
