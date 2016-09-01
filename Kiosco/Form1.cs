﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Globalization;
using System.Threading;

namespace Kiosco
{
    public partial class Form1 : Form
    {
        //private Modelos.Base objeto;
        //private Modelos.ManejoDatos manejador;
        private Modelos.AccesoDatos manejador;
        private DataTable tabla;
        //private MySqlCommand cmd;
        string sql;
        string raiz = Application.StartupPath.ToString();

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

            //objeto.Conectar();
        }

        private void btnUbicaciones_Click(object sender, EventArgs e)
        {
            try
            {
                // manejador = new Modelos.ManejoDatos("ubicaciones");
                manejador = new Modelos.AccesoDatos("ubicaciones");
                tabla = new DataTable();

                //tabla = manejador.Acceso.leo_tabla();
                tabla = manejador.leo_tabla();

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
            //descripcion,cantidad,fecha_vencimiento,ubicacion_id,tiempo_alarma,proveedor_id,codigo,rubro_id,precio
            //TODO: Cambiar parametros de constructor
            //Modelos.Producto objeto2 = new Modelos.Producto(txtDescripcion.Text,Convert.ToInt16(txtCantidad.Text), Convert.ToDateTime(dtpVenci.Text), Convert.ToInt16(txtUbicacion.Text), Convert.ToInt16(txtAlarma.Text), Convert.ToInt16(txtProveedor.Text), Convert.ToInt16(txtCodigo.Text), Convert.ToInt16(txtRubro.Text),Convert.ToDecimal(txtPrecio.Text));
            //manejador = new Modelos.AccesoDatos(objeto2.DBName);
            //descripcion,cantidad,fecha_vencimiento,ubicacion_id,tiempo_alarma,proveedor_id,codigo,rubro_id,precio
            //sql = "INSERT into productos (" + objeto2.getColumnas() +") VALUES (" + objeto2.toString() +")";

            //manejador.Acceso.insertar(sql);
            try
            {
                manejador.insertar(sql);
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error al ingresar el dato solicitado: " + ex.ToString());
                
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(raiz + @"\test.txt", true))
                {
                   
                    file.WriteLine("");
                    file.WriteLine("");
                    file.WriteLine("Fecha del error: " + DateTime.Today.ToString());
                    file.WriteLine("");
                    file.WriteLine("ERROR!!");
                    file.WriteLine("");
                    file.WriteLine(ex.ToString());
                }
            }
            

            //carga_grilla(manejador.Acceso.Nombre_tabla);
            carga_grilla(manejador.Nombre_tabla);
            limpiar();
        }

        private void limpiar()
        {
            foreach (Control objeto in Controls)
            {
                if (objeto is TextBox)
                {
                    objeto.Text = "";
                    objeto.Enabled = true;
                }
                if (objeto is ComboBox)
                {
                    ((ComboBox)objeto).SelectedValue = -1;
                    objeto.Enabled = true;
                }
                if (objeto is MaskedTextBox)
                {
                    ((MaskedTextBox)objeto).Text = "";
                    objeto.Enabled = true;
                }
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //manejador = new Modelos.ManejoDatos("productos");
            manejador = new Modelos.AccesoDatos("productos");
            tabla = new DataTable();

            

            //tabla = manejador.Acceso.leo_tabla();
            this.tabla = manejador.leo_tabla();

            dgvGeneral.DataSource = tabla;
        }

        private void btnEliminarProd_Click(object sender, EventArgs e)
        {
            //manejador = new Modelos.ManejoDatos("productos");
            manejador = new Modelos.AccesoDatos("productos");
            string restriccion;
            //sql = "delete from " + manejador.Acceso.Nombre_tabla;
            sql = "delete from " + manejador.Nombre_tabla;
            restriccion = " id = " + txtEliminar.Text;

            //manejador.Acceso.insertar(sql);
            manejador.insertar(sql, restriccion);

            //carga_grilla(manejador.Acceso.Nombre_tabla);
            carga_grilla(manejador.Nombre_tabla);
        }

        private void carga_grilla(String nombre_tabla)
        {
            //manejador = new Modelos.ManejoDatos(nombre_tabla);
            manejador = new Modelos.AccesoDatos(nombre_tabla);
            tabla = new DataTable();

            //tabla = manejador.Acceso.leo_tabla();
            tabla = manejador.leo_tabla();

            dgvGeneral.DataSource = tabla;
        }
    }
}
