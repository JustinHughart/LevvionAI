using System.Windows.Forms;

namespace LevvionAITool
{
    /// <summary>
    /// A helper class for the Levvion AI tool.
    /// </summary>
    public static class Helper
    {
        /// <summary>
        /// Refreshes ToString on a listbox.
        /// </summary>
        /// <param name="listbox">The listbox.</param>
        public static void RefreshToString(this ListBox listbox)
        {
            int count = listbox.Items.Count;
            listbox.SuspendLayout();

            for (int i = 0; i < count; i++)
            {
                listbox.Items[i] = listbox.Items[i];
            }

            listbox.ResumeLayout();
        }
    }
}
