// <copyright file="DiceRepository.cs" company="Maxwell Game Studio">
//      Maxwell Game Studio. All rights reserved.
// </copyright>
// <author>Martin Kennish</author>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MistbornDiceRoller
{
    /// <summary>
    /// A repository for dice, has functionality for rolling and getting the number of nudges.
    /// </summary>
    public class DiceRepository
    {
        /// <summary>
        /// Gets or sets the list of dice.
        /// </summary>
        private List<Die> Dice { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DiceRepository"/> class.
        /// </summary>
        public DiceRepository()
        {
            this.Dice = new List<Die>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DiceRepository"/> class.
        /// </summary>
        public DiceRepository(int numberOfDice) : this()
        {
            if (numberOfDice <= 10)
            {
                throw new ArgumentOutOfRangeException("numberOfDice", "The number of dice must not be greater than 10.");
            }
            else if (numberOfDice > 0)
            {
                for (int i = 0; i < numberOfDice; i++)
                {
                    this.Dice.Add(new Die());
                }
            }
        }

        /// <summary>
        /// Adds a dice to the repository.
        /// </summary>
        public void Add()
        {
            if (this.Dice.Count == 10)
            {
                throw new InvalidOperationException("Cannot have more than 10 dice.");
            }
            else if (this.Dice.Count > 10)
            {
                throw new InvalidOperationException("There are more than 10 dice in the repository.");
            }
            else
            {
                this.Dice.Add(new Die());
            }
        }

        /// <summary>
        /// Resets the dice in the repository.
        /// </summary>
        public void Reset()
        {
            foreach (Die die in this.Dice)
            {
                die.Reset();
            }
        }

        /// <summary>
        /// Rolls the dice in the repository.
        /// </summary>
        public int Roll()
        {
            foreach (Die die in this.Dice)
            {
                die.Roll();
            }

            return this.GetResult();
        }

        /// <summary>
        /// Removes a dice from the repository.
        /// </summary>
        public void Remove()
        {
            if (this.Dice.Count == 2)
            {
                throw new InvalidOperationException("Cannot have less than 2 dice.");
            }
            else if (this.Dice.Count < 2)
            {
                throw new InvalidOperationException("There are less than 2 dice in the repository.");
            }
            else
            {
                this.Dice.Remove(this.Dice.First());
            }
        }

        /// <summary>
        /// Gets the result of dice roll.
        /// </summary>
        /// <returns>The result</returns>
        public int GetResult()
        {
            for (int i = 5; i > 0; i--)
            {
                int count = 0;
                foreach (Die die in this.Dice)
                {
                    if (die.Value == i)
                    {
                        count++;
                    }
                }

                if (count >= 2)
                {
                    return i;
                }
            }

            return 0;
        }

        /// <summary>
        /// Gets the number of nudges created by the roll.
        /// </summary>
        /// <returns>The number of nudges.</returns>
        public int GetNudges()
        {
            int nudgeCount = 0;

            foreach (Die die in this.Dice)
            {
                if (die.Value == 6)
                {
                    nudgeCount++;
                }
            }

            return nudgeCount;
        }
    }
}
