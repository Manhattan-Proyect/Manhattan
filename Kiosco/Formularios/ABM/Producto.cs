using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kiosco.Formularios.ABM
{
    public partial class frmProducto : Form
    {
        enum estado
        {
            cargar, actualizar
        }

        //private Modelos.AccesoDatos manejador;
        private Datos.DBCommand<Modelos.Base> comando = new Datos.DBCommand<Modelos.Base>();
        private estado est = estado.cargar;
        private int id;

        public frmProducto()
        {
            InitializeComponent();
            est = estado.cargar;
        }

        public frmProducto(int id)
        {
            InitializeComponent();
            this.id = id;
            DataTable tabla = new DataTable();
            carga_combo(cboProv, leo_tabla("proveedores"), "id", "descripcion");
            carga_combo(cboRubro, leo_tabla("rubros"), "id", "descripcion");
            carga_combo(cboUbic, leo_tabla("ubicaciones"), "id", "descripcion");
            string sql = "SELECT * FROM productos WHERE id = " + id;
            tabla = comando.carga_grilla(sql);
            DataRow row = tabla.Rows[0];
            txtDescr.Text = row[1].ToString();
            txtCodigo.Text = row[7].ToString();
            txtAlarma.Text = row[5].ToString();
            txtCantidad.Text = row[2].ToString();
            txtPLista.Text = row[9].ToString();
            txtPFinal.Text = row[10].ToString();
            dtpVenc.Value = Convert.ToDateTime(row[3]);
            cboUbic.SelectedValue = row[4].ToString();
            cboProv.SelectedValue = row[6].ToString();
            cboRubro.SelectedValue = row[8].ToString();
            est = estado.actualizar;

        }

        private void frmProducto_Load(object sender, EventArgs e)
        {
            txtCodigo.Focus();
            if (est == estado.cargar)
            {
                carga_combo(cboProv, leo_tabla("proveedores"), "id", "descripcion");
                carga_combo(cboRubro, leo_tabla("rubros"), "id", "descripcion");
                carga_combo(cboUbic, leo_tabla("ubicaciones"), "id", "descripcion");
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //string descripcion, int cantidad, DateTime fecha_vencimiento, Ubicacion ubicacion, int tiempo_alarma, Proveedor proveedor, int codigo, Rubro rubro, decimal precio_lista, decimal precio_final
            if (est == estado.cargar)
            {
                Modelos.Proveedor prov = new Modelos.Proveedor(Convert.ToInt16(cboProv.SelectedValue));
                Modelos.Ubicacion ubic = new Modelos.Ubicacion(Convert.ToInt16(cboUbic.SelectedValue));
                Modelos.Rubro rub = new Modelos.Rubro(Convert.ToInt16(cboRubro.SelectedValue));
                Modelos.Producto prod = new Modelos.Producto(txtDescr.Text, Convert.ToInt32(txtCantidad.Text), dtpVenc.Value, ubic, Convert.ToInt32(txtAlarma.Text), prov, Convert.ToInt32(txtCodigo.Text), rub, Convert.ToDecimal(txtPLista.Text), Convert.ToDecimal(txtPFinal.Text));
                comando.insertar(prod);
            }
            else
            {
                Modelos.Proveedor prov = new Modelos.Proveedor(Convert.ToInt16(cboProv.SelectedValue));
                Modelos.Ubicacion ubic = new Modelos.Ubicacion(Convert.ToInt16(cboUbic.SelectedValue));
                Modelos.Rubro rub = new Modelos.Rubro(Convert.ToInt16(cboRubro.SelectedValue));
                Modelos.Producto prod = new Modelos.Producto(id);
                Modelos.Producto prod2 = new Modelos.Producto(txtDescr.Text, Convert.ToInt32(txtCantidad.Text), dtpVenc.Value, ubic, Convert.ToInt32(txtAlarma.Text), prov, Convert.ToInt32(txtCodigo.Text), rub, Convert.ToDecimal(txtPLista.Text), Convert.ToDecimal(txtPFinal.Text));
                comando.actualizar(prod,prod2);
            }
            
        }

        private void carga_combo(ComboBox combo, DataTable tabla, string pk, string descripcion)
        {
            combo.Items.Clear();
            combo.DataSource = tabla;
            combo.ValueMember = pk;
            combo.DisplayMember = descripcion;
        }

        private DataTable leo_tabla(string nombre_tabla)
        {
            DataTable tabla = new DataTable();
            Modelos.AccesoDatos acceso = new Modelos.AccesoDatos(nombre_tabla);

            tabla = acceso.leo_tabla();

            return tabla;
        }
        
    }
}
