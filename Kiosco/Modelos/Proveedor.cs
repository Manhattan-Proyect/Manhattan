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
        // Properties
        private int id;
        private string descripcion;
        private string contacto;
        private string observacion;

        // Getters and Setters
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

        public string Contacto
        {
            get { return contacto; }

            set { contacto = value; }
        }

        public string Observacion
        {
            get { return observacion; }

            set { observacion = value; }
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

        public Proveedor(int id, string descripcion, string contacto, string observacion)
        {
            this.id = id;
            this.descripcion = descripcion;
            this.contacto = contacto;
            this.observacion = observacion;
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
