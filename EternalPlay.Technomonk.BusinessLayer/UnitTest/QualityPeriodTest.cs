using EternalPlay.Technomonk.BusinessLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using EternalPlay.ReusableCore.Extensions;

namespace EternalPlay.Technomonk.BusinessLayer.UnitTest {
    /// <summary>
    ///This is a test class for QualityPeriodTest and is intended
    ///to contain all QualityPeriodTest Unit Tests
    ///</summary>
    [TestClass()]
    public class QualityPeriodTest {

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
        ///A test for QualityPeriod Constructor
        ///</summary>
        [TestMethod()]
        public void QualityPeriodQualityPeriodConstructorTest() {
            Cycle parent = null;
            Quality quality = null;
            DateTime startDate = new DateTime();
            DateTime endDate = new DateTime();
            QualityPeriod target = new QualityPeriod(parent, quality, startDate, endDate);

            Assert.IsNotNull(target);
        }
        #endregion

        #region Property Tests
        /// <summary>
        ///A test for AsOf
        ///</summary>
        [TestMethod()]
        public void QualityPeriodAsOfTest() {
            DateTime asOf = DateTime.Now;
            YearlySchedule yearlySchedule = new YearlySchedule(asOf);
            Cycle parent = new Cycle(yearlySchedule, DateTime.MinValue);
            Quality quality = null;
            DateTime startDate = new DateTime();
            DateTime endDate = new DateTime();

            QualityPeriod target = new QualityPeriod(parent, quality, startDate, endDate);

            DateTime actual, expected;
            actual = target.AsOf;
            expected = asOf;

            Assert.AreEqual<DateTime>(expected, actual, "AsOf not correctly retrieving from parent object heirarchy.");
        }

        /// <summary>
        ///A test for Cycle
        ///</summary>
        [TestMethod()]
        public void QualityPeriodCycleTest() {
            DateTime asOf = DateTime.Now;
            YearlySchedule yearlySchedule = new YearlySchedule(asOf);
            Cycle parent = yearlySchedule.Cycles.First();
            Quality quality = null;
            DateTime startDate = new DateTime();
            DateTime endDate = new DateTime();
            
            QualityPeriod target = new QualityPeriod(parent, quality, startDate, endDate);
            
            Cycle actual, expected;
            actual = target.Cycle;
            expected = parent;

            Assert.AreEqual<Cycle>(expected, actual, "Cycle not storing and returning proper values.");
        }

        /// <summary>
        ///A test for IsActive
        ///</summary>
        [TestMethod()]
        public void QualityPeriodIsActiveActiveCurrentTest() {
            DateTime asOf = DateTime.Now.FirstMondayOfYear().AddDays(1); //NOTE:  Set as of in active and current period
            YearlySchedule yearlySchedule = new YearlySchedule(asOf);
            Cycle parent = yearlySchedule.Cycles.First();
            Quality quality = null;
            DateTime startDate = parent.QualityPeriods.First().StartDate;
            DateTime endDate = parent.QualityPeriods.First().EndDate;

            QualityPeriod target = new QualityPeriod(parent, quality, startDate, endDate);

            bool actual, expected;
            actual = target.IsActive;
            expected = true; //NOTE:  this is active/current test

            Assert.AreEqual<bool>(expected, actual, "IsActive not correctly deriving from parent object heirarchy when active and current.");
        }

        /// <summary>
        ///A test for IsActive
        ///</summary>
        [TestMethod()]
        public void QualityPeriodIsActiveActiveNotCurrentTest() {
            DateTime asOf = DateTime.Now.FirstMondayOfYear().AddDays(7); //NOTE:  Set as of in active but not current period
            YearlySchedule yearlySchedule = new YearlySchedule(asOf);
            Cycle parent = yearlySchedule.Cycles.First();
            Quality quality = null;
            DateTime startDate = parent.QualityPeriods.First().StartDate;
            DateTime endDate = parent.QualityPeriods.First().EndDate;

            QualityPeriod target = new QualityPeriod(parent, quality, startDate, endDate);

            bool actual, expected;
            actual = target.IsActive;
            expected = true; //NOTE:  this is active/not current test

            Assert.AreEqual<bool>(expected, actual, "IsActive not correctly deriving from parent object heirarchy when active but not current.");
        }

        /// <summary>
        ///A test for IsActive
        ///</summary>
        [TestMethod()]
        public void QualityPeriodIsActiveNotActiveActiveCycleTest() {
            DateTime asOf = DateTime.Now.FirstMondayOfYear().AddDays(1); //NOTE:  Set as of in inactive current cycle
            YearlySchedule yearlySchedule = new YearlySchedule(asOf);
            Cycle parent = yearlySchedule.Cycles.First();
            Quality quality = null;
            DateTime startDate = parent.QualityPeriods.Last().StartDate;
            DateTime endDate = parent.QualityPeriods.Last().EndDate;

            QualityPeriod target = new QualityPeriod(parent, quality, startDate, endDate);

            bool actual, expected;
            actual = target.IsActive;
            expected = false; //NOTE:  this is inactive test

            Assert.AreEqual<bool>(expected, actual, "IsActive not correctly deriving from parent object heirarchy when not active.");
        }

        /// <summary>
        ///A test for IsActive
        ///</summary>
        [TestMethod()]
        public void QualityPeriodIsActiveNotActiveNotActiveCycleTest() {
            DateTime asOf = DateTime.Now.FirstMondayOfYear().AddDays(1); //NOTE:  Set as of in inactive current cycle
            YearlySchedule yearlySchedule = new YearlySchedule(asOf);
            Cycle parent = yearlySchedule.Cycles.Last(); //NOTE:  elect anything but the first cycle
            Quality quality = null;
            DateTime startDate = parent.QualityPeriods.First().StartDate;
            DateTime endDate = parent.QualityPeriods.First().EndDate;

            QualityPeriod target = new QualityPeriod(parent, quality, startDate, endDate);

            bool actual, expected;
            actual = target.IsActive;
            expected = false; //NOTE:  this is inactive test

            Assert.AreEqual<bool>(expected, actual, "IsActive not correctly deriving from parent object heirarchy when not active.");
        }

        /// <summary>
        ///A test for IsCurrent
        ///</summary>
        [TestMethod()]
        public void QualityPeriodIsCurrentCurrentTest() {
            DateTime asOf = DateTime.Now.FirstMondayOfYear().AddDays(1); //NOTE: Set as of into first cycle
            YearlySchedule yearlySchedule = new YearlySchedule(asOf);
            Cycle parent = yearlySchedule.Cycles.First();
            Quality quality = null;
            DateTime startDate = parent.QualityPeriods.First().StartDate;
            DateTime endDate = parent.QualityPeriods.First().EndDate;

            QualityPeriod target = new QualityPeriod(parent, quality, startDate, endDate);

            bool actual, expected;
            actual = target.IsCurrent;
            expected = true;

            Assert.AreEqual<bool>(expected, actual, "IsActive not correctly deriving from parent object heirarchy when not active.");
        }

        /// <summary>
        ///A test for IsCurrent
        ///</summary>
        [TestMethod()]
        public void QualityPeriodIsCurrentNotYetCurrentTest() {
            DateTime asOf = DateTime.Now.FirstMondayOfYear().AddDays(1); //NOTE: Set as of into first cycle
            YearlySchedule yearlySchedule = new YearlySchedule(asOf);
            Cycle parent = yearlySchedule.Cycles.First();
            Quality quality = null;
            DateTime startDate = parent.QualityPeriods.Last().StartDate;
            DateTime endDate = parent.QualityPeriods.Last().EndDate;

            QualityPeriod target = new QualityPeriod(parent, quality, startDate, endDate);

            bool actual, expected;
            actual = target.IsCurrent;
            expected = false;

            Assert.AreEqual<bool>(expected, actual, "IsActive not correctly deriving from parent object heirarchy when not active.");
        }

        /// <summary>
        ///A test for IsCurrent
        ///</summary>
        [TestMethod()]
        public void QualityPeriodIsCurrentNoLongerCurrentTest() {
            DateTime asOf = DateTime.Now.FirstMondayOfYear().AddDays(7); //NOTE: Set as of into second cycle
            YearlySchedule yearlySchedule = new YearlySchedule(asOf);
            Cycle parent = yearlySchedule.Cycles.First();
            Quality quality = null;
            DateTime startDate = parent.QualityPeriods.First().StartDate;
            DateTime endDate = parent.QualityPeriods.First().EndDate;

            QualityPeriod target = new QualityPeriod(parent, quality, startDate, endDate);

            bool actual, expected;
            actual = target.IsCurrent;
            expected = false;

            Assert.AreEqual<bool>(expected, actual, "IsActive not correctly deriving from parent object heirarchy when not active.");
        }

        /// <summary>
        ///A test for EndDate
        ///</summary>
        [TestMethod()]
        public void QualityPeriodEndDateTest() {
            Cycle parent = null;
            Quality quality = null;
            DateTime startDate = new DateTime();
            DateTime endDate = new DateTime();

            QualityPeriod target = new QualityPeriod(parent, quality, startDate, endDate);

            DateTime actual, expected;
            actual = target.EndDate;
            expected = endDate;

            Assert.AreEqual<DateTime>(expected, actual, "EndDate not storing and returning proper values.");
        }

        /// <summary>
        ///A test for Quality
        ///</summary>
        [TestMethod()]
        public void QualityPeriodQualityTest() {
            Cycle parent = null;
            Quality quality = new Quality();
            DateTime startDate = new DateTime();
            DateTime endDate = new DateTime();
            
            QualityPeriod target = new QualityPeriod(parent, quality, startDate, endDate);
            
            Quality actual, expected;
            actual = target.Quality;
            expected = quality;

            Assert.AreEqual<Quality>(expected, actual, "Quality not storing and returning proper values.");
        }

        /// <summary>
        ///A test for StartDate
        ///</summary>
        [TestMethod()]
        public void QualityPeriodStartDateTest() {
            Cycle parent = null;
            Quality quality = null;
            DateTime startDate = new DateTime();
            DateTime endDate = new DateTime();
            
            QualityPeriod target = new QualityPeriod(parent, quality, startDate, endDate);

            DateTime actual, expected;
            actual = target.StartDate;
            expected = startDate;

            Assert.AreEqual<DateTime>(expected, actual, "StartDate not storing and returning proper values.");
        }
        #endregion
        #endregion
    }
}
