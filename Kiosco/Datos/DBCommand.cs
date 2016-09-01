using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace Kiosco.Datos
{
    class DBCommand <Base>
    {
        private MySqlConnection vConexion = new MySqlConnection();
        private MySqlCommand vComando = new MySqlCommand();
        private string sql = "";
        private MySqlConnectionStringBuilder vSBuilder;
        

        public DBCommand()
        {
            vConexion.ConnectionString = cadena_conexion();
            vComando.CommandType = System.Data.CommandType.Text;
            vComando.Connection = vConexion;
        }

        public String cadena_conexion()
        {
            //DBName = "Base";
            //Cmd = new MySqlCommand();

            vSBuilder = new MySqlConnectionStringBuilder();
            vSBuilder.Server = "sql7.freemysqlhosting.net";
            vSBuilder.Port = 3306;
            vSBuilder.Database = "sql7131578";
            vSBuilder.UserID = "sql7131578";
            vSBuilder.Password = "gWp4zNiMY9";

            return vSBuilder.ToString();
        }

        private Boolean conectar()
        {
            try
            {
                vConexion.Open();
                return true;
            }
            catch (Exception)
            {
                MessageBox.Show("Error al conectar la base de datos!");
                return false;
            }
        }

        private void desconectar()
        {
            try
            {
                vConexion.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("No se puede desconectar!");
            }
        }

        public void insertar(Modelos.Base objeto)
        {

            if (conectar())
            {
                sql = "INSERT INTO " + objeto.DBName + " (" + objeto.getColumnas() + ") VALUES (" + objeto.toString() + ")";

                vComando.CommandText = sql;
                try
                {
                    vComando.ExecuteNonQuery();
                    MessageBox.Show("Se inserto correctamente!");
                }
                catch (Exception)
                {
                    MessageBox.Show("Error al ingresar el producto!");
                }
                finally
                {
                    desconectar();
                }
            }          
        }
    }
}
