using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EternalPlay.Technomonk.BusinessLayer;
using System.Xml.Linq;

namespace EternalPlay.Technomonk.BusinessLayer.UnitTest {
    /// <summary>
    /// Summary description for CycleDefinitionTest
    /// </summary>
    [TestClass]
    public class CycleDefinitionTest {

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

        #region Test Methods
        #endregion

        /// <summary>
        ///A test for the static QualityDefinitions property of the CycleDefinitions class.
        ///</summary>
        ///<remarks>
        ///This method will need to be updated if the quality definitions XML changes the number of quality nodes
        ///</remarks>
        [TestMethod()]
        public void CycleDefinitionsQualityDefinitionsTest() {
            ICollection<Quality> actual;
            int actualCount, expectedCount;

            //NOTE:  Get the object and ensure it is not null
            actual = CycleDefinition.QualityDefinitions;
            Assert.IsNotNull(actual, "QualityDefinitions property was null");

            //NOTE:  Check the quality object count from the collection
            actualCount = actual.Count;
            expectedCount = 8;
            Assert.AreEqual<int>(expectedCount, actualCount, "Number of qualities in the QualityDefinitions property did not match expected count." );
        }

        /// <summary>
        ///A test for the static LoadQualitiesXml private function of the CycleDefinitions class.
        ///</summary>
        ///<remarks>
        ///This method will need to be updated if the quality definitions XML changes the number of quality nodes
        ///</remarks>
        [TestMethod()]
        [DeploymentItem("EternalPlay.Technomonk.BusinessLayer.dll")]
        public void CycleDefinitionsLoadQualitiesXmlTest() {
            XDocument actual;
            int actualNodeCount, expectedNodeCount;

            //NOTE:  Call the method and ensure a non null return
            actual = CycleDefinition_Accessor.LoadQualitiesXml();
            Assert.IsNotNull(actual, "LoadQualitiesXml function returned a null reference");

            //NOTE:  Check the returned documents quality node count to ensure a propeer load
            actualNodeCount = actual.Descendants("quality").Count();
            expectedNodeCount = 8;
            Assert.AreEqual<int>(expectedNodeCount, actualNodeCount, "Number of qualities in the QualityDefinitions property did not match expected count.");
        }

        /// <summary>
        ///A test for the static LoadQualitiesFromDefinition private function of the CycleDefinitions class.
        ///</summary>
        ///<remarks>
        ///This method will need to be updated if the quality definitions XML changes the number of quality nodes
        ///</remarks>
        [TestMethod()]
        [DeploymentItem("EternalPlay.Technomonk.BusinessLayer.dll")]
        public void CycleDefinitionsLoadQualitiesFromDefinitionTest() {
            ICollection<Quality> actual;
            int actualCount, expectedCount;

            //NOTE:  Call the method and ensure a non null return
            actual = CycleDefinition_Accessor.LoadQualitiesFromDefinition();
            Assert.IsNotNull(actual, "LoadQualitiesFromDefinition function returned a null reference");

            //NOTE:  Check the quality object count from the collection
            actualCount = actual.Count;
            expectedCount = 8;
            Assert.AreEqual<int>(expectedCount, actualCount, "Number of qualities in the LoadQualitiesFromDefinition call did not match expected count.");
        }
    }
}
