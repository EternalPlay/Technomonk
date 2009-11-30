using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace EternalPlay.Technomonk.BusinessLayer {
    /// <summary>
    /// Simple class representing a Technomonk quality
    /// </summary>
    public class Quality {
        /// <summary>
        /// Long description of the quality
        /// </summary>
        public string LongDescription { get; set; }

        /// <summary>
        /// Name of the quality.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Short description of the quality
        /// </summary>
        public string ShortDescription { get; set; }

        /// <summary>
        /// Gets the sort order for the quality
        /// </summary>
        public int SortOrder { get; set; }
    }
}