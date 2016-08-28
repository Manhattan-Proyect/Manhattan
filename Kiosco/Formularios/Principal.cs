using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kiosco.Formularios
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }

        private void productoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ABM.frmProducto frmProducto = new ABM.frmProducto();
            frmProducto.Show();            
        }

        private void proveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ABM.Proveedor frmProv = new ABM.Proveedor();
            frmProv.Show();
        }

        private void rubroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ABM.Rubro frmRubro = new ABM.Rubro();
            frmRubro.Show();
        }

        private void ubicacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ABM.Ubicacion frmUbicacion = new ABM.Ubicacion();
            frmUbicacion.Show();
        }

        private void pruebaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 frmPrueba = new Form1();
            frmPrueba.Show();
        }
    }
}
