Console.WriteLine("Chapter9");


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
            throw new InvalidOperationException("Stack is empty.");

        T last = Data[^1];
        Data.RemoveAt(Data.Count - 1);
        return last;
    }

    public T Read()
    {
        return Data.LastOrDefault();
    }
}
