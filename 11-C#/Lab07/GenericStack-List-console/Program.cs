using GenericStack_List_console;

GStack<int> stackInt = new GStack<int>();
stackInt.Push(10);
stackInt.Push(20);
stackInt.Push(30);
stackInt.Push(40);
stackInt.Push(50);
Console.WriteLine("**************Type is int**********");
Console.WriteLine(stackInt.ToString());

GStack<string> stackStr = new GStack<string>();
stackStr.Push("ahmed");
stackStr.Push("omar");
stackStr.Push("osama");
stackStr.Push("Ibrahim");
stackStr.Push("ali");
Console.WriteLine("**************Type is string**********");
Console.WriteLine(stackStr.ToString());
