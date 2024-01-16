using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentaInformatica
{
    internal class Producto
    {
        private int _id;
        private string _descripcion;
        private double _costo;
        private double _precioVenta;
        private int _stock;
        private int _idUsuario;

        public Producto()
        {
        }
        public Producto(int id, string descripcion, double costo, double precioVenta, int stock, int idUsuario)
        {
            this._id = id;
            this._descripcion = descripcion;
            this._costo = costo;
            this._precioVenta = precioVenta;
            this._stock = stock;
            this._idUsuario = idUsuario;

        }

        public int Id { get { return _id; } set { _id = value; } }
        public string Descripcion { get { return _descripcion; } set { _descripcion = value; } }

        public double Costo { get { return _costo; } set { _costo = value; } }

        public double PrecioVenta { get { return _precioVenta; } set { _precioVenta = value; } }

        public int Stock { get { return _stock; } set { _stock = value; } }

        public int IdUsuario { get { return _idUsuario; } set { _idUsuario = value; } }
    }

}
