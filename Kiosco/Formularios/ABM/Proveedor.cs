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
    public partial class Proveedor : Form
    {
        Datos.DBCommand<Modelos.Base> comando = new Datos.DBCommand<Modelos.Base>();

        public Proveedor()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Modelos.Proveedor prov = new Modelos.Proveedor((comando.cantElementos("proveedores")) + 1,txtNombre.Text,Convert.ToInt64(txtContacto.Text),txtVisitas.Text,txtObservaciones.Text);
            comando.insertar(prov);
        }
    }
}
