using System.Xml.Linq;
using LevvionAI.Types;
using LevvionAI.Types.Conditions;

namespace LevvionAI
{
    /// <summary>
    /// A static class for loading various bits of data when it comes to AI.
    /// </summary>
    public static class AILoader
    {
        /// <summary>
        /// Creates the condition.
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
