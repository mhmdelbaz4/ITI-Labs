namespace StackAndQueue.Exceptions;

public class StackOverflowException : Exception
{
    public StackOverflowException(string message) : base(message)
    {
    }
}
