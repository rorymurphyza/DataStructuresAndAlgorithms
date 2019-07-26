using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataStructuresAndAlgorithms.Patterns;

#pragma warning disable IDE0017
namespace DataStructuresAndAlgorithmsTests.Patterns
{
    /* Testing the Command pattern
     * Some of these tests need to run as a game frame that gets repeated, so they will have timers associated with them
     */ 
    [TestClass]
    public class CommandTests
    {
        public CommandTests()
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

        //Testing the most simple implementation, where a command is directly turned into an action
        [TestMethod]
        public void BasicHandler()
        {
            var c = new CommandBasic();
            c.ButtonPressed = CommandBasic.Buttons.BUTTON_A;
            Assert.AreEqual("Button A", c.HandleInput());
            Assert.AreNotEqual("Button B", c.HandleInput());

            c.ButtonPressed = CommandBasic.Buttons.BUTTON_X;
            Assert.AreEqual("Button X", c.HandleInput());
            Assert.AreNotEqual("Button A", c.HandleInput());
            Assert.AreNotEqual("Button B", c.HandleInput());
        }
    }
}
#pragma warning restore IDE0017
