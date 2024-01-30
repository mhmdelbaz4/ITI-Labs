namespace List_AddToFile_Console;
using System.IO;
using System.Text;


internal class NList<T>:List<T>
{
    string? filePath ;
    StreamReader sr;
    StreamWriter sw;

    public NList(string? path)
    {
        filePath = path;
    }

    public void Add(T value)
    {
        base.Add(value);
        sw = new StreamWriter(filePath);
        sw.WriteLine(value);
        sw.Close();
    }

    public string Read()
    {
        sr = new StreamReader(filePath);
        string temp = sr.ReadToEnd();
        sr.Close();
        return temp;
    }
    
    ~NList()
    {
        sr.Dispose();
        sw.Dispose();
    }
    
}
