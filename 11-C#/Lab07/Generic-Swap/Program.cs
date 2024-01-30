using Generic_Swap;

int num1 = 10;
int num2 = 20;
Console.WriteLine("****************Type is int**************");
Console.WriteLine("::Before Swap::");
Console.WriteLine($"num1={num1} & num2={num2}");
Swap<int>(ref num1, ref num2);
Console.WriteLine("::After Swap::");
Console.WriteLine($"num1={num1} & num2={num2}");
Console.WriteLine("==============================");


Console.WriteLine("****************Type is float**************");
float f1 = 20.5f;
float f2 = 30.7f;
Console.WriteLine("::Before Swap::");
Console.WriteLine($"num1={f1} & num2={f2}");
Swap<float>(ref f1, ref f2);
Console.WriteLine("::After Swap::");
Console.WriteLine($"num1={f1} & num2={f2}");
Console.WriteLine("==============================");


Console.WriteLine("****************Type is Employee (Struct)**************");
Employee emp1 = new Employee(100, "ahmed", 3000);
Employee emp2 = new Employee(200, "Omar", 5000);
Console.WriteLine("::Before Swap::");
Console.WriteLine($"emp1={emp1} \nemp2={emp2}");
Swap<Employee>(ref emp1, ref emp2);
Console.WriteLine("::After Swap::");
Console.WriteLine($"emp1={emp1} \nemp2={emp2}");
Console.WriteLine("==============================");


static void Swap<T>(ref T item1,ref T item2) where T : struct
{
    T temp = item1;
    item1 = item2;
    item2 = temp;
}