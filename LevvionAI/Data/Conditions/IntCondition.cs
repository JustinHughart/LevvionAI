using System;
using System.Xml.Linq;

namespace LevvionAI.Data.Conditions
{
    /// <summary>
    /// A condition for checking an int.
    /// </summary>
    public class IntCondition : Condition
    {
        /// <summary>
        /// The value
        /// </summary>
        public int Value;

        /// <summary>
        /// Initializes a new instance of the <see cref="IntCondition"/> class.
        /// </summary>
        public IntCondition()
        {
            Value = 0;
        }

        /// <summary>
        /// Determines whether this instance is satisfied.
        /// </summary>
        /// <param name="state">The state of the AI.</param>
        /// <returns></returns>
        /// <exception cref="System.Exception">Invalid equality type in IntCondtion.IsSatisfied().</exception>
        public override bool IsSatisfied(AIState state)
        {
            var value = state.GetInt(ID);

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
                case EqualityType.GreaterThan:
                    return value > Value;
                case EqualityType.LessThan:
                    return value < Value;
                case EqualityType.GreaterThanOrEqual:
                    return value >= Value;
                case EqualityType.LessThanOrEqual:
                    return value <= Value;
                default:
                    throw new Exception("Invalid equality type in IntCondtion.IsSatisfied().");
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
                    int.TryParse(attribute.Value, out Value);
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
            element.Name = "intcondition";

            element.Add(new XAttribute("value", Value));

            return element;
        }
    }
}
