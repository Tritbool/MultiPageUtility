using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel;
using XMLToWBT.DataStructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using XMLToWBT;

namespace Testing
{
    /// <summary>
    /// Summary description for TestDataStructure
    /// </summary>
    [TestClass]
    public class TestDataStructure
    {
        public TestDataStructure()
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

        Tree<string> tree = new Tree<string>();

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

        #region Tree
        [TestMethod]
        public void TestCreateTree()
        {
            Tree<int> t = new Tree<int>();
        }

        [TestMethod]
        public void TestRootTree()
        {

            try
            {
                Tree<string> t = new Tree<string>();
                Console.WriteLine(t._isRoot);
            }
            catch (Exception e)
            {

                Console.WriteLine(e);
            }
        }

        [TestMethod]
        public void insertNode()
        {
            tree.addChild(new Node<string>("test", tree, "yolo"));
            Console.WriteLine(tree.ToString());
        }


        [TestMethod]
        public void displayTree()
        {
            tree.addChild(new Node<string>("test", tree, "<html>"));
            tree.addChild(new Node<string>("test1", tree, "<head>"));
            tree.addChild(new Node<string>("test4", tree, "</head>"));
            Node<string> myNode = new Node<string>("insert",null,"<tool/>");
            tree.Children[1].addChild(new Node<string>("test2", tree.Children[1], "<title>"));
            tree.Children[1].addChild(new Node<string>("test3", tree.Children[1], "</title>"));

            tree.insertNodeAt(tree,tree.Children[1].Children[0],myNode);
            //OU :  tree.Children[1].Children[0].addChild(myNode);

            tree.showTree();
        }

        #endregion
        #region Node
        [TestMethod]
        public void TestCreateNode()
        {
            Node<int> t = new Node<int>();
        }

        [TestMethod]
        public void TestRootNode()
        {

            try
            {
                Node<string> t = new Node<string>();
                Console.WriteLine(t._isRoot);
            }
            catch (Exception e)
            {

                Console.WriteLine(e);
            }
        }
        #endregion
    }
}
