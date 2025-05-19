using System;
using System.Globalization;

namespace Codingame.CosmicLove;

public class ScientificNumber : IComparable
{
    public ScientificNumber(string s)
    {
        string[] inputs = s.Split('e');
        N = float.Parse(inputs[0], CultureInfo.InvariantCulture);
        P = int.Parse(inputs[1]);
    }

    public ScientificNumber(double n, int p)
    {
        N = n;
        P = n == 0 ? 0 : p;
    }

    public double N { get; }
    public int P { get; }

    public static readonly ScientificNumber Zero = new(0, 0);
    public static readonly ScientificNumber One = new(1, 0);

    public static ScientificNumber operator /(ScientificNumber a, ScientificNumber b)
    {
        if (a.N == 0)
            return Zero;

        double N = a.N / b.N;
        int P = a.P - b.P;

        while (N < 1)
        {
            N *= 10;
            P--;
        }

        return new ScientificNumber(N, P);
    }

    public static ScientificNumber operator *(ScientificNumber a, double b) => b * a;
    public static ScientificNumber operator *(double a, ScientificNumber b) => new ScientificNumber(a, 0) * b;
    public static ScientificNumber operator *(ScientificNumber a, ScientificNumber b)
    {
        if (a.N == 0)
            return Zero;

        double N = a.N * b.N;
        int P = a.P + b.P;

        while (N >= 10)
        {
            N /= 10;
            P++;
        }

        return new ScientificNumber(N, P);
    }

    public static bool operator >(ScientificNumber a, ScientificNumber b)
    {
        if (a.P > b.P)
            return true;

        if (a.P < b.P)
            return false;

        return a.N > b.N;
    }

    public static bool operator <(ScientificNumber a, ScientificNumber b)
    {
        return !(a > b);
    }

    public static implicit operator double(ScientificNumber a)
    {
        double result = a.N;

        if (a.P > 0)
        {
            for (int i = 0; i < a.P; i++)
                result *= 10;
        }
        else if (a.P < 0)
        {
            for (int i = 0; i < -a.P; i++)
                result /= 10;
        }

        return result;
    }

    #region IComparable

    public int CompareTo(object obj)
    {
        if (obj is not ScientificNumber scientificNumber)
            throw new ArgumentException();

        if (this < scientificNumber)
            return -1;

        if (this > scientificNumber)
            return 1;

        return 0;
    }

    #endregion
}
