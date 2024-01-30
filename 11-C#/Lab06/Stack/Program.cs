using StackAndQueue;

// InvalidCollectionSize Exception
//Queue queue1 = new Queue(5);

Queue queue1 = new Queue(5);
queue1.Enqueue(10);
queue1.Enqueue(20);
queue1.Enqueue(30);
queue1.Enqueue(40);
queue1.Enqueue(50);
Console.WriteLine($"Queue1 {queue1}");

//QueueFullException
//queue1.Enqueue(60);

Queue queue2 = new Queue(5);

queue2.Enqueue(10);
queue2.Enqueue(20);
queue2.Enqueue(30);
queue2.Enqueue(40);
queue2.Enqueue(50);
Console.WriteLine($"Queue2 {queue2}");

Console.WriteLine($"Queue1 + Queue2 = {queue1 + queue2}");
Console.WriteLine($"(Queue1 == Queue2) = {queue1.Equals(queue2)}");