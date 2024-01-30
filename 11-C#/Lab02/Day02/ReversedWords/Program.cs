using System.Text;

Console.WriteLine("Enter a sentence :");
string? sentence = Console.ReadLine()?.Trim();

while (string.IsNullOrEmpty(sentence) || isNumber(sentence))
{
    Console.WriteLine("Opps you entered a wrong sentence!!");
    Console.WriteLine("Enter sentence again :");
    sentence = Console.ReadLine()?.Trim();
};

string result = ReverseWords(sentence);

Console.WriteLine($"Reversed sentence : {result}");


static string ReverseWords(string value)
{
    StringBuilder sb = new StringBuilder();

    string[] arr =  value.Split(' ');
    
    for(int i=arr.Length; i>0; i--)
    {
        if (arr[i-1] == "")
            continue;

        sb.Append(arr[i-1]);
        sb.Append(' ');
    }

    return sb.ToString();
}

static bool isNumber(string value)
{
    if (long.TryParse(value, out var n1))
        return true;

    if(Decimal.TryParse(value ,out var n2))
        return true;

    return false;
}