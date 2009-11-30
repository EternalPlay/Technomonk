using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EternalPlay.Technomonk.BusinessLayer {
    /// <summary>
    /// Extension methods for System.DateTime objects
    /// </summary>
    public static class DateTimeExtensions {
        /// <summary>
        /// Gets a date time of the last calendar day of the given Year.
        /// </summary>
        /// <param name="date">Instance to extend</param>
        /// <returns><see cref="System.DateTime" /> value for the last day of the Year</returns>
        public static DateTime LastDayOfYear(this DateTime date) {
            return new DateTime(date.Year, 12, 31);
        }

        /// <summary>
        /// Gets a date time of the first Monday of the calendar for the given year.
        /// </summary>
        /// <param name="date">Instance to extend</param>
        /// <returns><see cref="System.DateTime" /> value for the first Monday of the Year</returns>
        public static DateTime FirstMondayOfYear(this DateTime date) {
            return (new DateTime(date.Year, 1, 1).FirstAvailableMonday());
        }

        /// <summary>
        /// Gets the first monday that occurs on or after the given date.
        /// </summary>
        /// <remarks>
        /// If the given <see cref="System.DateTime" /> occurs on a Monday a date (with no time) of the same date is returned.  Otherwise
        /// the date of the next occuring Monday is returned.
        /// </remarks>
        /// <param name="date">Instance to extend</param>
        /// <returns><see cref="System.DateTime" /> of the correct Monday.</returns>
        public static DateTime FirstAvailableMonday(this DateTime date) {
            while (date.DayOfWeek != DayOfWeek.Monday)
                date = date.AddDays(1);

            return date.Date;
        }
    }
}
