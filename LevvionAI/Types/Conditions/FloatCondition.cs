using System;
using System.Xml.Linq;

namespace LevvionAI.Types.Conditions
{
    /// <summary>
    /// A condition for checking a float.
    /// </summary>
    public class FloatCondition : Condition
    {
        /// <summary>
        /// The value
        /// </summary>
        public float Value;

        /// <summary>
        /// Initializes a new instance of the <see cref="FloatCondition"/> class.
        /// </summary>
        public FloatCondition()
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
            var value = state.GetFloat(ID);

            if (!value.HasValue)
            {
                return false;
            }

            switch (Equality)
            {
                case EqualityType.Equals:
                    return value.Equals(Value);
                case EqualityType.NotEquals:
                    return !value.Equals(Value);
                case EqualityType.GreaterThan:
                    return value > Value;
                case EqualityType.LessThan:
                    return value < Value;
                case EqualityType.GreaterThanOrEqual:
                    return value >= Value;
                case EqualityType.LessThanOrEqual:
                    return value <= Value;
                default:
                    throw new Exception("Invalid equality type in FloatCondtion.IsSatisfied().");
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
                    float.TryParse(attribute.Value, out Value);
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
            element.Name = "floatcondition";

            element.Add(new XAttribute("value", Value));

            return element;
        }
    }
}
