using System.IO;
using System.Xml.Linq;
using LevvionAI.Data;
using LevvionAI.Data.Conditions;
using LevvionAI.Interfaces;

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

        /// <summary>
        /// Loads the AI.
        /// </summary>
        /// <param name="rng">The RNG.</param>
        /// <param name="path">The path.</param>
        /// <returns></returns>
        public static AIController LoadAI(IRandom rng, string path)
        {
            var doc = XDocument.Load(path);

            return LoadController(rng, doc);
        }

        /// <summary>
        /// Loads the AI.
        /// </summary>
        /// <param name="rng">The RNG.</param>
        /// <param name="stream">The stream.</param>
        /// <returns></returns>
        public static AIController LoadAI(IRandom rng, Stream stream)
        {
            var doc = XDocument.Load(stream);

            return LoadController(rng, doc);
        }

        /// <summary>
        /// Loads the controller.
        /// </summary>
        /// <param name="rng">The RNG.</param>
        /// <param name="document">The document.</param>
        /// <returns></returns>
        private static AIController LoadController(IRandom rng, XDocument document)
        {
            var ai = new AIController(rng);
            ai.LoadFromXml(document.Root);
            return ai;
        }
    }
}
