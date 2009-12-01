using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.IO;
using System.Reflection;
using EternalPlay.ReusableCore.Extensions;

namespace EternalPlay.Technomonk.BusinessLayer {
    /// <summary>
    /// Represents a yearly schedule of Cycles.
    /// </summary>
    public class YearlySchedule {
        #region Fields
        private DateTime _asOf;
        private List<Cycle> _cycles;
        #endregion

        #region Constructors
        /// <summary>
        /// Constructs a schedule for the year of the given as of date
        /// </summary>
        /// <param name="asOf"></param>
        public YearlySchedule(DateTime asOf) {
            _asOf = asOf;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets and sets the as of date for the schedule.
        /// </summary>
        /// <remarks>
        /// If the as of date is set after consruction, the cycles will clear and be reset to the year of the new date.
        /// </remarks>
        public DateTime AsOf {
            get {
                return _asOf;
            }

            set {
                this.ResetCycles();
                _asOf = value;
            }
        }

        /// <summary>
        /// Gets a collection of the cycles for the year represented by the as of date
        /// </summary>
        public ICollection<Cycle> Cycles {
            get {
                if (_cycles == null)
                    _cycles = BuildCycles(_asOf, this);

                return _cycles;
            }
        }

        /// <summary>
        /// Gets the active cycle (based on as of date) from the cycle collection.
        /// </summary>
        /// <remarks>
        /// If the as of date represents a date time where there is no active cycle, such as the period at the end of the year, the
        /// Active cycle will be null.
        /// </remarks>
        public Cycle ActiveCycle {
            get {
                return this.Cycles.Where(cycle => cycle.IsCurrent).FirstOrDefault();
            }
        }
        #endregion

        #region Functions
        /// <summary>
        /// Clears the cycle collection forcing them to be rebuilt on the next access.
        /// </summary>
        private void ResetCycles() {
            _cycles = null;
        }
        
        /// <summary>
        /// Builds a <see cref="List{Cycle}" /> based on the given as of date.
        /// </summary>
        /// <param name="asOf">As of date for the cycles to build</param>
        /// <param name="parent">Parent YearlySchedule for the created Cycles</param>
        /// <returns><see cref="List{Cycle}" /></returns>
        private static List<Cycle> BuildCycles(DateTime asOf, YearlySchedule parent) {
            DateTime cycleStart, cycleEnd, endOfYear;
            List<Cycle> cycles = new List<Cycle>();

            cycleStart = asOf.FirstMondayOfYear();
            cycleEnd = cycleStart.AddDays(CycleDefinition.QualityDefinitions.Count * 7);
            endOfYear = asOf.LastDayOfYear();

            while (cycleEnd <= endOfYear) {
                Cycle newCycle = new Cycle(parent, cycleStart);
                cycles.Add(newCycle);

                cycleStart = cycleStart.AddDays(CycleDefinition.QualityDefinitions.Count * 7);
                cycleEnd = cycleStart.AddDays(CycleDefinition.QualityDefinitions.Count * 7);
            }

            return cycles;
        }

        #endregion

        #region Nested Types
        /// <summary>
        /// Constants for use by the parent class
        /// </summary>
        private static class Constants {
            /// <summary>
            /// Integer representation of January
            /// </summary>
            public const int January = 1;

            /// <summary>
            /// Integer representation of December
            /// </summary>
            public const int December = 12;

            /// <summary>
            /// Integer representation of the first day of the month
            /// </summary>
            public const int FirstDayOfMonth = 1;

            /// <summary>
            /// Integer representation of the last day of December
            /// </summary>
            public const int LastDayOfDecember = 31;
        }
        #endregion
    }
}
