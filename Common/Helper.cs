namespace Common;

public static class Helper {
    public static void PrintElements<T>(IEnumerable<T> elements)
    {
        Console.Write("\n [ ");
        foreach (var element in elements)
        {
            Console.Write($"{element} ");
        }
        Console.Write(" ] ");
    } 
}