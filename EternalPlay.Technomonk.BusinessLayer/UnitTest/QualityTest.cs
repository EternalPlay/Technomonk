using EternalPlay.Technomonk.BusinessLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace EternalPlay.Technomonk.BusinessLayer.UnitTest {
   
    /// <summary>
    ///This is a test class for QualityTest and is intended
    ///to contain all QualityTest Unit Tests
    ///</summary>
    [TestClass()]
    public class QualityTest {


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


        /// <summary>
        ///A test for SortOrder property
        ///</summary>
        [TestMethod()]
        public void QualitySortOrderTest() {
            Quality target = new Quality();
            int actual, expected;

            expected = 1;
            target.SortOrder = expected;
            actual = target.SortOrder;
            Assert.AreEqual<int>(expected, actual, "SortOrder not storing and returning proper values.");
        }

        /// <summary>
        ///A test for ShortDescription property
        ///</summary>
        [TestMethod()]
        public void QualityShortDescriptionTest() {
            Quality target = new Quality();
            string actual, expected;

            expected = "Test short description.";
            target.ShortDescription = expected;
            actual = target.ShortDescription;
            Assert.AreEqual<string>(expected, actual, "ShortDescription not storing and returning proper values.");
        }

        /// <summary>
        ///A test for Name property
        ///</summary>
        [TestMethod()]
        public void QualityNameTest() {
            Quality target = new Quality();
            string actual, expected;

            expected = "Test name.";
            target.ShortDescription = expected;
            actual = target.ShortDescription;
            Assert.AreEqual<string>(expected, actual, "Name not storing and returning proper values.");
        }

        /// <summary>
        ///A test for LongDescription
        ///</summary>
        [TestMethod()]
        public void QualityLongDescriptionTest() {
            Quality target = new Quality();
            string actual, expected;

            expected = "Test long description.";
            target.ShortDescription = expected;
            actual = target.ShortDescription;
            Assert.AreEqual<string>(expected, actual, "LongDescription not storing and returning proper values.");
        }

        /// <summary>
        ///A test for Quality Constructor
        ///</summary>
        [TestMethod()]
        public void QualityQualityConstructorTest() {
            string defaultString = null;
            int defaultInt = 0;

            //NOTE:  Verify non null construction
            Quality target = new Quality();
            Assert.IsNotNull(target, "Construction resulted in null object reference.");

            //NOTE:  Verify default values after construction
            Assert.AreEqual<string>(defaultString, target.LongDescription, "LongDescription did not default properly");
            Assert.AreEqual<string>(defaultString, target.Name, "Name did not default properly");
            Assert.AreEqual<string>(defaultString, target.ShortDescription, "ShortDescription did not default properly");
            Assert.AreEqual<int>(defaultInt, target.SortOrder, "SortOrder did not default properly");
        }
    }
}