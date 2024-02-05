using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entrega1.modelo
{
    internal class ProductoVendido
    {
        private int id;
        private int idProducto;
        private int stock;
        private int idVenta;

        public ProductoVendido(int id, int idProducto, int stock, int idVenta)
        {
            this.id = id;
            this.idProducto = idProducto;
            this.stock = stock;
            this.idVenta = idVenta;
        }

        public int Id { get => id; set => id = value; }
        public int IdProducto { get => idProducto; set => idProducto = value; }
        public int Stock { get => stock; set => stock = value; }
        public int IdVenta { get => idVenta; set => idVenta = value; }
    }
