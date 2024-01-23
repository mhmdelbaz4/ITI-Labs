namespace GenericStack_List_console;
using System.Text;

public class GStack<T> where T : IComparable<T>
{

    List<T> values;
    int top;

    public GStack()
    {
        values = new List<T>();
        top = -1;
    }

    public void Push(T value)
    {
        values.Add(value);
        top++;
    }


    public T Pop()
    {
        if (top != -1)
            return values[top--];

        throw new StackOverflowException("stack is empty!!");
    }


    public T GetTop()
    {
        if (top == -1)
            throw new StackOverflowException("stack is empty!!");

        return values[top];
    }

    public static GStack<T> operator +(GStack<T> s1, GStack<T> s2)
    {
        GStack<T> result = new GStack<T>();

        // Copy values from s1
        for (int i = 0; i <= s1.top; i++)
        {
            result.Push(s1.values[i]);
        }

        // Copy values from s2
        for (int i = 0; i <= s2.top; i++)
        {
            result.Push(s2.values[i]);
        }

        return result;
    }


    public bool TryPop(out T result)
    {
        result = default;

        try
        {
            result = Pop();
            return true;
        }
        catch
        {
            return false;
        }
    }

    public override bool Equals(object obj)
    {
        if (obj is null) return false;

        GStack<T>? other = obj as GStack<T>;

        if (obj?.GetType() != typeof(GStack<T>))
            return false;

        if (object.ReferenceEquals(this, obj))
            return true;


        bool isEqual = this.values.SequenceEqual(other.values)
                       && this.top == other.top;

        return isEqual;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder("[");
        for (int i = 0; i <= top; i++)
        {
            sb.Append(values[i]);
            if (i < top)
                sb.Append(", ");
        }
        sb.Append("]");
        return sb.ToString();
    }
}