using Common;

Console.WriteLine("HELLO!");


class Heap
{
    List<int> Data = [];

    int RootNode => Data.First();

    int LastNode => Data.Last();

    int LeftChildIndex(int index) => index * 2 + 1;

    int RightChildIndex(int index) => index * 2 + 2;

    int ParentIndex(int index) => (index - 1) / 2;

    void Insert(int value)
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

    void Delete()
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
        bool HasGreaterChild(int index)
        {
            return (Data.TryGet(LeftChildIndex(index), out var lcValue) && lcValue > Data[index]) ||
                   (Data.TryGet(RightChildIndex(index), out var rcValue) && rcValue > Data[index]);
        }
        
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
}