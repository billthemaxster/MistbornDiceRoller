// <copyright file="DiceRepository.cs" company="Maxwell Game Studio">
//      Maxwell Game Studio. All rights reserved.
// </copyright>
// <author>Martin Kennish</author>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MistbornDiceRoller.UI
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
        /// Gets or sets the number of dice in the repository.
        /// </summary>
        public int Count
        {
            get
            {
                return this.Dice.Count;
            }
            set
            {
                this.Dice = new List<Die>();

                for (int i = 0; i < value; i++)
                {
                    this.Dice.Add(new Die());
                }
            }
        }

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
            if (numberOfDice > 10)
            {
                throw new ArgumentOutOfRangeException("numberOfDice", "The number of dice must not be greater than 10.");
            }
            else if (numberOfDice < 2)
            {
                throw new ArgumentOutOfRangeException("numberOfDice", "The number of dice must not be less than 2.");
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
                throw new InvalidOperationException(Exceptions.RepositoryCountAtMax);
            }
            else if (this.Dice.Count > 10)
            {
                throw new InvalidOperationException(Exceptions.RepositoryCountGreaterThanMax);
            }
            else
            {
                this.Dice.Add(new Die());
            }
        }

        /// <summary>
        /// Sets the value of each dice in the repository to zero.
        /// </summary>
        public void Clear()
        {
            foreach (Die die in this.Dice)
            {
                die.Clear();
            }
        }

        /// <summary>
        /// Resets the repository to 6 dice.
        /// </summary>
        public void Reset()
        {
            this.Count = 6;
        }

        /// <summary>
        /// Removes a dice from the repository.
        /// </summary>
        public void Remove()
        {
            if (this.Dice.Count == 2)
            {
                throw new InvalidOperationException(Exceptions.RepositoryCountAtMin);
            }
            else if (this.Dice.Count < 2)
            {
                throw new InvalidOperationException(Exceptions.RepositoryCountLessThanMin);
            }
            else
            {
                this.Dice.Remove(this.Dice.First());
            }
        }

        #region Rolling Dice

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

        /// <summary>
        /// Gets the values of the rolls.
        /// </summary>
        /// <returns>A list of the roll values.</returns>
        public List<int> GetRollValues()
        {
            List<int> values = new List<int>();

            foreach (Die die in this.Dice)
            {
                values.Add(die.Value);
            }

            return values;
        }
        #endregion

        #region Logging
        //some event to log when a roll has happened

        /// <summary>
        /// Gets the string that is used to log a roll.
        /// </summary>
        /// <returns>The log entry for the dice roll</returns>
        private string ToLog()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("Roll: ");
            sb.Append(this.GetResult().ToString());
            sb.Append(" Nudges: ");
            sb.Append(this.GetNudges().ToString());
            sb.Append(" DiceCount: ");
            sb.Append(this.Dice.Count);
            sb.Append(" \n\t");

            foreach (int value in this.GetRollValues())
            {
                sb.Append(value.ToString());
                sb.Append(" ");
            }

            return sb.ToString();
        }

        #endregion
    }
}
