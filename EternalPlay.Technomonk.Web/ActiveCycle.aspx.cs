using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

namespace EternalPlay.Technomonk.Web {
    
    /// <summary>
    /// This page represents the Active Cycle
    /// - Shows the qualities of the cycle
    /// - Emphasizes the Active Quality
    /// </summary>
    public partial class ActiveCycle : ContentPage {

        #region Constants

        private const string PAGEURL = "~/ActiveCycle.aspx";

        #endregion

        #region Methods

        /// <summary>
        /// Builds a base url to redirect to this page.
        /// </summary>
        /// <returns>Url to this page with no query string</returns>
        public static Uri ConstructUrl() {
            StringBuilder urlbuilder = new StringBuilder();

            urlbuilder.Append(PAGEURL);

            return new Uri(urlbuilder.ToString(), UriKind.Relative);
        }

        #endregion

    }
}
