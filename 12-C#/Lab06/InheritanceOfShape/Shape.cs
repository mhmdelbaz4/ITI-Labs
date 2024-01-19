using InheritanceOfShape.Exceptions;

namespace InheritanceOfShape;

abstract class Shape
{
    int dim1;
    int dim2;

    public int Dim1 {get => dim1;
        set 
        {
            if (value < 0)
                throw new ShapeDimensionLengthException("Invalid Dimension length");

            dim1 = value;
        }
    }
    public int Dim2
    {
        get => dim2;
        set
        {
            if (value < 0)
                throw new ShapeDimensionLengthException("Invalid Dimension length");

            dim2 = value;
        }
    }


    public abstract int GetArea();

    public abstract int GetPer();

    public override string ToString()
    {
        return $"Dim1 :{Dim1} ,Dim2 :{Dim2}";
    }

    public override bool Equals(object? obj)
    {
        if(obj?.GetType() != typeof(Shape))
            return false;

        if (object.ReferenceEquals(this, obj))
            return true;

        Shape other = obj as Shape;
           
        return other.Dim1 == this.Dim1 && other.Dim2 == this.Dim2;
    }

}
