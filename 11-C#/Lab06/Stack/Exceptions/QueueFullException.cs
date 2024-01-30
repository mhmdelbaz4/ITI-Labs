namespace StackAndQueue.Exceptions;

public class QueueFullException :Exception
{
    public QueueFullException(string message) :base(message)
    {}
}
