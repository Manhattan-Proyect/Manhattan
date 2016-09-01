using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;


namespace Kiosco.Modelos
{
    class AccesoDatos
    {
        private MySqlConnectionStringBuilder builder;
        private String nombre_tabla = "";

        private MySqlConnection conexion = new MySqlConnection();
        private MySqlCommand cmd = new MySqlCommand();

        private DataTable tabla;

        public AccesoDatos(string nombre_tabla)
        {
            //this.cadena_conexion = cadena_conexion;
            this.nombre_tabla = nombre_tabla;
            cadena_conexion();
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


        //public string Cadena_conexion
        //{
        //    get
        //    {
        //        return cadena_conexion;
        //    }

        //    set
        //    {
        //        cadena_conexion = value;
        //    }
        //}

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
            conexion.ConnectionString = builder.ToString();

            try
            {
                conexion.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectar a la base de datos: " + ex.ToString());
            }

            

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

        public void insertar(String txt_sql, String restriccion)
        {
            abm(txt_sql + " WHERE " + restriccion);
        }


    }
}
