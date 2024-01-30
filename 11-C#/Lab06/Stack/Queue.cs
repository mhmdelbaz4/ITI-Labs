using StackAndQueue.Exceptions;
using System.Text;

namespace StackAndQueue;

public class Queue
{
    int size =5;
    int rear;
    int[] values;


    public Queue(int _size)
    {
        Size = _size;
        rear = -1;
        values = new int[Size];
    }

    public int Size
    {
        get => size;
        private set
        {
            if(value > 0)
            {
                size = value;
            }
            else
            {
                throw new InvalidCollectionSize("Collection size is wrong!");
            }
        }
    }

    public void Enqueue(int value)
    {
        if(rear == size-1)
        {
            throw new QueueFullException("Queue is full");
        }

        values[++rear] = value;
    }

    public int Dequeue()
    {
        if (rear == -1)
        {
            throw new QueueEmptyException("Queue is Empty");
        }

        int result = values[0];

        rear--;
        for (int i = 0; i<rear;i++)
        {
            values[i] = values[i + 1];
        }


        return result;
    }

    public bool TryEnqueue(int value)
    {

        try
        {
            Enqueue(value);
            return true;
        }
        catch(QueueFullException)
        {
            return false;
        }

    }
    public bool TryDequeue(int value ,out int result)
    {
        result = 0;

        try
        {
            result = this.Dequeue();
            return true;
        }
        catch (QueueEmptyException)
        {
            return false;
        }
        
    }

    public int GetFront()
    {
        if(rear==-1)
        {
            throw new QueueEmptyException("Queue is empty");
        }    

        return values[0];
    }

    public static Queue operator+(Queue left, Queue right)
    {
        int newSize = right.Size + left.Size;
        Queue resultQueue = new Queue(newSize);

        for (int i = 0; i < left.Size; i++)
            resultQueue.Enqueue(left.values[i]);


        for (int i = 0; i < right.Size; i++)
            resultQueue.Enqueue(right.values[i]);

        return resultQueue;
    }

    public override bool Equals(object? obj)
    {
        if (obj?.GetType() != typeof(Queue))
            return false;

        if(object.ReferenceEquals(this, obj))
            return true;
 
        Queue other = obj as Queue;

        bool isEqual = this.values.SequenceEqual(other.values) 
                       && this.Size == other.Size
                       && this.rear == other.rear;

        return isEqual;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder("[");
        for (int i = 0; i <= rear; i++)
        {
            sb.Append(values[i]);
            if (i < rear)
                sb.Append(", ");
        }
        sb.Append("]");
        return sb.ToString();
    }
}
