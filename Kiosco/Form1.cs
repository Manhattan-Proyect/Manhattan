using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Kiosco
{
    public partial class Form1 : Form
    {
        private Modelos.Base objeto = new Modelos.Base();
        private Modelos.ManejoDatos manejador;
        private DataTable tabla;
        private MySqlCommand cmd;
        string sql;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Modelos.Producto prod = new Modelos.Producto();
            //prod.Descripcion = "Taza";
            //prod.Cantidad = 10;
            //prod.FechaVencimiento = DateTime.Now;
            //prod.TiempoAlarma = 0;
            //prod.Codigo = 50373;
            //prod.Precio = 15.70m;
            //prod.Ubicacion = new Modelos.Ubicacion(1);
            //prod.Proveedor = new Modelos.Proveedor(1);
            //prod.Rubro = new Modelos.Rubro(1);
            //prod.Guardar();

            objeto.Conectar();
        }

        private void btnProducto_Click(object sender, EventArgs e)
        {
            try
            {
                tabla = new DataTable();
                sql = "SELECT * FROM productos";
                cmd = new MySqlCommand(sql, objeto.Connection1);

                tabla.Load(cmd.ExecuteReader());

                dgvGeneral.DataSource = tabla;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se puede obtener la tabla Producto. Error: " + ex.ToString());
            }
            
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            manejador = new Modelos.ManejoDatos("productos");
            sql = "INSERT into productos VALUES (1,'Coca Cola x 2000',1,'2017-08-10',1,90,1,123,1,15)";

            manejador.Acceso.insertar(sql);

            carga_grilla();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            manejador = new Modelos.ManejoDatos("productos");
            tabla = new DataTable();

            tabla = manejador.Acceso.leo_tabla();

            dgvGeneral.DataSource = tabla;
        }

        private void btnEliminarProd_Click(object sender, EventArgs e)
        {
            manejador = new Modelos.ManejoDatos("productos");
            sql = "delete from " + manejador.Acceso.Nombre_tabla;
            sql += " WHERE id = 1";

            manejador.Acceso.insertar(sql);

            carga_grilla();
        }

        private void carga_grilla()
        {
            manejador = new Modelos.ManejoDatos("productos");
            tabla = new DataTable();

            tabla = manejador.Acceso.leo_tabla();

            dgvGeneral.DataSource = tabla;
        }
    }
}
