using System.Xml.Linq;
using LevvionAI.Data;
using LevvionAI.Data.Conditions;

namespace LevvionAI
{
    /// <summary>
    /// A static class for loading various bits of data when it comes to AI.
    /// </summary>
    public static class AILoader
    {
        /// <summary>
        /// Creates a node or circle from XML.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <returns></returns>
        public static Node CreateNode(XElement element)
        {
            Node node = null;

            //Certainly there's a more elegant way than this? Switch cases don't work on strings apparantly.
            if (element.Name.LocalName.ToStringEquals("node"))
            {
                node = new Node();
            }
            else if (element.Name.LocalName.ToStringEquals("circle"))
            {
                node = new Circle();
            }
            else 
            {
                return null;
            }

            node.LoadFromXml(element);

            return node;
        }

        /// <summary>
        /// Creates a condition from XML.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <returns></returns>
        public static Condition CreateCondition(XElement element)
        {
            Condition condition = null;

            //Certainly there's a more elegant way than this? Switch cases don't work on strings apparantly.
            if (element.Name.LocalName.ToStringEquals("multicondition"))
            {
                condition = new MultiCondition();
            }
            else if (element.Name.LocalName.ToStringEquals("boolcondition"))
            {
                condition = new BoolCondition();
            }
            else if (element.Name.LocalName.ToStringEquals("intcondition"))
            {
                condition = new IntCondition();
            }
            else if (element.Name.LocalName.ToStringEquals("floatcondition"))
            {
                condition = new FloatCondition();
            }
            else
            {
                return null;
            }

            condition.LoadFromXml(element);

            return condition;
        }
    }
}
