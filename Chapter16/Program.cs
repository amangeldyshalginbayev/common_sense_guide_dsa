using Common;

Console.WriteLine("HELLO!");

// Ex 16.1
var heap = new Heap
{
    Data = [10, 9, 8, 6, 5, 7, 4, 2, 1, 3]
};
heap.Print();
heap.Insert(11);
heap.Print();

// Ex 16.2
heap.Delete();
heap.Print();

heap = new Heap();
var numbers = new List<int>  {55, 22, 34, 10, 2, 99, 68};
numbers.ForEach(n => heap.Insert(n));
Console.WriteLine("Initial Heap: ");
heap.Print();
var result = new List<int>();
while (heap.HasValue)
{
    result.Add(heap.Pop());
}
Console.WriteLine("Result array: ");
result.PrintElements();

class Heap
{
    public List<int> Data = [];

    int RootNode => Data.First();

    int LastNode => Data.Last();

    int LeftChildIndex(int index) => index * 2 + 1;

    int RightChildIndex(int index) => index * 2 + 2;

    int ParentIndex(int index) => (index - 1) / 2;

    public void Insert(int value)
    {
        // Insert as Last Node
        Data.Add(value);

        var newNodeIndex = Data.Count - 1;

        // trickle up algorithm
        while (newNodeIndex > 0)
        {
            int parentIndex = ParentIndex(newNodeIndex);

            if (Data[newNodeIndex] <= Data[parentIndex])
                break;

            (Data[parentIndex], Data[newNodeIndex]) = (Data[newNodeIndex], Data[parentIndex]);

            newNodeIndex = parentIndex;
        }
    }

    public void Delete()
    {
        var lastIndex = Data.Count - 1;
        Data[0] = Data[lastIndex];
        Data.RemoveAt(lastIndex);

        var trickleNodeIndex = 0;

        // Trickle down algorithm
        while (HasGreaterChild(trickleNodeIndex))
        {
            var largerChildIndex = FindLargerChildIndex(trickleNodeIndex);
            
            (Data[trickleNodeIndex], Data[largerChildIndex]) = (Data[largerChildIndex], Data[trickleNodeIndex]);
            
            trickleNodeIndex = largerChildIndex;
        }
        // Checks whether there is a child node with greater value than the current node
        bool HasGreaterChild(int index)
        {
            return (Data.TryGet(LeftChildIndex(index), out var lcValue) && lcValue > Data[index]) ||
                   (Data.TryGet(RightChildIndex(index), out var rcValue) && rcValue > Data[index]);
        }
        
        // Function assumes that there is a child node when called
        int FindLargerChildIndex(int index)
        {
            var leftChildExists = Data.TryGet(LeftChildIndex(index), out var lcValue);
            var rightChildExists = Data.TryGet(RightChildIndex(index), out var rcValue);

            if (leftChildExists && rightChildExists)
            {
                return lcValue > rcValue ? LeftChildIndex(index) : RightChildIndex(index);
            }

            return rightChildExists ? RightChildIndex(index) : LeftChildIndex(index);
        }
    }

    public void Print()
    {
        Data.PrintElements();
    }
    
    public bool HasValue => Data.Count > 0;

    public int Pop()
    {
        var topExists = Data.TryGet(0, out var value);
        
        if (topExists)
        {
            Delete();
            return value;
        }
        
        throw new InvalidOperationException("Heap is empty.");
    }
}