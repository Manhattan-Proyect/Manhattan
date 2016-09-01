using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kiosco.Formularios.Tablas
{
    public partial class Producto : Form
    {
        Datos.DBCommand<Modelos.Base> comando = new Datos.DBCommand<Modelos.Base>();

        public Producto()
        {
            InitializeComponent();
        }

        private void Producto_Load(object sender, EventArgs e)
        {
            dgvProductos.DataSource = carga_grilla();
            dgvProductos.AutoResizeColumns();
        }

        private DataTable carga_grilla()
        {
            string sql = "";
            sql = "SELECT prod.id,prod.descripcion, prod.cantidad,prod.fecha_vencimiento,";
            sql += "ub.descripcion as ubicacion,prod.tiempo_alarma,";
            sql += "prov.descripcion as proveedor,prod.codigo,";
            sql += "rub.descripcion as rubro,";
            sql += "prod.precio_lista,prod.precio_final FROM productos prod";
            sql += " JOIN ubicaciones ub ON prod.ubicacion_id = ub.id ";
            sql += " JOIN proveedores prov ON prod.proveedor_id = prov.id ";
            sql += " JOIN rubros rub ON prod.rubro_id = rub.id";
           return comando.carga_grilla(sql);            
        }

        private void dgvProductos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = Convert.ToInt16(dgvProductos.CurrentRow.Cells[0].Value);
            ABM.frmProducto actualizar = new ABM.frmProducto(id);
            actualizar.Show();
        }
    }
}
