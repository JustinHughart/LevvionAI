using System;
using System.Xml.Linq;

namespace LevvionAI.Data.Conditions
{
    /// <summary>
    /// A condition for checking a bool.
    /// </summary>
    public class BoolCondition : Condition
    {
        /// <summary>
        /// The value
        /// </summary>
        public bool Value;

        /// <summary>
        /// Initializes a new instance of the <see cref="BoolCondition"/> class.
        /// </summary>
        public BoolCondition()
        {
            Value = false;
        }

        /// <summary>
        /// Determines whether this instance is satisfied.
        /// </summary>
        /// <param name="state">The state of the AI.</param>
        /// <returns></returns>
        /// <exception cref="System.Exception">Invalid equality type in BoolCondtion.IsSatisfied().</exception>
        public override bool IsSatisfied(AIState state)
        {
            var value = state.GetBool(ID);

            if (!value.HasValue)
            {
                return false;
            }

            switch (Equality)
            {
                    case EqualityType.Equals:
                    return value == Value;
                    case EqualityType.NotEquals:
                    return value != Value;
                default:
                    throw new Exception("Invalid equality type in BoolCondtion.IsSatisfied().");
            }
        }

        /// <summary>
        /// Uses XML to initialize the object.
        /// </summary>
        /// <param name="element">The element used for loading.</param>
        public override void LoadFromXml(XElement element)
        {
            base.LoadFromXml(element);

            //Handle attributes
            foreach (var attribute in element.Attributes())
            {
                if (attribute.ToStringEquals("value"))
                {
                    bool.TryParse(attribute.Value, out Value);
                    continue;
                }
            }
        }

        /// <summary>
        /// Converts the object to XML.
        /// </summary>
        /// <returns></returns>
        public override XElement SaveToXml()
        {
            var element = base.SaveToXml();
            element.Name = "boolcondition";

            element.Add(new XAttribute("value", Value));

            return element;
        }
    }
}
