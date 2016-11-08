using CFFLORES.Entidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using CFFLORES.AccesoDatos;
using CFFLORES.WebService.Errores;


namespace CFFLORES.WebService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Producto" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Producto.svc or Producto.svc.cs at the Solution Explorer and start debugging.
    public class Producto : IProducto
    {
        public void DoWork()
        {
        }


        private DAOProducto daoproducto = new DAOProducto();
        public string ObtenerProducto(string codigobarra)
        {
            if (daoproducto.ObtenerProducto(codigobarra) == null)
            {
                throw new FaultException<RepetidoException>(
                    new RepetidoException()
                    {
                        excodigobarra = codigobarra,
                        exNombreProducto = "El producto No existe",
                        exStock = 0
                    },
                    new FaultReason("Error al intentar Consultar"));

            }
            return daoproducto.ObtenerProducto(codigobarra).Stock.ToString();
        }

        public EProducto CrearProducto(EProducto productos)
        {
            if (daoproducto.ObtenerProducto(productos.codigobarra) != null)
            {
                throw new FaultException<RepetidoException>(
                    new RepetidoException()
                    {
                        excodigobarra = productos.codigobarra,
                        exNombreProducto = "El producto No existe",
                        exStock = 0
                    },
                    new FaultReason("Error al intentar Insertar"));

            }
            return daoproducto.CrearProducto(productos);
        }

        public EProducto ModificarProducto(EProducto productos)
        {
            if (daoproducto.ObtenerProducto(productos.codigobarra) == null)
            {
                throw new FaultException<RepetidoException>(
                    new RepetidoException()
                    {
                        excodigobarra = productos.codigobarra,
                        exNombreProducto = "El producto No existe",
                        exStock = 0
                    },
                    new FaultReason("Error al intentar Modificar"));

            }
            return daoproducto.ModificarProducto(productos);
        }


    }
}
