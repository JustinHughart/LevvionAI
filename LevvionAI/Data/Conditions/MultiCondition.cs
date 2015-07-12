using System.Collections.Generic;
using System.Xml.Linq;

namespace LevvionAI.Data.Conditions
{
    /// <summary>
    /// A condition that describes having multiple conditions.
    /// </summary>
    public class MultiCondition : Condition
    {
        /// <summary>
        /// The conditions to be satisfied.
        /// </summary>
        public List<Condition> Conditions;

        /// <summary>
        /// Initializes a new instance of the <see cref="MultiCondition"/> class.
        /// </summary>
        public MultiCondition()
        {
            Conditions = new List<Condition>();
        }

        /// <summary>
        /// Determines whether this instance is satisfied.
        /// </summary>
        /// <param name="state">The state of the AI.</param>
        /// <returns></returns>
        public override bool IsSatisfied(AIState state)
        {
            foreach (var condition in Conditions)
            {
                if (!condition.IsSatisfied(state))
                {
                    return false;
                }
            }

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
            
            //Load conditions.
            var conditionselement = element.Element("conditions");

            if (conditionselement == null)
            {
                return;
            }

            foreach (var condition in conditionselement.Elements())
            {
                Conditions.Add(AILoader.CreateCondition(condition));
            }
        }

        /// <summary>
        /// Converts the object to XML.
        /// </summary>
        /// <returns></returns>
        public override XElement SaveToXml()
        {
            var element = base.SaveToXml();
            element.Name = "multicondition";

            var conditionselement = new XElement("conditions");
            element.Add(conditionselement);

            foreach (var condition in Conditions)
            {
                conditionselement.Add(condition.SaveToXml());
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
            var retval = "{" +
                         "MultiCondition : ";

            foreach (var condition in Conditions)
            {
                retval += condition + ",";
            }

            retval.Remove(retval.Length - 1); //Clear the last ,

            retval += "}";

            return retval;
        }
    }
}
