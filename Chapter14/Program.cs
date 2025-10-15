
// Ex14.5
// Works unless node is tail
// Deletes node from classic linked list
static void DeleteNode(Node node) {
    node.Data = node.NextNode.Data;
    node.NextNode = node.NextNode.NextNode;
}


var node1 = new Node("once");
var node2 = new Node("upon");
var node3 = new Node("a");
var node4 = new Node("time");

node1.NextNode = node2;
node2.NextNode = node3;
node3.NextNode = node4;

var list = new LinkedList(node1);
var lastNode = list.GetLast();
Console.Write($"Last element -> {lastNode.Data}");

//list.Print();
//Console.WriteLine(list.Read(0));
//Console.WriteLine(list.FindIndex("time"));
//Console.WriteLine(list.FindIndex("testValue"));

var doubleNode1 = new DoubleNode("once");
var doubleNode2 = new DoubleNode("upon");
var doubleNode3 = new DoubleNode("a");
var doubleNode4 = new DoubleNode("time");

doubleNode1.NextNode = doubleNode2;

doubleNode2.NextNode = doubleNode3;
doubleNode2.PrevNode = doubleNode1;

doubleNode3.NextNode = doubleNode4;
doubleNode3.PrevNode = doubleNode2;

doubleNode4.PrevNode = doubleNode3;



var doubleList = new DoublyLinkedList(doubleNode1, doubleNode4);
//doubleList.PrintReverse();

public class Node
{
    public string Data { get; set; }
    public Node NextNode { get; set; }

    public Node(string data)
    {
        Data = data;
    }
}

public class LinkedList
{
    public Node FirstNode { get; set; }

    // Ex14.1
    public void Print() {
        var currentNode = FirstNode;

        while (currentNode != null) {
            Console.WriteLine(currentNode.Data);
            currentNode = currentNode.NextNode;
        }
    }

    // Ex 14.3
    public Node GetLast() {
        var currentNode = FirstNode;

        while (currentNode != null) {
            if (currentNode.NextNode == null) {
                return currentNode;
            }
            else {
                currentNode = currentNode.NextNode;
            }
        }

        throw new Exception("LinkedList not initialized yet");
    }

    
    // Ex 14.4
    public void Reverse() {
        Node previousNode = null;
        var currentNode = FirstNode;

        while (currentNode != null) {
            var nextNode = currentNode.NextNode;

            currentNode.NextNode = previousNode;
            previousNode = currentNode;
            currentNode = nextNode;
        }

        FirstNode = previousNode;
    }


    public LinkedList(Node firstNode)
    {
        FirstNode = firstNode;
    }

    public string Read(int index)
    {
        var currentNode = FirstNode;
        var currentIndex = 0;

        while (currentIndex < index)
        {
            currentNode = currentNode.NextNode;
            currentIndex += 1;

            if (currentNode == null)
            {
                return string.Empty;
            }
        }

        return currentNode.Data;
    }

    public int FindIndex(string value)
    {
        var currentNode = FirstNode;
        var currentIndex = 0;

        while (currentNode != null)
        {
            if (currentNode.Data == value)
            {
                return currentIndex;
            }

            currentNode = currentNode.NextNode;
            currentIndex += 1;
        }

        return -1;
    }

    public void InsertAtIndex(int index, string value)
    {
        var newNode = new Node(value);

        if (index == 0)
        {
            newNode.NextNode = FirstNode;
            FirstNode = newNode;
        }
        else
        {
            var currentNode = FirstNode;
            var currentIndex = 0;

            while (currentIndex < index - 1)
            {
                currentNode = currentNode.NextNode;
                currentIndex += 1;
            }

            newNode.NextNode = currentNode.NextNode;
            currentNode.NextNode = newNode;
        }
    }

    public void DeleteAtIndex(int index)
    {
        if (index == 0)
        {
            FirstNode = FirstNode.NextNode;
        }
        else
        {
            var currentNode = FirstNode;
            var currentIndex = 0;

            while (currentIndex < index - 1)
            {
                currentNode = currentNode.NextNode;
                currentIndex += 1;
            }

            var nodeAfterDeletedNode = currentNode.NextNode.NextNode;
            currentNode.NextNode = nodeAfterDeletedNode;
        }
    }
}


public class DoubleNode
{
    public string Data { get; set; }
    public DoubleNode NextNode { get; set; }
    public DoubleNode PrevNode { get; set; }

    public DoubleNode(string data)
    {
        Data = data;
    }
}

public class DoublyLinkedList
{
    public DoubleNode FirstNode { get; set; }
    public DoubleNode LastNode { get; set; }

    public DoublyLinkedList(DoubleNode firstNode = null, DoubleNode lastNode = null)
    {
        FirstNode = firstNode;
        LastNode = lastNode;
    }

    // Ex14.2
    public void PrintReverse() {
        var currentNode = LastNode;

        while (currentNode != null) {
            Console.WriteLine(currentNode.Data);
            currentNode = currentNode.PrevNode;
        }
    }

    public void InsertAtEnd(string value)
    {
        var node = new DoubleNode(value);

        if (FirstNode == null)
        {
            FirstNode = node;
            LastNode = node;
        }
        else
        {
            LastNode.NextNode = node;
            node.PrevNode = LastNode;
            LastNode = node;
        }
    }

    public DoubleNode RemoveFromFront()
    {
        var removedNode = FirstNode;
        FirstNode = FirstNode.NextNode;
        return removedNode;
    }
}

public class Queue
{
    public DoublyLinkedList Data { get; set; }

    public Queue()
    {
        Data = new DoublyLinkedList();
    }

    public void Enqueue(string value)
    {
        Data.InsertAtEnd(value);
    }

    public string Dequeue()
    {
        var removedNode = Data.RemoveFromFront();
        return removedNode.Data;
    }

    public string Read()
    {
        if (Data.FirstNode == null)
        {
            return string.Empty;
        }
        else
        {
            return Data.FirstNode.Data;
        }
    }
}
