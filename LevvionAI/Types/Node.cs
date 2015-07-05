using System.Xml.Linq;
using EssellSeriesStatistics;

namespace LevvionAI.Types
{
    /// <summary>
    /// An AI node for Mask of Levvion.
    /// </summary>
    public class Node : IXmlLoadable, IXmlSavable 
    {
        /// <summary>
        /// The condition to be satisfied for the node to be accessed.
        /// </summary>
        public Condition Condition;
        /// <summary>
        /// The action to do if ithe condition is satisfied.
        /// </summary>
        public Action Action;
        /// <summary>
        /// The priority of the action compared to others.
        /// </summary>
        public int Priority;
        /// <summary>
        /// The chance of the action happening if the condition is satisfied.
        /// </summary>
        public float Chance;
        /// <summary>
        /// Whether or not the action is interruptable.
        /// </summary>
        public bool Interruptable;

        /// <summary>
        /// Initializes a new instance of the <see cref="Node"/> class.
        /// </summary>
        public Node()
        {
            Condition = null;
            Action = new Action();
            Priority = 0;
            Chance = 0;
            Interruptable = false;
        }

        /// <summary>
        /// Uses XML to initialize the object.
        /// </summary>
        /// <param name="element">The element used for loading.</param>
        public void LoadFromXml(XElement element)
        {
            if (element == null)
            {
                return;
            }

            //Handle attributes
            foreach (var attribute in element.Attributes())
            {
                if (attribute.Name.LocalName.ToStringEquals("priority"))
                {
                    int.TryParse(attribute.Value, out Priority);
                    continue;
                }

                if (attribute.Name.LocalName.ToStringEquals("chance"))
                {
                    float.TryParse(attribute.Value, out Chance);
                    continue;
                }

                if (attribute.Name.LocalName.ToStringEquals("interruptable"))
                {
                    bool.TryParse(attribute.Value, out Interruptable);
                    continue;
                }
            }

            //Handle elements

        }

        /// <summary>
        /// Converts the object to XML.
        /// </summary>
        /// <returns></returns>
        public XElement SaveToXml()
        {
            var element = new XElement("node");

            //Attributes
            element.Add(new XAttribute("priority", Priority));
            element.Add(new XAttribute("chance", Chance));
            element.Add(new XAttribute("interruptable", Interruptable));

            //Elements
            var conditionelement = new XElement("condition");
            conditionelement.Add(Condition.SaveToXml());

            var actionelement = new XElement("action");
            actionelement.Add(Action.SaveToXml());

            return element;
        }
    }
}
