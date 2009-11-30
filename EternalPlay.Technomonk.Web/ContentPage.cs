using System;using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace EternalPlay.Technomonk.Web {
    /// <summary>
    /// Base page for all Technomonk content pages
    /// </summary>
    public class ContentPage : System.Web.UI.Page {
        /// <summary>
        /// Perform pre initialization specific activities
        /// 
        /// 1. Master Page manipulation
        /// 2. Theme manipulation
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPreInit(EventArgs e) {
            base.OnPreInit(e);

            //NOTE:  1. Master Page manipulation

            //NOTE:  2. Theme manipulation
            InitializeTheme(this);
        }

        #region Functions
        /// <summary>
        /// Initializes the theme for the page.
        /// </summary>
        /// <param name="page">ContentPage object to initialize.</param>
        private static void InitializeTheme(ContentPage page) {
            page.Theme = "Default";
        }
        #endregion
    }
}
