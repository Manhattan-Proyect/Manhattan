using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Data;

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
                    MessageBox.Show("Error al ingresar!");
                }
                finally
                {
                    desconectar();
                }
            }          
        }

        public void borrar(Modelos.Base objeto)
        {
            if (conectar())
            {
                sql = "DELETE FROM " + objeto.DBName + " WHERE Id = " + objeto.Id;

                vComando.CommandText = sql;
                try
                {
                    vComando.ExecuteNonQuery();
                    MessageBox.Show("Se borro correctamente!");
                }
                catch (Exception)
                {
                    MessageBox.Show("Error al borrar!");
                }
                finally
                {
                    desconectar();
                }
            }
        }

        public void actualizar(Modelos.Base objetoViejo, Modelos.Base objetoNuevo)
        {
            if (conectar())
            {
                sql = "UPDATE " + objetoViejo.DBName + " SET " + getUpdateString(objetoViejo,objetoNuevo);

                vComando.CommandText = sql;
                try
                {
                    vComando.ExecuteNonQuery();
                    MessageBox.Show("Se actualizo correctamente!");
                }
                catch (Exception)
                {
                    MessageBox.Show("Error al actualizar!");
                }
                finally
                {
                    desconectar();
                }
            }
        }

        public int cantElementos(string nombre_tabla)
        {
            if (conectar())
            {
                DataTable tabla = new DataTable();

                sql = "SELECT * FROM " + nombre_tabla;

                vComando.CommandText = sql;
                try
                {
                    tabla.Load(vComando.ExecuteReader());
                    return tabla.Rows.Count;
                }
                catch (Exception)
                {
                    MessageBox.Show("No se puede obtener la tabla " + nombre_tabla);
                }
                finally
                {
                    desconectar();
                    
                }
            }
            return 0;
        }

        public DataTable carga_grilla(string consulta)
        {
            DataTable tabla = new DataTable();
            if (conectar())
            {
                
                sql = consulta;

                vComando.CommandText = sql;
                try
                {
                    tabla.Load(vComando.ExecuteReader());
                    return tabla;
                }
                catch (Exception)
                {
                    MessageBox.Show("Error al obtener la tabla ");
                }
                finally
                {
                    desconectar();
                }
            }
            return tabla;
        }

        private string getUpdateString(Modelos.Base objetoViejo, Modelos.Base objetoNuevo)
        {
            string update = "";
            
            update += objetoViejo.getActualizar(objetoNuevo);
            update += " WHERE Id = " + objetoViejo.Id;

            return update;
        }
    }
}
