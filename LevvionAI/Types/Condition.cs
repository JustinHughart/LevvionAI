using System.Xml.Linq;
using EssellSeriesStatistics;

namespace LevvionAI.Types
{
    public abstract class Condition : IXmlLoadable, IXmlSavable 
    {
        public string ID;

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
