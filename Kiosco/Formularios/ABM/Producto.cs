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
        //private Modelos.AccesoDatos manejador;
        private Datos.DBCommand<Modelos.Base> comando = new Datos.DBCommand<Modelos.Base>();


        public frmProducto()
        {
            InitializeComponent();
        }

        private void frmProducto_Load(object sender, EventArgs e)
        {
            txtCodigo.Focus();
            carga_combo(cboProv, leo_tabla("proveedores"), "id", "descripcion");
            carga_combo(cboRubro, leo_tabla("rubros"), "id", "descripcion");
            carga_combo(cboUbic, leo_tabla("ubicaciones"), "id", "descripcion");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //string descripcion, int cantidad, DateTime fecha_vencimiento, Ubicacion ubicacion, int tiempo_alarma, Proveedor proveedor, int codigo, Rubro rubro, decimal precio_lista, decimal precio_final
            Modelos.Proveedor prov = new Modelos.Proveedor(cboProv.SelectedIndex);
            Modelos.Ubicacion ubic = new Modelos.Ubicacion(cboUbic.SelectedIndex);
            Modelos.Rubro rub = new Modelos.Rubro(cboRubro.SelectedIndex);
            Modelos.Producto prod = new Modelos.Producto(txtDescr.Text, Convert.ToInt32(txtCantidad.Text), dtpVenc.Value, ubic, Convert.ToInt32(txtAlarma.Text), prov, Convert.ToInt32(txtCodigo.Text), rub, Convert.ToDecimal(txtPLista.Text), Convert.ToDecimal(txtPFinal.Text));
            comando.insertar(prod);
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
