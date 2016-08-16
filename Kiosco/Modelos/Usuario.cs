using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kiosco.Modelos
{
    class Usuario : Base
    {
        // Properties
        private int id;
        private string nombre;
        private string password;
        private int permiso;

        // Getters and Setters
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        public int Permiso
        {
            get { return permiso; }
            set { permiso = value; }
        }

        // Constructors
        public Usuario()
        {
            this.DBName = "usuarios";
        }
    }
}
