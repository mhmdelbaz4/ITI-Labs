using System.Diagnostics;

int count = 0;

char[] tempArr;

Stopwatch stopwatch = Stopwatch.StartNew();
for (int number = 1; number < 100000000; number++)
{
    tempArr = number.ToString().ToCharArray();
    foreach (char temp in tempArr)
    {
        if (temp == '1')
            count++;
    }
}
stopwatch.Stop();
Console.WriteLine(count);
Console.WriteLine(stopwatch.ElapsedMilliseconds / 1000);







