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
    public partial class Rubro : Form
    {
        Datos.DBCommand<Modelos.Base> comando = new Datos.DBCommand<Modelos.Base>();

        public Rubro()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Modelos.Rubro rub = new Modelos.Rubro(comando.cantElementos("rubros")+1,txtNombre.Text);
            comando.insertar(rub);
        }
    }
}
