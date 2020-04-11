using System;
using System.Collections.Generic;
using System.Linq;

namespace MistbornDiceRoller
{
    public class DiceRoller : IDiceRoller
    {
        private readonly IRandomNumberGenerator _randomNumberGenerator;
        
        public DiceRoller(IRandomNumberGenerator randomNumberGenerator)
        {
            _randomNumberGenerator = randomNumberGenerator;
        }
        
        public (int result, int nudges) Roll(int numberOfDice)
        {
            if (numberOfDice < 2)
            {
                throw new ArgumentOutOfRangeException(nameof(numberOfDice), "Must be 2 or greater dice.");
            }
            else if (numberOfDice > 10)
            {
                throw new ArgumentOutOfRangeException(nameof(numberOfDice), "The number of dice must not be greater than 10.");
            }

            IEnumerable<int> rolledDice =  RollDice(numberOfDice);

            var groupedDice = rolledDice.GroupBy(x => x);

            int nudges = groupedDice
                .FirstOrDefault(x => x.Key == 6)
                ?.Count() ?? 0;

            int result = GetResult(groupedDice);

            return (result, nudges);
        }

        private IEnumerable<int> RollDice(int numberOfDice)
        {
            return Enumerable.Range(0, numberOfDice - 1).Select(x => _randomNumberGenerator.Next(1, 7));
        }

        private int GetResult(IEnumerable<IGrouping<int, int>> groupedDice)
        {
            return groupedDice
                .Where(x => x.Key != 6)
                .Select(x => new
                {
                    x.Key,
                    Value = x.Count()
                })
                .Where(x => x.Value >= 2)
                .OrderByDescending(x => x.Key)
                .Select(x => x.Key)
                .FirstOrDefault();
        }
    }
}
