using EternalPlay.Technomonk.BusinessLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EternalPlay.Technomonk.BusinessLayer.UnitTest
{
    
    
    /// <summary>
    ///This is a test class for YearlyScheduleTest and is intended
    ///to contain all YearlyScheduleTest Unit Tests
    ///</summary>
    [TestClass()]
    public class YearlyScheduleTest {


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
        #region Constructor Tests
        /// <summary>
        ///A test for YearlySchedule Constructor
        ///</summary>
        [TestMethod()]
        public void YearlyScheduleConstructorTest() {
            DateTime asOf = DateTime.Now;
            YearlySchedule target = new YearlySchedule(asOf);

            Assert.IsNotNull(target, "Construction is resulting in a null reference.");
        }
        #endregion

        #region Property Tests
        /// <summary>
        ///A test for ActiveCycle
        ///</summary>
        [TestMethod()]
        public void YearlyScheduleActiveCycleIsActiveTest() {
            DateTime asOf = new DateTime(2009, 1, 5);
            YearlySchedule target = new YearlySchedule(asOf);
            Cycle actual, expected;
            actual = target.ActiveCycle;
            expected = target.Cycles.First();

            Assert.AreEqual<Cycle>(expected, actual, "ActiveCycle does not match expected Cycle.");
        }

        /// <summary>
        ///A test for ActiveCycle
        ///</summary>
        [TestMethod()]
        public void YearlyScheduleActiveCycleNotActiveTest() {
            DateTime asOf = new DateTime(2009, 1, 5);
            YearlySchedule target = new YearlySchedule(asOf);
            Cycle actual, expected;
            actual = target.ActiveCycle;
            expected = target.Cycles.Last();

            Assert.AreNotEqual<Cycle>(expected, actual, "ActiveCycle does not match expected Cycle.");
        }

        /// <summary>
        ///A test for ActiveCycle
        ///</summary>
        [TestMethod()]
        public void YearlyScheduleActiveCyclePreCyclesPeriodTest() {
            DateTime asOf = new DateTime(2009, 1, 1);
            YearlySchedule target = new YearlySchedule(asOf);
            Cycle actual;

            actual = target.ActiveCycle;
            Assert.IsNull(actual, "ActiveCycle is not null for pre cycle as of date.");
        }

        /// <summary>
        ///A test for ActiveCycle
        ///</summary>
        [TestMethod()]
        public void YearlyScheduleActiveCyclePostCyclesPeriodTest() {
            DateTime asOf = new DateTime(2009, 12, 15);
            YearlySchedule target = new YearlySchedule(asOf);
            Cycle actual;

            actual = target.ActiveCycle;
            Assert.IsNull(actual, "ActiveCycle is not null for post cycle as of date.");
        }

        /// <summary>
        ///A test for AsOf
        ///</summary>
        [TestMethod()]
        public void YearlyScheduleAsOfTest() {
            DateTime asOf = DateTime.Now;
            YearlySchedule target = new YearlySchedule(asOf);
            DateTime actual, expected;

            //NOTE:  Test constructed value
            actual = target.AsOf;
            expected = asOf;
            Assert.AreEqual(expected, actual);
            

            //NOTE:  Test updated property value
            asOf = asOf.AddDays(1); //NOTE:  Modify original date the test the update
            target.AsOf = asOf;

            actual = target.AsOf;
            expected = asOf;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Cycles
        ///</summary>
        [TestMethod()]
        public void YearlyScheduleCyclesTest() {
            DateTime asOf = new DateTime(2009, 1, 1);
            YearlySchedule target = new YearlySchedule(asOf);
            
            //NOTE:  Assure that a non null cycles object was created
            ICollection<Cycle> actual;
            actual = target.Cycles;
            Assert.IsNotNull(actual, "Cycles is not propererly initializing.");
        }
        #endregion

        #region Function Tests
        /// <summary>
        ///A test for ResetCycles
        ///</summary>
        [TestMethod()]
        [DeploymentItem("EternalPlay.Technomonk.BusinessLayer.dll")]
        public void YearlyScheduleResetCyclesTest() {
            DateTime asOf = new DateTime(2009, 1, 5);
            YearlySchedule_Accessor target = new YearlySchedule_Accessor(asOf);
            
            //NOTE:  Ensure _cycles initializes properly
            Assert.IsNotNull(target.Cycles, "Cycles property did not initialize."); //NOTE:  Use the property first to force initialization
            Assert.IsNotNull(target._cycles, "_cycles field did not initialize.");

            //NOTE:  if the method works, the cycles private member should be null;
            target.ResetCycles();
            Assert.IsNull(target._cycles, "ResetCycles did not clear the internal _cycles field.");
        }

        /// <summary>
        ///A test for BuildCycles
        ///</summary>
        ///<remarks>
        ///This test method is dependent on the definitions in QualityDefinitions.xml resource.  If the definitions change, this
        ///method may need to be updated.
        ///</remarks>
        [TestMethod()]
        [DeploymentItem("EternalPlay.Technomonk.BusinessLayer.dll")]
        public void YearlyScheduleBuildCyclesTest() {
            DateTime asOf = new DateTime(2009, 1, 5);
            YearlySchedule parent = new YearlySchedule(asOf);
            int actualCount, expectedCount;
            List<Cycle> actual;
            
            actual = YearlySchedule_Accessor.BuildCycles(asOf, parent);
            Assert.IsNotNull(actual);

            actualCount = actual.Count;
            expectedCount = 6; //NOTE:  Dependent on xml definitions

            Assert.AreEqual<int>(expectedCount, actualCount, "BuildCycles return count does not match expected count.");
        }
        #endregion
        #endregion
    }
}
