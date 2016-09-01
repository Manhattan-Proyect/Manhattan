using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Configuration;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace Kiosco.Modelos
{
    abstract class Base
    {
        private MySqlCommand Cmd;
        private MySqlConnectionStringBuilder Builder;
        private MySqlConnection Connection;
        private MySqlDataReader Reader;
        private string SqlString;
        private DataTable Tabla;
        private DataRow registro;
        private string db_name;
        private int id;

        public string DBName
        {
            get { return db_name; }
            set { this.db_name= value; }
        }

        public DataRow RegistroDB
        {
            get { return registro; }
        }

        public MySqlConnection Connection1
        {
            get
            {
                return Connection;
            }

            set
            {
                Connection = value;
            }
        }

        public int Id
        {
            get { return id; }

            set { id = value; }
        }

        public Base()
        {
            DBName= "Base";
            Cmd = new MySqlCommand();

            Builder = new MySqlConnectionStringBuilder();
            Builder.Server = "sql7.freemysqlhosting.net";
            Builder.Port = 3306;
            Builder.Database = "sql7131578";
            Builder.UserID = "sql7131578";
            Builder.Password = "gWp4zNiMY9";
            
            Connection = new MySqlConnection(Builder.ToString());
        }

        public bool Conectar()
        {
            try
            {
                if (Connection.State.ToString() == "Closed")
                {
                    Connection.Open();
                    //MessageBox.Show("Conectado OK!");
                }
                else
                {
                    MessageBox.Show("Usted ya estaba conectado!");
                }
               
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al conectar a MySQL. " + ex.ToString());
            }
            
            return false;
        }

        public void Desconectar()
        {
            Connection.Close();
        }

        public DataTable SelectAll()
        {
            Tabla = new DataTable();
            Tabla.Rows.Clear();
            SqlString = "SELECT * FROM " + DBName;

            try
            {
                Conectar();
                Cmd.Connection = Connection;
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = SqlString;

                //Tabla.Load(Cmd.ExecuteReader());
                Reader = Cmd.ExecuteReader();
                while (Reader.Read())
                {
                    Tabla.Rows.Add(Reader);
                }
                Desconectar();
                return Tabla;
            }
            catch (MySqlException ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public bool SelectById(int id)
        {
            Tabla = new DataTable();
            Tabla.Rows.Clear();

            SqlString = "SELECT * FROM ";
            SqlString += DBName;
            SqlString += " WHERE id=";
            SqlString += id;

            try
            {
                Conectar();
                Cmd.Connection = Connection;
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = SqlString;

                Tabla.Load(Cmd.ExecuteReader());

                Desconectar();
            }
            catch (MySqlException ex)
            {
                throw new Exception(ex.ToString());
            }
            catch (IndexOutOfRangeException ex)
            {
                throw new Exception(ex.ToString());
            }

            if (Tabla.Rows.Count != 0)
            {
                registro = Tabla.Rows[0];
                return true;
            }

            return false;
        }

        public bool Insert(DataRow datos)
        {
            SqlString = "INSERT INTO ";
            SqlString += DBName;
            SqlString += " (";

            MessageBox.Show(datos.ToString());

            return true;
        }

        public void MostrarDBName()
        {
            MessageBox.Show(DBName);
        }

        abstract public string getColumnas();

        abstract public string toString();

        abstract public string getActualizar(Modelos.Base objeto);
        


        //public abstract Base mostrarme();
    }
}
