namespace MistbornDiceRoller
{
    public interface IRandomNumberGenerator
    {
        int Next(int minValue, int maxValue);
    }
}
