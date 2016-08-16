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
    }
}
