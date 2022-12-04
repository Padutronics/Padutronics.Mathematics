namespace Padutronics.Mathematics;

public static class NormalizationFunctions
{
    public static double Normalize(double minimum, double maximum, double value)
    {
        return (value - minimum) / (maximum - minimum);
    }
}