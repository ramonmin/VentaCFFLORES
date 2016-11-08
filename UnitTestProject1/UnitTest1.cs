using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ServiceModel;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestCrear()
        {
            ProductoWSC.ProductoClient proxy = new ProductoWSC.ProductoClient();
            ProductoWSC.EProducto productocreado = proxy.CrearProducto(new ProductoWSC.EProducto()
                {
                    codigobarra = "555555555556",
                    NombreProducto = "Prueba3",
                    Stock = 20
                }
                );

            Assert.AreEqual("555555555556", productocreado.codigobarra);
            Assert.AreEqual("Prueba3", productocreado.NombreProducto);
            Assert.AreEqual(20, productocreado.Stock);
        }
        [TestMethod]
        public void TestCrearFault()
        {
            ProductoWSC.ProductoClient proxy = new ProductoWSC.ProductoClient();
            try
            {
                ProductoWSC.EProducto productocreado = proxy.CrearProducto(new ProductoWSC.EProducto()
                {
                    codigobarra = "555555555557",
                    NombreProducto = "Prueba4",
                    Stock = 100
                });
            }
            catch (FaultException<ProductoWSC.RepetidoException> error)
            {
                Assert.AreEqual("Error al intentar Insertar", error.Reason.ToString());
                Assert.AreEqual(error.Detail.excodigobarra, "555555555557");
                Assert.AreEqual(error.Detail.exNombreProducto, "Prueba4");
            }

        }


        [TestMethod]
        public void TestModificar()
        {
            ProductoWSC.ProductoClient proxy = new ProductoWSC.ProductoClient();
            ProductoWSC.EProducto productomodificar = proxy.ModificarProducto(new ProductoWSC.EProducto()
            {
                codigobarra = "123",
                NombreProducto = "Prueba Test1",
                Stock = 21
            }
                );

            Assert.AreEqual("123", productomodificar.codigobarra);
            Assert.AreEqual("Prueba Test1", productomodificar.NombreProducto);
            Assert.AreEqual(21, productomodificar.Stock);
        }


        [TestMethod]
        public void TestModificarFault()
        {
            ProductoWSC.ProductoClient proxy = new ProductoWSC.ProductoClient();
            try
            {
                ProductoWSC.EProducto productocreado = proxy.ModificarProducto(new ProductoWSC.EProducto()
                {
                    codigobarra = "121",
                    NombreProducto = "Prueba test A",
                    Stock = 47
                });
            }
            catch (FaultException<ProductoWSC.RepetidoException> error)
            {
                Assert.AreEqual("Error al intentar Modificar", error.Reason.ToString());
                Assert.AreEqual(error.Detail.excodigobarra, "121");
                Assert.AreEqual(error.Detail.exNombreProducto, "El producto No existe");
                Assert.AreEqual(error.Detail.exStock, 47);
            }

        }

    }
}
