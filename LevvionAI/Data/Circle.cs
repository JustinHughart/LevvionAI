using System.Collections.Generic;
using System.Xml.Linq;
using LevvionAI.Data;

namespace LevvionAI.Data
{
    /// <summary>
    /// A circle of nodes for use in LevvionAI.
    /// </summary>
    public class Circle : Node
    {
        /// <summary>
        /// The nodes that belong to the circle.
        /// </summary>
        public List<Node> Nodes;

        /// <summary>
        /// Initializes a new instance of the <see cref="Circle"/> class.
        /// </summary>
        public Circle()
        {
            Nodes = new List<Node>();
        }

        /// <summary>
        /// Determines whether this instance is a circle.
        /// </summary>
        /// <returns></returns>
        public override bool IsCircle()
        {
            return true;
        }

        /// <summary>
        /// Uses XML to initialize the object.
        /// </summary>
        /// <param name="element">The element used for loading.</param>
        public override void LoadFromXml(XElement element)
        {
            if (element == null)
            {
                return;
            }
            
            base.LoadFromXml(element);
            
            var nodeselement = element.Element("nodes");

            if (nodeselement == null)
            {
                return;
            }

            foreach (var nodeelement in nodeselement.Elements())
            {
                Nodes.Add(AILoader.CreateNode(nodeelement));
            }

            Nodes.Sort();
            Nodes.Reverse();
        }

        /// <summary>
        /// Converts the object to XML.
        /// </summary>
        /// <returns></returns>
        public override XElement SaveToXml()
        {
            var element =  base.SaveToXml();
            element.Name = "circle";

            var nodeselement = new XElement("nodes");
            element.Add(nodeselement);

            foreach (var node in Nodes)
            {
                nodeselement.Add(node.SaveToXml());
            }

            return element;
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            //Holy crap what a mess.

            var retval = "{Circle: " +
                         Action + "," +
                         Condition + "," +
                         "Priority: " + Priority +
                         "Chance: " + Chance +
                         "Interruptable: " + Interruptable +
                         "{" +
                         "Nodes: ";

            foreach (var node in Nodes)
            {
                retval += node + ",";
            }

            retval.Remove(retval.Length - 1); //Clear the last ,

            retval +=
                "}" +
                "}";

            return retval;
        }
    }
}
