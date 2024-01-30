int[] arr = ReadDataFromUser();
Console.WriteLine("**********************************");

int result = getMaxDistance(arr);

Console.WriteLine($"max distance = {result}");

static int[] ReadDataFromUser()
{
    int size = 0;

    Console.Write("Enter array size :");

    while (!int.TryParse(Console.ReadLine(), out size) || size <= 0)
    {
        Console.WriteLine("Opppps!! you entered a wrong number");
        Console.WriteLine("Enter array size :");
    }
    int[] arr = new int[size];

    for (int i = 0; i < size; i++)
    {
        Console.WriteLine($"Number {i + 1} :");
        while (!int.TryParse(Console.ReadLine(), out arr[i]))
        {
            Console.WriteLine("Wrong number!!!");
            Console.WriteLine($"Number {i + 1} agian :");
        }
    }

    return arr;
}

static int getMaxDistance(int[] arr)
{
    int max = 0;

    for(int i=0; i < arr.Length-1;i++)
    {
        for(int j=i+1; j<arr.Length; j++)
        {
            if (arr[i] == arr[j])
            {
                if(max < j-i)
                {
                    max = j - i -1;
                }
            }
        }
    }
    return max;
}
