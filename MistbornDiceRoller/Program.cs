// <copyright file="Program.cs" company="Maxwell Game Studio">
//      Maxwell Game Studio. All rights reserved.
// </copyright>
// <author>Martin Kennish</author>
using System;
using System.Windows.Forms;

namespace MistbornDiceRoller
{
    /// <summary>
    /// Initialises the application.
    /// </summary>
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        internal static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new DiceRollerForm());
        }
    }
}
