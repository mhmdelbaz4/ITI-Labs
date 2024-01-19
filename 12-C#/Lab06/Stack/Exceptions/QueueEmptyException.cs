namespace StackAndQueue.Exceptions;

public class QueueEmptyException:Exception
{
    public QueueEmptyException(string message):base(message)
    {}
}
