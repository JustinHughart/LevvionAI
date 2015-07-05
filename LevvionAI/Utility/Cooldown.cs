using System;

namespace LevvionAI.Utility
{
    /// <summary>
    /// A class that uses time to manage a cooldown.
    /// </summary>
    public class Cooldown
    {
        /// <summary>
        /// Gets the time left.
        /// </summary>
        /// <value>
        /// The time left.
        /// </value>
        public TimeSpan TimeLeft { get; private set; }
        /// <summary>
        /// The _zero
        /// </summary>
        private readonly TimeSpan _zero  = new TimeSpan(0, 0, 0, 0, 0);

        /// <summary>
        /// Initializes a new instance of the <see cref="Cooldown"/> class.
        /// </summary>
        /// <param name="timeleft">The timeleft.</param>
        public Cooldown(TimeSpan timeleft)
        {
            TimeLeft = timeleft;
        }

        /// <summary>
        /// Updates via  the specified delta time.
        /// </summary>
        /// <param name="deltatime">The deltatime.</param>
        public void Update(TimeSpan deltatime)
        {
            TimeLeft = TimeLeft - deltatime;
        }

        /// <summary>
        /// Determines whether this instance is finished.
        /// </summary>
        /// <returns></returns>
        public bool IsFinished()
        {
            return TimeLeft <= _zero;
        }
    }
}
