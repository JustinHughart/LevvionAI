using System.Xml.Linq;
using EssellSeriesStatistics;

namespace LevvionAI.Types
{
    public class Node : IXmlLoadable, IXmlSavable 
    {
        public Condition Conditional;
        public Action Action;
        public int Priority;
        public float Chance;
        public bool Interruptable;

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
