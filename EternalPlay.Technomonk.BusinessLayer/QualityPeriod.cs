using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EternalPlay.Technomonk.BusinessLayer {
    /// <summary>
    /// Represents a Quality expressed through a duration of time.
    /// </summary>
    public class QualityPeriod {
        #region Fields
        private Cycle _cycle;
        private Quality _quality;
        private DateTime _startDate, _endDate;
        #endregion

        #region Constructors
        /// <summary>
        /// Constructs a QualityPeriod with the given quality and period definition data
        /// </summary>
        /// <param name="parent">Parent <see cref="EternalPlay.Technomonk.BusinessLayer.Cycle" /> object.</param>
        /// <param name="quality">Quality being defined for the period</param>
        /// <param name="startDate">Starting <see cref="System.DateTime" /> for the period.</param>
        /// <param name="endDate">Ending <see cref="System.DateTime" /> for the period.</param>
        internal QualityPeriod(Cycle parent, Quality quality, DateTime startDate, DateTime endDate) {
            _cycle = parent;
            _quality = quality;
            _startDate = startDate;
            _endDate = endDate;
        }
        #endregion

        /// <summary>
        /// Gets the parent <see cref="EternalPlay.Technomonk.BusinessLayer.Cycle" /> that contains the QualityPeriod.
        /// </summary>
        public Cycle Cycle {
            get {
                return _cycle;
            }
        }

        /// <summary>
        /// As of relational date used for determining active and current QualityPeriods.
        /// </summary>
        public DateTime AsOf {
            get {
                return _cycle.YearlySchedule.AsOf;
            }
        }

        /// <summary>
        /// <see cref="EternalPlay.Technomonk.BusinessLayer.Cycle" /> being defined for the period.
        /// </summary>
        public Quality Quality {
            get {
                return _quality;
            }
        }

        /// <summary>
        /// Date when the QualityPeriod starts
        /// </summary>
        public DateTime StartDate {
            get {
                return _startDate;
            }
        }

        /// <summary>
        /// Date when the QualityPeriod ends
        /// </summary>
        public DateTime EndDate {
            get {
                return _endDate;
            }
        }

        /// <summary>
        /// Determines if the QualityPeriod is Active within the parent cycle.
        /// </summary>
        /// <remarks>
        /// A period is active if the as of date occurs after the start of the parent cycle and before the end of the quality period
        /// </remarks>
        public bool IsActive {
            get {
                return (this.Cycle.IsCurrent && this.AsOf >= this.StartDate);
            }
        }

        /// <summary>
        /// Determines if the Quality period is the Current quality period.
        /// </summary>
        /// <remarks>
        /// A period is current if the as of date occurs between the start and end dates of the period.  A current quality period
        /// is also Active, but Active periods may not be current.
        /// </remarks>
        public bool IsCurrent {
            get {
                return (this.StartDate <= this.AsOf && this.AsOf <= this.EndDate);
            }
        }
    }
}