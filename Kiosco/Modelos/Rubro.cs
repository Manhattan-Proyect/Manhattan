using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kiosco.Modelos
{
    class Rubro : Base
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
        public Rubro()
        {
            DBName = "rubros";
        }

        public Rubro(int id)
        {
            DBName = "rubros";
            if (!SelectById(id))
            {
                return;
            }
            DataRow datos = RegistroDB;
            Id = Convert.ToInt32(datos["id"]);
            Descripcion = datos["descripcion"].ToString();
        }

        public Rubro(int id, string descripcion)
        {
            DBName = "rubros";
            this.id = id;
            this.descripcion = descripcion;
        }

        public override string getColumnas()
        {
            return "id,descripcion";
        }

        public override string toString()
        {
            return Id + ",'" + Descripcion +"'";
        }

        public override string getActualizar(Base objeto)
        {
            throw new NotImplementedException();
        }
    }
}
