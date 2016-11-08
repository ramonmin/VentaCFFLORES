using CFFLORES.Entidad;
using CFFLORES.WebService.Errores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CFFLORES.WebService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IProducto" in both code and config file together.
    [ServiceContract]
    public interface IProducto
    {
        [OperationContract]
        string ObtenerProducto(string codigobarra);

        [FaultContract(typeof(RepetidoException))]
        [OperationContract]
        EProducto CrearProducto(EProducto productos);

        [FaultContract(typeof(RepetidoException))]
        [OperationContract]
        EProducto ModificarProducto(EProducto productos);


    }
}
