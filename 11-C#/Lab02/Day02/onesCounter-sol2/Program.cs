using System.Diagnostics;

int num = 99999999;

Stopwatch stopwatch = new Stopwatch();

stopwatch.Start();
int result = countOnes(num);
stopwatch.Stop();

Console.WriteLine(result);
Console.WriteLine(stopwatch.ElapsedMilliseconds);



static int countOnes(int value)
{
    if (value.ToString().Length == 1)
        return 0;

    if (value.ToString().Length == 2)
        return 20;

    int power = value.ToString().Length - 1;

    return 9 * countOnes(value / 10) +(int) Math.Pow(10,power)+ countOnes(value / 10);
}


/// 9999 : 9* count() * 

/*
 *      2 digits -> 11
        3 digits -> 9*(2 digits)+100
        4 digits -> 9*(3 digits)+1000

 *  1->99   =11         10+1

    1
    10
    11
    21
    31
    41
    51  
    61
    71
    81  
    91

    100->999
    9*11 + 100           9*(2 digits)+100

    1000-> 9999
    9*(3 digits) +1000   9*(9(2 digits)+100)+1000 
 
    

    number = 9*digitsNo + 10**(digitsno-1)
      
 */
