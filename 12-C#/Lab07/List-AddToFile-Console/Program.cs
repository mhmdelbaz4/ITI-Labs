using List_AddToFile_Console;

string? path = "D:\\ITI\\ITI-Labs\\12-C#\\Lab07\\Lab07\\List-AddToFile-Console\\data.txt";
NList<string> newList = new NList<string>(path);

newList.Add("Hello World!");

Console.WriteLine(newList.Read());

