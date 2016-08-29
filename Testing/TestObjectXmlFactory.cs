using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using XMLToWBT.Factories;

namespace Testing
{
    /// <summary>
    /// Summary description for TestObjectXmlFactory
    /// </summary>
    [TestClass]
    public class TestObjectXmlFactory
    {
        public TestObjectXmlFactory()
        {
            //
            // TODO: Add constructor logic here
            //
        }

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
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void TestCreateXmlObject()
        {
            //
            // TODO: Add test logic here
            //
            XmlObjectFactory fact = new XmlObjectFactory();

            bool ok = true;
            ok = ok && fact.Create("ACTIONS") != null;
            ok = ok && fact.Create("block") != null;
            ok = ok && fact.Create("MultiPage")!= null;
            ok = ok && fact.Create("pageview")!= null;
            ok = ok && fact.Create("tabstrip") != null;
            ok = ok && fact.Create("add")!= null;
            ok = ok && fact.Create("drop")!= null;
            ok = ok && fact.Create("edit")!= null;
            ok = ok && fact.Create("move")!= null;
            ok = ok && fact.Create("ButTon")!= null;
            ok = ok && fact.Create("Caption")!= null;
            ok = ok && fact.Create("CheckBox")!= null;
            ok = ok && fact.Create("Combobox")!= null;
            ok = ok && fact.Create("datepicker")!= null;
            ok = ok && fact.Create("editor")!= null;
            ok = ok && fact.Create("grid")!= null;
            ok = ok && fact.Create("hyperlink")!= null;
            ok = ok && fact.Create("image")!= null;
            ok = ok && fact.Create("label")!= null;
            ok = ok && fact.Create("numerictextbox")!= null;
            ok = ok && fact.Create("radiobutton")!= null;
            ok = ok && fact.Create("tab") != null;
            ok = ok && fact.Create("textbox")!= null;
            ok = ok && fact.Create("unREFERENCEDtag") != null;

            if(ok)
                Console.WriteLine("Factory OK");
            else
                Console.WriteLine("Factory error");

            ok = ok && fact.Create("FAKE NAME") != null;

            if (ok)
                Console.WriteLine("Factory default error");
            else
                Console.WriteLine("Factory default ok");

        }
    }
}
