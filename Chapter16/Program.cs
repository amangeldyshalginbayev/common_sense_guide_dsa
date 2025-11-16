

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

	void Delete() {
		Data[0] = Data[Count - 1];
		Data.RemoveAt(Data.Count - 1);

		

				

	}
}