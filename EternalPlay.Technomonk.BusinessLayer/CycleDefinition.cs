using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.IO;
using System.Reflection;
using System.Globalization;

namespace EternalPlay.Technomonk.BusinessLayer {
    //TODO:  Add globalization support to allow loading based on culture codes

    /// <summary>
    /// Interal static class for managing access to CycleDefinition XML files
    /// </summary>
    internal static class CycleDefinition {
        #region fields
        private static ICollection<Quality> _cycleDefinition;
        #endregion

        #region Properties
        internal static ICollection<Quality> QualityDefinitions {
            get {
                if (_cycleDefinition == null)
                    _cycleDefinition = LoadQualitiesFromDefinition();

                return _cycleDefinition;
            }
        }
        #endregion

        #region Functions
        /// <summary>
        /// Loads a collection of Quality objects from an embedded cycle definition xml file.
        /// </summary>
        /// <returns><see cref="System.Collections.Generic.ICollection{Quality}" /></returns>
        private static ICollection<Quality> LoadQualitiesFromDefinition() {
            return LoadQualitiesXml().Descendants()
                .Where(el => el.Name == Constants.XNameQuality)
                .Select(el => {
                    return new Quality {
                        LongDescription = el.Descendants(Constants.XNameLongDescription).First().Value,
                        Name = el.Attribute(Constants.XNameName).Value,
                        ShortDescription = el.Descendants(Constants.XNameShortDescription).First().Value,
                        SortOrder = int.Parse(el.Attribute(Constants.XNameSortOrder).Value, CultureInfo.InvariantCulture)
                    };
                }).OrderBy(quality => quality.SortOrder)
                .ToList();
        }

        /// <summary>
        /// Loads a <see cref="System.Xml.Linq.XDocument" /> containing a cycle quality definition.
        /// </summary>
        /// <returns><see cref="System.Xml.Linq.XDocument" /></returns>
        private static XDocument LoadQualitiesXml() {
            XDocument qualitiesDocument;
            using (StreamReader reader = new StreamReader(Assembly.GetExecutingAssembly().GetManifestResourceStream(Constants.QualityDefinitionResourceFileName))) {
                qualitiesDocument = XDocument.Parse(reader.ReadToEnd());
                reader.Close();
            }

            return qualitiesDocument;
        }
        #endregion

        #region Nested Types
        /// <summary>
        /// Static class for holding constants for the parent class
        /// </summary>
        private static class Constants {
            /// <summary>
            /// Resource access name for the quality definition resource file
            /// </summary>
            public const string QualityDefinitionResourceFileName = "EternalPlay.Technomonk.BusinessLayer.Resources.QualityDefinition.xml";

            /// <summary>
            /// XName for long description elements.
            /// </summary>
            public static readonly XName XNameLongDescription = "longDescription";

            /// <summary>
            /// XName for name attributes.
            /// </summary>
            public static readonly XName XNameName = "name";

            /// <summary>
            /// XName for quality elements
            /// </summary>
            public static readonly XName XNameQuality = "quality";

            /// <summary>
            /// XName for short description elements
            /// </summary>
            public static readonly XName XNameShortDescription = "shortDescription";

            /// <summary>
            /// XName for sort order attributes
            /// </summary>
            public static readonly XName XNameSortOrder = "sortOrder";
        }
        #endregion
    }
}
