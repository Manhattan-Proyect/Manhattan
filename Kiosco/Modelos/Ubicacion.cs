using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kiosco.Modelos
{
    class Ubicacion : Base
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
        public Ubicacion()
        {
            DBName = "ubicaciones";
        }

        public Ubicacion(int id)
        {
            DBName = "ubicaciones";
            if (!SelectById(id))
            {
                return;
            }
            DataRow datos = RegistroDB;
            Id = Convert.ToInt32(datos["id"]);
            Descripcion = datos["descripcion"].ToString();
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
