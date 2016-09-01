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
        private Producto prod = new Producto();
        private int cantidad;
        private Ticket tick = new Ticket();
        

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

        internal Producto Prod
        {
            get { return prod; }

            set { prod = value; }
        }

        public int Cantidad
        {
            get { return cantidad; }

            set { cantidad = value; }
        }

        internal Ticket Tick
        {
            get { return tick; }

            set { tick = value; }
        }


        // Constructors
        public Venta()
        {
            DBName = "ventas";
        }

        public Venta(int id, DateTime fecha, Producto prod, int cantidad, Ticket tick)
        {
            this.id = id;
            this.fecha = fecha;
            this.prod = prod;
            this.cantidad = cantidad;
            this.tick = tick;
        }

        public override string getColumnas()
        {
            throw new NotImplementedException();
        }

        public override string toString()
        {
            throw new NotImplementedException();
        }

        public override string getActualizar(Base objeto)
        {
            throw new NotImplementedException();
        }
    }
}
