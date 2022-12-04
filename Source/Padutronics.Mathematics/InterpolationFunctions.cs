namespace Padutronics.Mathematics;

public static class InterpolationFunctions
{
    public static double Interpolate(double from, double to, double progress)
    {
        // Linear blend: (1 - t)A + tB
        //  A - initial value.
        //  B - final value.
        //  t - current progress normalized to [0.0, 1.0] range.

        return (1.0 - progress) * from + progress * to;
    }
}