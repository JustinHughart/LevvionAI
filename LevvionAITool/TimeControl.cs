using System;
using System.Windows.Forms;

namespace LevvionAITool
{
    /// <summary>
    /// A control for setting time.
    /// </summary>
    public partial class TimeControl : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TimeControl"/> class.
        /// </summary>
        public TimeControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Gets the time for this instance.
        /// </summary>
        /// <returns></returns>
        public TimeSpan Time()
        {
            return new TimeSpan((int)numDays.Value, (int)numHours.Value, (int)numMinutes.Value, (int)numSeconds.Value, (int)numMilliseconds.Value);
        }
    }
}
