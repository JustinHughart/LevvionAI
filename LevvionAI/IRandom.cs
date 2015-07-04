namespace LevvionAI
{
    /// <summary>
    /// An interface to get data from a RNG.
    /// </summary>
    public interface IRandom
    {
        /// <summary>
        /// Gets a random bool.
        /// </summary>
        /// <returns></returns>
        bool GetBool();
        /// <summary>
        /// Gets a random int between min and max.
        /// </summary>
        /// <param name="min">The minimum.</param>
        /// <param name="max">The maximum.</param>
        /// <returns></returns>
        int GetInt(int min, int max);
        /// <summary>
        /// Gets a random float between min and max.
        /// </summary>
        /// <param name="min">The minimum.</param>
        /// <param name="max">The maximum.</param>
        /// <returns></returns>
        float GetFloat(float min, float max);
    }
}
