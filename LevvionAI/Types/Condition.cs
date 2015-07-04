using System.Xml.Linq;
using EssellSeriesStatistics;

namespace LevvionAI.Types
{
    /// <summary>
    /// An enum denoting a condition's equality type.
    /// </summary>
    public enum EqualityType
    {
        /// <summary>
        /// If the condition is equal to the value.
        /// </summary>
        Equals,
        /// <summary>
        /// If the condition is not equal to the value.
        /// </summary>
        NotEquals,
        /// <summary>
        /// If the condition is greater than the value.
        /// </summary>
        GreaterThan,
        /// <summary>
        /// If the condition is less than the value.
        /// </summary>
        LessThan,
        /// <summary>
        /// If the condition is greater than or equal to the value.
        /// </summary>
        GreaterThanOrEqual,
        /// <summary>
        /// If the condition is less than or equal to the value.
        /// </summary>
        LessThanOrEqual,
    }

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
        /// The equality type of the condition.
        /// </summary>
        public EqualityType Equality;

        public Condition()
        {
            ID = "";
            Equality = EqualityType.Equals;
        }

        /// <summary>
        /// Determines whether this instance is satisfied.
        /// </summary>
        /// <param name="state">The state of the AI.</param>
        /// <returns></returns>
        public virtual bool IsSatisfied(AIState state)
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

                if (attribute.ToStringEquals("equality"))
                {
                    EqualityType.TryParse(attribute.Value, out Equality);
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
            element.Add(new XAttribute("equality", Equality));

            return element;
        }
    }
}
