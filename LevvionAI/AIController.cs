using System.Xml.Linq;
using EssellSeriesStatistics;

namespace LevvionAI
{
    public class AIController : IXmlLoadable, IXmlSavable
    {
        /// <summary>
        /// Uses XML to initialize the object.
        /// </summary>
        /// <param name="element">The element used for loading.</param>
        public void LoadFromXml(XElement element)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Converts the object to XML.
        /// </summary>
        /// <returns></returns>
        public XElement SaveToXml()
        {
            throw new System.NotImplementedException();
        }
    }
}
