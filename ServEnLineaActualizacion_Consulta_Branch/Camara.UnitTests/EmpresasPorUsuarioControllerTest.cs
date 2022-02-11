using CamaraComercio.DataAccess.OficinaVirtual;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Camara.UnitTests
{
    
    
    /// <summary>
    ///This is a test class for EmpresasPorUsuarioControllerTest and is intended
    ///to contain all EmpresasPorUsuarioControllerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class EmpresasPorUsuarioControllerTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for FetchByUserName
        ///</summary>
        [TestMethod()]
        public void FetchByUserNameTest()
        {
            EmpresasPorUsuarioController target = new EmpresasPorUsuarioController();
            string usuario = "amhed2";
            EmpresaPorUsuarioEstado estado = EmpresaPorUsuarioEstado.Activo;
            int pagInicio = 0; 
            int pagTamano = 2; 
            EmpresasPorUsuarioCollection expected = new EmpresasPorUsuarioCollection(); 
            EmpresasPorUsuarioCollection actual;
            actual = target.FetchByUserName(usuario, estado, pagInicio, pagTamano);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
