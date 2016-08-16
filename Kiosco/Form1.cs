using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kiosco
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Modelos.Producto prod = new Modelos.Producto();
            prod.Descripcion = "Taza";
            prod.Cantidad = 10;
            prod.FechaVencimiento = DateTime.Now;
            prod.TiempoAlarma = 0;
            prod.Codigo = 50373;
            prod.Precio = 15.70m;
            prod.Ubicacion = new Modelos.Ubicacion(1);
            prod.Proveedor = new Modelos.Proveedor(1);
            prod.Rubro = new Modelos.Rubro(1);
            prod.Guardar();
        }
    }
}
