using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kiosco.Modelos
{
    class Ticket : Base
    {
        private int id;
        private DateTime fecha;


        //Constructores
        public Ticket()
        {
            DBName = "tickets";
        }

        public Ticket(int id, DateTime fecha)
        {
            this.id = id;
            this.fecha = fecha;
        }


        //Getter and Setters
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

        public override string getColumnas()
        {
            throw new NotImplementedException();
        }

        public override string toString()
        {
            throw new NotImplementedException();
        }
    }
}
