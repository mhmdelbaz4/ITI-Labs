using _3DPoint;

Point3D point1 = new Point3D(10, 20, 30);
Point3D point2 = new Point3D(10,20,30);
Point3D point3 =point1 + point2;
Point3D point4 = point1 - point2;

Console.WriteLine($"Point1 {point1}");
Console.WriteLine($"Point2 {point2}");
Console.WriteLine($"Point1 + point2 {point3}");
Console.WriteLine($"Point1 - point2 {point4}");
Console.WriteLine($"Point1 == point2 --> {point1 == point2}");


string str1 =point1.ToString();
string str2 =(string) point1;
Console.WriteLine($"casting point1 using tostring()--> {point1}");
Console.WriteLine($"casting point1 using string explicit casting--> {point1}");



int size, tempData;
Console.WriteLine("Enter array size");
while (!int.TryParse(Console.ReadLine(), out size) || size<=0)
{
    Console.WriteLine("Wrong Size !!!!");
    Console.Write("Enter size Again :");
}

Point3D[] arr = new Point3D[size];

for (int i = 0; i < size; i++)
{
    Console.WriteLine("**********Points Data************");
    Console.WriteLine($"**************Point {i + 1} Data*************** ");

    for (int j = 1; j < 4; j++)
    {
        arr[i] = new Point3D(0, 0, 0);

        Console.Write($"Enter Coordinate {j} :");
        while (! int.TryParse(Console.ReadLine(), out tempData))
        {
            Console.WriteLine("oppppppppps , Wrong number!!!");
            Console.Write("Enter X Again :");
        }

        switch (j)
        {
            case 1: arr[i].X = tempData; break;
            case 2: arr[i].Y = tempData; break;
            case 3: arr[i].Z = tempData; break;
        }
    }
}

Console.WriteLine("***********Data***************");
for (int i = 0; i < arr.Length; i++)
{
    Console.WriteLine(arr[i]);
}