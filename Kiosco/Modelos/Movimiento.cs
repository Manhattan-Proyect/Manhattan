using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kiosco.Modelos
{
    class Movimiento : Base
    {
        private int id;
        private string descripcion;
        private DateTime fecha;
        private decimal monto;
        private string tipo;

        public Movimiento()
        {
            DBName = "movimientos";
        }

        public Movimiento(int id, string descripcion, DateTime fecha, decimal monto, string tipo)
        {
            this.id = id;
            this.descripcion = descripcion;
            this.fecha = fecha;
            this.monto = monto;
            this.tipo = tipo;
        }

        //Getter and Setters
        public int Id
        {
            get { return id; }

            set { id = value; }
        }

        public string Descripcion
        {
            get { return descripcion; }

            set { descripcion = value; }
        }

        public DateTime Fecha
        {
            get { return fecha; }

            set { fecha = value; }
        }

        public decimal Monto
        {
            get { return monto; }

            set { monto = value; }
        }

        public string Tipo
        {
            get { return tipo; }

            set { tipo = value; }
        }


    }
}
