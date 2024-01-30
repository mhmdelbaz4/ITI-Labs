Duration d1 = new Duration(1000);
Console.WriteLine($"D1 -> {d1}");
Duration d2 = new Duration(70, 70, 1);
Console.WriteLine($"D2 -> {d2}");

Console.WriteLine($"D1+D2 = {d1+d2}");
Console.WriteLine($"D1>D2 = {d1 > d2}");
Console.WriteLine($"D1<D2 = {d1 < d2}");
Console.WriteLine($"D1+100 = {d1+100}");
Console.WriteLine($"100+d1 = {100+d1}");
Console.WriteLine($"D1++ = {d1++}");
Console.WriteLine($"D1-- = {d1--}");

if(d1)
{
    Console.WriteLine("true");
}

Console.WriteLine($"(DateTime)D1 = {(DateTime)d1}");
