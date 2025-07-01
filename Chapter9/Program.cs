var linter = new Linter();

Console.WriteLine(linter.Lint("( var x = { y: [1, 2, 3] } )"));
Console.WriteLine(linter.Lint("( var x = ) y: {1, 2, 3} ( ) []"));


class Stack<T> {
	private List<T> Data { get; set; }

    public Stack()
    {
        Data = new List<T>();
    }

    public void Push(T element)
    {
        Data.Add(element);
    }

    public T Pop()
    {
        if (Data.Count == 0)
            return default(T);

        T last = Data[^1];
        Data.RemoveAt(Data.Count - 1);
        return last;
    }

    public T Read()
    {
        return Data.LastOrDefault();
    }
}

class Linter {
    private Stack<char> Stack { get; set; }

    public Linter() {
        Stack = new Stack<char>();
    }

    public string Lint(string text) {
        foreach (var c in text) {
            if (IsOpeningBrace(c)) {
                Stack.Push(c);
            }
            else if (IsClosingBrace(c)) {
                var top = Stack.Pop();

                if (top == default(char)) {
                    return $"'{c}' does not have opening brace";
                }

                if (IsNotMatch(top, c)) {
                    return $"'{c}' has mismatched opening brace";
                }
            }
        }

        var value = Stack.Read();

        if (value != default(char)) {
            return $"'{value}' does not have closing brace";
        }

        return "No issue found";
    }

    private bool IsOpeningBrace(char c) {
        return c == '(' || c == '[' || c == '{';
    }

    private bool IsClosingBrace(char c) {
        return c == ')' || c == ']' || c == '}';
    }

    private bool IsNotMatch(char opening, char closing) {
        return closing != new Dictionary<char, char>
        {
            { '(', ')' },
            { '[', ']' },
            { '{', '}' }
        }[opening];
    }
}



