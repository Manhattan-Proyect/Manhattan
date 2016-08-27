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
        private decimal precio_lista;
        private decimal precio_final;

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
            get { return cantidad; }

            set { cantidad = value; }
        }
        public DateTime FechaVencimiento
        {
            get { return fecha_vencimiento; }

            set { fecha_vencimiento = value; }
        }
        public Ubicacion Ubicacion
        {
            get { return ubicacion; }

            set { ubicacion = value; }
        }
        public int TiempoAlarma
        {
            get { return tiempo_alarma; }

            set { tiempo_alarma = value; }
        }
        public Proveedor Proveedor
        {
            get { return proveedor; }

            set { proveedor = value; }
        }
        public int Codigo
        {
            get { return codigo; }

            set { codigo = value; }
        }
        public Rubro Rubro
        {
            get { return rubro; }

            set { rubro = value; }
        }
        public decimal Precio_lista
        {
            get { return precio_lista; }

            set { precio_lista = value; }
        }

        public decimal Precio_final
        {
            get { return precio_final; }

            set { precio_final = value; }
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
            Precio_lista = Convert.ToInt32(datos["precio"]);
        }

        public Producto(int id, string descripcion, int cantidad, DateTime fecha_vencimiento, Ubicacion ubicacion, int tiempo_alarma, Proveedor proveedor, int codigo, Rubro rubro, decimal precio_lista, decimal precio_final)
        {
            this.id = id;
            this.descripcion = descripcion;
            this.cantidad = cantidad;
            this.fecha_vencimiento = fecha_vencimiento;
            this.ubicacion = ubicacion;
            this.tiempo_alarma = tiempo_alarma;
            this.proveedor = proveedor;
            this.codigo = codigo;
            this.rubro = rubro;
            this.precio_lista = precio_lista;
            this.precio_final = precio_final;
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

            return "'" + Descripcion + "', " + Cantidad + ", '" + fecha + "', "  + ", " + TiempoAlarma + ", "  + ", " + Codigo + ", " + ", " + Precio;
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

        
    }
}
