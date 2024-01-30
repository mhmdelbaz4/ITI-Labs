namespace InheritanceOfShape;

internal class Rectangle : Shape
{
    public override int GetArea()
    {
        return Dim1 * Dim2;
    }

    public override int GetPer()
    {
        return (Dim1 + Dim2) * 2;
    }

    public override string ToString()
    {
        return $"Rectangle[{Dim1},{Dim2}]";
    }
}
