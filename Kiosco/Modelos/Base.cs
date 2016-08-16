using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace Kiosco.Modelos
{
    class Base
    {
        private OleDbCommand Cmd;
        private OleDbConnection Connection;
        private OleDbDataReader Reader;
        private string ConnectionString;
        private string SqlString;
        private DataTable Tabla;
        private string db_name;

        public string DBName
        {
            get { return db_name; }
            set { this.db_name= value; }
        }

        public Base()
        {
            DBName= "Base";
            Cmd = new OleDbCommand();
            Connection = new OleDbConnection();
            ConnectionString = ConfigurationManager.ConnectionStrings["Kiosco"].ToString();
        }

        public bool Conectar()
        {
            try
            {
                Connection.ConnectionString = ConnectionString;
                Connection.Open();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectar a SQL. " + ex.ToString());
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
            catch (OleDbException ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public DataRow SelectById(int id)
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
            catch (OleDbException ex)
            {
                throw new Exception(ex.ToString());
            }
            catch (IndexOutOfRangeException ex)
            {
                throw new Exception(ex.ToString());
            }

            if (Tabla.Rows.Count != 0)
            {
            }
            return Tabla.Rows[0];
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
    }
}
