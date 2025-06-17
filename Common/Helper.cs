namespace Common;

public static class Helper {
    public static void PrintElements<T>(IEnumerable<T> elements)
    {
        foreach (var element in elements)
        {
            Console.Write($"{element} ");
        }
    } 
}