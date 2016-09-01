using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kiosco.Modelos
{
    class Proveedor : Base
    {
        //// Properties
        //private int id;
        private string descripcion;
        private double contacto;
        private string visita;
        private string observacion;

        // Getters and Setters
        //public int Id
        //{
        //    get { return id; }
        //    set { id = value; }
        //}
        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        public double Contacto
        {
            get { return contacto; }

            set { contacto = value; }
        }

        public string Observacion
        {
            get { return observacion; }

            set { observacion = value; }
        }

        public string Visita
        {
            get { return visita; }

            set { visita = value; }
        }

        // Constructors
        public Proveedor()
        {
            DBName = "proveedores";
        }

        public Proveedor(int id)
        {
            DBName = "proveedores";
            if (!SelectById(id))
            {
                return;
            }
            DataRow datos = RegistroDB;
            Id = Convert.ToInt32(datos["id"]);
            Descripcion = datos["descripcion"].ToString();
        }

        public Proveedor(int id, string descripcion, double contacto, string visita, string observacion)
        {
            DBName = "proveedores";
            Id = id;
            this.descripcion = descripcion;
            this.contacto = contacto;
            this.visita = visita;
            this.observacion = observacion;
        }

        public Proveedor(string descripcion, double contacto, string visita, string observacion)
        {
            DBName = "proveedores";
            this.descripcion = descripcion;
            this.contacto = contacto;
            this.visita = visita;
            this.observacion = observacion;
        }

        public override string getColumnas()
        {
            return "id,descripcion,contacto,visita,observacion";
        }

        public override string toString()
        {
            return Id + ",'" + Descripcion + "', " + Contacto + ", '" + Visita + "', '" + Observacion +"'";
        }

        public override string getActualizar(Base objeto)
        {
            throw new NotImplementedException();
        }
    }
}
