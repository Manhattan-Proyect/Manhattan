using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Debug
using System.Windows.Forms;

namespace Kiosco.Modelos
{
    class Producto : Base
    {
        // Properties
        private int id;
        private string descripcion;
        private int cantidad;
        private DateTime fecha_vencimiento;
        private Ubicacion ubicacion;
        private int tiempo_alarma;
        private Proveedor proveedor;
        private int codigo;
        private Rubro rubro;
        private decimal precio;

        // Getters and Setters
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }
        public int Cantidad
        {
            get
            {
                return cantidad;
            }

            set
            {
                cantidad = value;
            }
        }
        public DateTime FechaVencimiento
        {
            get
            {
                return fecha_vencimiento;
            }

            set
            {
                fecha_vencimiento = value;
            }
        }
        public Ubicacion Ubicacion
        {
            get
            {
                return ubicacion;
            }

            set
            {
                ubicacion = value;
            }
        }
        public int TiempoAlarma
        {
            get
            {
                return tiempo_alarma;
            }

            set
            {
                tiempo_alarma = value;
            }
        }
        public Proveedor Proveedor
        {
            get
            {
                return proveedor;
            }

            set
            {
                proveedor = value;
            }
        }
        public int Codigo
        {
            get
            {
                return codigo;
            }

            set
            {
                codigo = value;
            }
        }
        public Rubro Rubro
        {
            get
            {
                return rubro;
            }

            set
            {
                rubro = value;
            }
        }
        public decimal Precio
        {
            get
            {
                return precio;
            }

            set
            {
                precio = value;
            }
        }

        // Constructors
        public Producto()
        {
            DBName = "Productos"; // Propiedad de la clase Base
        }

        public Producto(int id)
        {
            DBName = "Productos"; // Propiedad de la clase Base
            
            if (!SelectById(id))
            {
                return;
            }
            DataRow datos = RegistroDB;
            Id = id;
            Descripcion = datos["descripcion"].ToString();
            Cantidad = Convert.ToInt32(datos["cantidad"]);
            FechaVencimiento = Convert.ToDateTime(datos["fecha_vencimiento"]);
            Ubicacion = new Ubicacion(Convert.ToInt32(datos["ubicacion_id"]));
            TiempoAlarma = Convert.ToInt32(datos["tiempo_alarma"]);
            Proveedor = new Proveedor(Convert.ToInt32(datos["proveedor_id"]));
            Codigo = Convert.ToInt32(datos["codigo"]);
            Rubro = new Rubro(Convert.ToInt32(datos["rubro_id"]));
            Precio = Convert.ToInt32(datos["precio"]);
        }

        // Métodos
        public void Guardar()
        {
            DataTable dt = new DataTable();
        }

        //public override mostrarme()
        //{
        //    //Producto me = new Producto(id);
        //    if (SelectById(id))
        //    {
        //        return;
        //    }
        //    //me.Cantidad = cantidad;
        //    //me.Codigo = codigo;
        //    //me.Descripcion = descripcion;
        //    //me.FechaVencimiento = fecha_vencimiento;
        //    //me.Ubicacion = ubicacion;
        //    //me.TiempoAlarma = tiempo_alarma;
        //    //me.Proveedor = proveedor;
        //    //me.Rubro = rubro;
        //    //me.Precio = precio;
        //    return null;
        //}
    }
}
