using EternalPlay.Technomonk.BusinessLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using EternalPlay.ReusableCore.Extensions;

namespace EternalPlay.Technomonk.BusinessLayer.UnitTest {    
    /// <summary>
    ///This is a test class for DateTimeExtensionsTest and is intended
    ///to contain all DateTimeExtensionsTest Unit Tests
    ///</summary>
    [TestClass()]
    public class DateTimeExtensionsTest {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext {
            get {
                return testContextInstance;
            }
            set {
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

        #region Test Methods
        /// <summary>
        ///A test for LastDayOfYear
        ///</summary>
        [TestMethod()]
        public void DateTimeExtensionsLastDayOfYearTest() {
            DateTime date = new DateTime(2009, 1, 1);
            DateTime expected = new DateTime(2009, 12, 31);
            DateTime actual;
            actual = DateTimeExtensions.LastDayOfYear(date);
            Assert.AreEqual(expected, actual, "Last day of year method not calculating as expected.");
        }

        /// <summary>
        ///A test for FirstMondayOfYear
        ///</summary>
        [TestMethod()]
        public void DateTimeExtensionsFirstMondayOfYearTest() {
            DateTime date = new DateTime(2009, 1, 1);
            DateTime expected = new DateTime(2009, 1, 5);
            DateTime actual;
            actual = DateTimeExtensions.FirstMondayOfYear(date);
            Assert.AreEqual(expected, actual, "First Monday of year method not calculating as expected.");
        }

        /// <summary>
        ///A test for FirstAvailableMonday
        ///</summary>
        [TestMethod()]
        public void DateTimeExtensionsFirstAvailableMondayTest() {
            DateTime date = new DateTime(2009, 11, 24);
            DateTime expected = new DateTime(2009, 11, 30);
            DateTime actual;
            actual = DateTimeExtensions.FirstAvailableMonday(date);
            Assert.AreEqual(expected, actual, "Net available Monday method not calculating as expected.");
        }
        #endregion
    }
}