using System;

struct Vector
{
    private double x;
    private double y;
    private double z;

    public Vector(double x = 0.0, double y = 0.0, double z = 0.0)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }

    public double X
    {
        get { return x; }
        set { x = value; }
    }

    public double Y
    {
        get { return y; }
        set { y = value; }
    }

    public double Z
    {
        get { return z; }
        set { z = value; }
    }

    public static Vector operator +(Vector left, Vector right)
    {
        return new Vector(left.X + right.X, left.Y + right.Y, left.Z + right.Z);
    }

    public static double operator *(Vector left, Vector right)
    {
        return left.X * right.X + left.Y * right.Y + left.Z * right.Z;
    }

    public static Vector operator *(Vector vector, double scalar)
    {
        return new Vector(vector.X * scalar, vector.Y * scalar, vector.Z * scalar);
    }

    public static bool operator <(Vector left, Vector right)
    {
        double length1 = Math.Sqrt(left.X * left.X + left.Y * left.Y + left.Z * left.Z);
        double length2 = Math.Sqrt(right.X * right.X + right.Y * right.Y + right.Z * right.Z);
        return length1 < length2;
    }

    public static bool operator >(Vector left, Vector right)
    {
        double length1 = Math.Sqrt(left.X * left.X + left.Y * left.Y + left.Z * left.Z);
        double length2 = Math.Sqrt(right.X * right.X + right.Y * right.Y + right.Z * right.Z);
        return length1 > length2;
    }

    public static bool operator ==(Vector left, Vector right)
    {
        return left.X == right.X && left.Y == right.Y && left.Z == right.Z;
    }

    public static bool operator !=(Vector left, Vector right)
    {
        return !(left == right);
    }

    public override bool Equals(Object obj)
    {
        //Check for null and compare run-time types.
        if ((obj == null) || !this.GetType().Equals(obj.GetType()))
        {
            return false;
        }
        else
        {
            Vector v = (Vector)obj;
            return (x == v.x) && (y == v.y) && (z == v.z);
        }
    }
    public override int GetHashCode()
    {
        return 0;
    }
}

class lab3task1
{
    static void Main()
    {
        Vector v1 = new Vector(3.0, 3.0, 3.0);
        Vector v2 = new Vector(3.0, 4.0, 5.0);

        Vector sum = v1 + v2;
        double Scalar_multiplication = v1 * v2;
        Vector scaled = v1 * 2.0;
        bool comparison = v1 < v2;

        Console.WriteLine($"Sum: ({sum.X}, {sum.Y}, {sum.Z})");
        Console.WriteLine($"Scalar multiplication: {Scalar_multiplication}");
        Console.WriteLine($"Scaled: ({scaled.X}, {scaled.Y}, {scaled.Z})");
        Console.WriteLine($"v1 < v2: {comparison}");

        Vector v3 = new Vector(1.0, 2.0, 3.0);
        bool isEqual = v1 == v3;
        Console.WriteLine($"v1 == v3: {isEqual}");
    }
}
