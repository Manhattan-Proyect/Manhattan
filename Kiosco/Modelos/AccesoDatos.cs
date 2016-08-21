using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;


namespace Kiosco.Modelos
{
    class AccesoDatos
    {
        private String cadena_conexion = "";
        private String nombre_tabla = "";

        private MySqlConnection conexion = new MySqlConnection();
        private MySqlCommand cmd = new MySqlCommand();

        private DataTable tabla;

        public AccesoDatos(string cadena_conexion, string nombre_tabla)
        {
            this.cadena_conexion = cadena_conexion;
            this.nombre_tabla = nombre_tabla;
        }

        public string Cadena_conexion
        {
            get
            {
                return cadena_conexion;
            }

            set
            {
                cadena_conexion = value;
            }
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

        private void conectar()
        {
            conexion.ConnectionString = cadena_conexion;
            conexion.Open();

            cmd.Connection = conexion;
            cmd.CommandType = System.Data.CommandType.Text;
        }

        private DataTable ejecutar(string txt_sql)
        {
            tabla = new DataTable();
            conectar();

            cmd.CommandText = txt_sql;

            tabla.Load(cmd.ExecuteReader());

            desconectar();

            return tabla;
            
        }

        private void desconectar()
        {
            conexion.Close();
        }

        public DataTable consulta(String txt_sql)
        {
            return ejecutar(txt_sql);
        }

        public DataTable leo_tabla(String nombre_tabla)
        {
            return ejecutar("select * from " + nombre_tabla);
        }

        public DataTable leo_tabla(String nombre_tabla, String restriccion)
        {
            return ejecutar("select * from " + nombre_tabla + " where " + restriccion);
        }

        public DataTable leo_tabla()
        {
            return ejecutar("select * from " + nombre_tabla);
        }

        private void abm(String txt_sql)
        {
            conectar();
            cmd.CommandText = txt_sql;
            cmd.ExecuteNonQuery();
            desconectar();
        }

        public void insertar(String txt_sql)
        {
            abm(txt_sql);
        }


    }
}
