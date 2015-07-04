using System;

namespace LevvionAI
{
    public static class LevvionHelper
    {
        #region String Equality

        /// <summary>
        /// Converts the object to a string and checks if it's equal ordinally, ignoring case.
        /// </summary>
        /// <param name="a">A.</param>
        /// <param name="b">The b.</param>
        /// <returns></returns>
        public static bool ToStringEquals(this object a, string b)
        {
            return a.ToString().Equals(b, StringComparison.OrdinalIgnoreCase);
        }

        #endregion
    }
}
