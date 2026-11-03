
using System;

namespace XELASOPORTE
{
    public class Repuesto
    {
        private string codigo;
        private string nombre;
        private string categoria;
        private int existencia;
        private int stockMinimo;
        private double costoCompra;
        private double precioVenta;

        public string Codigo { get { return codigo; } }
        public string Nombre { get { return nombre; } }
        public string Categoria { get { return categoria; } }
        public int Existencia { get { return existencia; } }
        public int StockMinimo { get { return stockMinimo; } }
        public double CostoCompra { get { return costoCompra; } }
        public double PrecioVenta { get { return precioVenta; } }

        public Repuesto(string codigo, string nombre, string categoria,
            int existencia, int stockMinimo, double costoCompra,
            double precioVenta)
        {
            this.codigo = codigo;
            this.nombre = nombre;
            this.categoria = categoria;
            this.existencia = existencia;
            this.stockMinimo = stockMinimo;
            this.costoCompra = costoCompra;
            this.precioVenta = precioVenta;
        }

        public bool UtilizarRepuesto(int cantidad)
        {
            if (cantidad > 0 && cantidad <= existencia)
            {
                existencia -= cantidad;
                return true;
            }

            return false;
        }

        public bool RegistrarEntrada(int cantidad)
        {
            if (cantidad > 0)
            {
                existencia += cantidad;
                return true;
            }

            return false;
        }

        public bool TieneStockBajo()
        {
            return existencia <= stockMinimo;
        }

        public void MostrarInformacion()
        {
            Console.WriteLine("Codigo: " + codigo);
            Console.WriteLine("Nombre: " + nombre);
            Console.WriteLine("Categoria: " + categoria);
            Console.WriteLine("Existencia: " + existencia);
            Console.WriteLine("Stock minimo: " + stockMinimo);
            Console.WriteLine("Costo de compra: Q" + costoCompra);
            Console.WriteLine("Precio de venta: Q" + precioVenta);

            if (TieneStockBajo())
                Console.WriteLine("ADVERTENCIA: Stock bajo.");
        }
    }
}
