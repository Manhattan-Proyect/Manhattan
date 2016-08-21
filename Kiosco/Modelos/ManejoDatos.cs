using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace Kiosco.Modelos
{
    class ManejoDatos
    {
        private MySqlConnectionStringBuilder builder;
        internal string nombre_tabla = "";

        private AccesoDatos acceso; 

        public string getNombreTabla()
        {
            return nombre_tabla;
        }

        public string Nombre_tabla
        {
            get
            {
                return nombre_tabla;
            }

            set
            {
                nombre_tabla = value;
            }
        }

        internal AccesoDatos Acceso
        {
            get
            {
                return acceso;
            }
            set
            {
                acceso = value;
            }

        }

        public ManejoDatos(string nombre_tabla)
        {
            //cadena_conexion();
            //this.nombre_tabla = nombre_tabla;
            acceso = new AccesoDatos(cadena_conexion(), nombre_tabla);
        }

        public String cadena_conexion()
        {
            //DBName = "Base";
            //Cmd = new MySqlCommand();

            builder = new MySqlConnectionStringBuilder();
            builder.Server = "sql7.freemysqlhosting.net";
            builder.Port = 3306;
            builder.Database = "sql7131578";
            builder.UserID = "sql7131578";
            builder.Password = "gWp4zNiMY9";

            return builder.ToString();
        }
    }
}
