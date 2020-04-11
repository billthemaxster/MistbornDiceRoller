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
        private readonly static Random _Generator = new Random();

        /// <summary>
        /// Gets the value of the die.
        /// </summary>
        public int Value { get; private set; }

        /// <summary>
        /// Rolls the die.
        /// </summary>
        public void Roll()
        {
            // Exclusive maximum.
            this.Value = _Generator.Next(1, 7);
        }

        /// <summary>
        /// Clears the value of the die.
        /// </summary>
        public void Clear()
        {
            this.Value = 0;
        }

        /// <summary>
        /// Returns the value of the dice as a string.
        /// </summary>
        /// <returns>The value of the dice</returns>
        public override string ToString()
        {
            return this.Value.ToString();
        }
    }
}
