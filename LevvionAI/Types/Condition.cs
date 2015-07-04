using System.Xml.Linq;
using EssellSeriesStatistics;

namespace LevvionAI.Types
{
    /// <summary>
    /// Dictates a condition statement.
    /// </summary>
    public abstract class Condition : IXmlLoadable, IXmlSavable 
    {
        /// <summary>
        /// The identifier
        /// </summary>
        public string ID;

        /// <summary>
        /// Determines whether this instance is satisfied.
        /// </summary>
        /// <returns></returns>
        public virtual bool IsSatisfied()
        {
            return true;
        }

        /// <summary>
        /// Uses XML to initialize the object.
        /// </summary>
        /// <param name="element">The element used for loading.</param>
        public virtual void LoadFromXml(XElement element)
        {
            if (element == null)
            {
                return;
            }

            //Handle attributes
            foreach (var attribute in element.Attributes())
            {
                if (attribute.ToStringEquals("id"))
                {
                    ID = attribute.Value;
                }
            }
        }

        /// <summary>
        /// Converts the object to XML.
        /// </summary>
        /// <returns></returns>
        public virtual XElement SaveToXml()
        {
            XElement element = new XElement("condition");

            element.Add(new XAttribute("id", ID));

            return element;
        }
    }
}
