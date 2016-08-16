using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kiosco.Modelos
{
    class Venta : Base
    {
        // Properties
        private int id;
        private DateTime fecha;
        private decimal ingreso;
        private decimal egreso;
        private decimal total;

        // Getters and Setters
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }
        public decimal Ingreso
        {
            get { return ingreso; }
            set { ingreso = value; }
        }
        public decimal Egreso
        {
            get { return egreso; }
            set { egreso = value; }
        }
        public decimal Total
        {
            get { return total; }
            set { total = value; }
        }

        // Constructors
        public Venta()
        {
            DBName = "ventas";
        }

        public Venta(DateTime _fecha, decimal _ingreso, decimal _egreso, decimal _total)
        {
            DBName = "ventas";
            Fecha = _fecha;
            Ingreso = _ingreso;
            Egreso = _egreso;
            Total = _total;
        }
    }
}
