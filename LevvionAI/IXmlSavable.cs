using System.Xml.Linq;

namespace EssellSeriesStatistics
{
    /// <summary>
    /// An interface that says you may save the object to XML.
    /// </summary>
    public interface IXmlSavable
    {
        /// <summary>
        /// Converts the object to XML.
        /// </summary>
        /// <returns></returns>
        XElement SaveToXml();
    }
}