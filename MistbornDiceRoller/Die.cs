// <copyright file="Die.cs" company="Maxwell Game Studio">
//      Maxwell Game Studio. All rights reserved.
// </copyright>
// <author>Martin Kennish</author>
using System;

namespace MistbornDiceRoller
{
    /// <summary>
    /// Represents a die and has rolling functionality.
    /// </summary>
    public class Die
    {
        /// <summary>
        /// The random number generator for dice.
        /// </summary>
        private static Random _Generator = new Random();

        /// <summary>
        /// Gets the value of the die.
        /// </summary>
        public int Value { get; private set; }

        /// <summary>
        /// Rolls the die.
        /// </summary>
        public void Roll()
        {
            this.Value = _Generator.Next(1, 6);
        }

        /// <summary>
        /// Resets the value of the die.
        /// </summary>
        public void Reset()
        {
            this.Value = 0;
        }
    }
}
