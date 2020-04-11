using System;
using System.Collections.Generic;
using System.Text;

namespace MistbornDiceRoller
{
    public interface IDiceRoller
    {
        (int result, int nudges) Roll(int numberOfDice);
    }
}
