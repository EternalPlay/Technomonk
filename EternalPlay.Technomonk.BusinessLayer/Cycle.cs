using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EternalPlay;

namespace EternalPlay.Technomonk.BusinessLayer {
    /// <summary>
    /// Represents a single cycle of quality periods
    /// </summary>
    public class Cycle {
        #region Fields
        private YearlySchedule _yearlySchedule;
        private ICollection<QualityPeriod> _qualityPeriods;
        #endregion Fields

        #region Constructors
        /// <summary>
        /// Constructs a Cycle with the given parent YearlySchedule and
        /// starting date
        /// </summary>
        /// <param name="parent">Parent <see cref="EternalPlay.Technomonk.BusinessLayer.YearlySchedule"/> reference.</param>
        /// <param name="startDate"><see cref="System.DateTime" />Starting date for the cycle.</param>
        internal Cycle(YearlySchedule parent, DateTime startDate) {
            _yearlySchedule = parent;
            _qualityPeriods = CreateQualityPeriods(startDate, this);
        }
        #endregion 

        #region Properties
        /// <summary>
        /// Gets a reference to the parent yearly schedule
        /// </summary>
        public YearlySchedule YearlySchedule {
            get {
                return _yearlySchedule;
            }
        }

        /// <summary>
        /// Gets a collection of QualityPeriods that comprise the cycle
        /// </summary>
        public ICollection<QualityPeriod> QualityPeriods {
            get {
                return _qualityPeriods;
            }
        }

        /// <summary>
        /// Gets the as of Date used for determining active cycles and quality periods
        /// </summary>
        public DateTime AsOf {
            get {
                return _yearlySchedule.AsOf;
            }
        }

        /// <summary>
        /// Determines if the Cycle is active based on the as of date
        /// </summary>
        public bool IsActive {
            get {
                return (this.StartDate <= this.AsOf && this.AsOf <= this.EndDate);
            }
        }

        /// <summary>
        /// Gets the start date of the cycle (the start date of the first quality period)
        /// </summary>
        public DateTime StartDate {
            get {
                return _qualityPeriods.OrderBy(qp => qp.StartDate).First().StartDate;
            }
        }

        /// <summary>
        /// Gets the end date of the cycle (the end date of the last quality period)
        /// </summary>
        public DateTime EndDate {
            get {
                return _qualityPeriods.OrderByDescending(qp => qp.EndDate).First().EndDate;
            }
        }
        #endregion Properties

        #region Functions
        private static ICollection<QualityPeriod> CreateQualityPeriods(DateTime cycleStart, Cycle parent) {
            List<QualityPeriod> qualityPeriods = new List<QualityPeriod>();
            DateTime periodStart, periodEnd;

            periodStart = cycleStart;
            periodEnd = cycleStart.AddDays(7).AddMilliseconds(-1);

            foreach (Quality q in CycleDefinition.QualityDefinitions.OrderBy(x => x.SortOrder)) {
                QualityPeriod qp = new QualityPeriod(parent, q, periodStart, periodEnd);
                qualityPeriods.Add(qp);

                periodStart = periodStart.AddDays(7);
                periodEnd = periodStart.AddDays(7).AddMilliseconds(-1);
            }

            return qualityPeriods;
        }
        #endregion
    }
}