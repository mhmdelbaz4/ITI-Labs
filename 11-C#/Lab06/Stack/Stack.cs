using System.Text;
namespace StackAndQueue.Exceptions;

public class Stack
{
    private int[] values;
    private int top;
    private int size;


    public Stack(int _size)
    {
        Size = _size;
        values = new int[Size];
        top = -1;
    }

    public int Size
    {
        get => size;
        private set
        {
            if (value > 0)
                top = value;
            else
                throw new InvalidCollectionSize("Collection size is wrong!");
        }
    }

    public void Push(int value)
    {
        if (top == Size - 1)
            throw new StackOverflowException("Stack overflow");

        values[++top] = value;
    }


    public int Pop()
    {
        if (top == -1)
            throw new StackUnderflowException("Stack underflow");

        return values[top--];
    }


    public int GetTop()
    {
        if (top == -1)
            throw new StackUnderflowException("Stack is empty");

        return values[top];
    }

    public static Stack operator +(Stack s1, Stack s2)
    {
        int newSize = s1.Size + s2.Size;
        Stack result = new Stack(newSize);

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


    public bool TryPush(int value)
    {

        try
        {
            Push(value);
            return true;
        }
        catch (StackOverflowException)
        {
            return false;
        }

    }

    public bool TryPop(out int result)
    {
        result = 0;

        try
        {
            result = Pop();
            return true;
        }
        catch (StackUnderflowException)
        {
            return false;
        }
    }

    public override bool Equals(object obj)
    {
        if (obj?.GetType() != typeof(Stack))
            return false;

        if (object.ReferenceEquals(this, obj))
            return true;

        Stack? other = obj as Stack;

        bool isEqual = this.values.SequenceEqual(other.values)
                       && this.Size == other.Size
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