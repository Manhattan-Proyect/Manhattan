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
        private int ubicacion2;
        private int tiempo_alarma;
        private Proveedor proveedor;
        private int proveedor2;
        private int codigo;
        private Rubro rubro;
        private int rubro2;
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

        public Producto(string descripcion,int cantidad,DateTime fecha_vencimiento,int ubicacion_id,int tiempo_alarma,int proveedor_id,int codigo,int rubro_id,decimal precio)
        {
            this.DBName = "productos";
            this.descripcion = descripcion;
            this.cantidad = cantidad;
            this.fecha_vencimiento = fecha_vencimiento;
            this.ubicacion2 = ubicacion_id;
            this.tiempo_alarma = tiempo_alarma;
            this.proveedor2 = proveedor_id;
            this.codigo = codigo;
            this.rubro2 = rubro_id;
            this.precio = precio;
        }

        public Producto(string descripcion, int cantidad, DateTime fecha_vencimiento, Ubicacion ubicacion, int tiempo_alarma, Proveedor proveedor, int codigo, Rubro rubro, decimal precio)
        {
            this.descripcion = descripcion;
            this.cantidad = cantidad;
            this.fecha_vencimiento = fecha_vencimiento;
            this.ubicacion = ubicacion;
            this.tiempo_alarma = tiempo_alarma;
            this.proveedor = proveedor;
            this.codigo = codigo;
            this.rubro = rubro;
            this.precio = precio;
        }

        // Métodos
        public void Guardar()
        {
            DataTable dt = new DataTable();
        }

        //descripcion,cantidad,fecha_vencimiento,ubicacion_id,tiempo_alarma,proveedor_id,codigo,rubro_id,precio
        public String toString()
        {
            
            string fecha = obtenerFecha();

            return "'" + Descripcion + "', " + Cantidad + ", '" + fecha + "', " + ubicacion2 + ", " + TiempoAlarma + ", " + proveedor2 + ", " + Codigo + ", " + rubro2 + ", " + Precio;
        }

        private string obtenerFecha()
        {
            string dia = fecha_vencimiento.Day.ToString();
            string mes = fecha_vencimiento.Month.ToString();
            string year = fecha_vencimiento.Year.ToString();
            string fecha = year + "-";
            if (fecha_vencimiento.Month < 10)
                fecha += "0" + mes + "-";
            else
                fecha += mes + "-";
            if (fecha_vencimiento.Day < 10)
                fecha += "0" + dia;
            else
                fecha += dia;
            return fecha;
        }

        public string getColumnas()
        {
            return "descripcion,cantidad,fecha_vencimiento,ubicacion_id,tiempo_alarma,proveedor_id,codigo,rubro_id,precio";
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
