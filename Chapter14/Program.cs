

var node1 = new Node("once");
var node2 = new Node("upon");
var node3 = new Node("a");
var node4 = new Node("time");

node1.NextNode = node2;
node2.NextNode = node3;
node3.NextNode = node4;

var list = new LinkedList(node1);

Console.WriteLine(list.Read(0));
Console.WriteLine(list.FindIndex("time"));
Console.WriteLine(list.FindIndex("testValue"));

public class Node {
	public string Data { get; set; }
	public Node NextNode { get; set; }

	public Node(string data) {
		Data = data;
	}
}

public class LinkedList {
	public Node FirstNode { get; set; }
	
	
	public LinkedList(Node firstNode) {
		FirstNode = firstNode;
	}

	public string Read(int index) {
		var currentNode = FirstNode;
		var currentIndex = 0;

		while (currentIndex < index) {
			currentNode = currentNode.NextNode;
			currentIndex += 1;

			if (currentNode == null) {
				return string.Empty;
			}
		}

		return currentNode.Data;
	}

	public int FindIndex(string value) {
		var currentNode = FirstNode;
		var currentIndex = 0;

		while (currentNode != null) {
			if (currentNode.Data == value) {
				return currentIndex;
			}
			
			currentNode = currentNode.NextNode;
			currentIndex += 1;
		}	

		return -1;
	}

	public void InsertAtIndex(int index, string value) {

		var newNode = new Node(value);

		if (index == 0) {
			newNode.NextNode = FirstNode;
			FirstNode = newNode;
		}
		else {
			var currentNode = FirstNode;
			var currentIndex = 0;

			while (currentIndex < index - 1) {
				currentNode = currentNode.NextNode;
				currentIndex += 1;
			}

			newNode.NextNode = currentNode.NextNode;
			currentNode.NextNode = newNode;
		}
	}





}