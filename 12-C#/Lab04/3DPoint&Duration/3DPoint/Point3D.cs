using System.Numerics;

namespace _3DPoint;

internal class Point3D
{
    public int X { get; set; }

    public int Y { get; set; }

    public int Z { get; set; }

    public Point3D(int _x ,int _y, int _z)
    {
        X= _x;
        Y= _y;
        Z= _z;
    }

    public Point3D(int _x ,int _y) :this(_x,_y,0)
    {}

    public Point3D(int _x) : this(_x, 0, 0)
    { }


    public static explicit operator string(Point3D point)
    {
        return point.ToString();
    }

    public static Point3D operator+(Point3D left, Point3D right)
    {
        return new Point3D(left.X + right.X, left.Y + right.Y, left.Z + right.Z);
    }
    public static Point3D operator -(Point3D left, Point3D right)
    {
        return new Point3D(left.X - right.X, left.Y - right.Y, left.Z - right.Z);
    }


    public override string ToString()
    {
        return $"Point Coordinates: ({X},{Y},{Z})";
    }

}
