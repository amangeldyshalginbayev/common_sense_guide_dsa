
//Console.WriteLine("");

//var node1 = new TreeNode(25);
//var node2 = new TreeNode(75);
//var root = new TreeNode(50, node1, node2);
//Delete(50, root);
//Console.WriteLine("stop here");


// Ex 15.1
var rootNode1 = new TreeNode(1);
var values = new List<int>{5, 9, 2, 4, 10, 6, 3, 8};
values.ForEach(v => Insert(v, rootNode1));
TraverseAndPrint(rootNode1);


static void TraverseAndPrint(TreeNode node) {
	if (node == null) {
		return;
	}

	TraverseAndPrint(node.LeftChild);
	Console.WriteLine(node.Value);
	TraverseAndPrint(node.RightChild);
}

// Ex 15.2
/*
If a well-balanced binary search tree contains 1,000 values, what is the
maximum number of steps it would take to search for a value within it?
log(1000) = 10
*/

// Ex 15.3
Console.WriteLine($"Greatest value => {FindGreatest(rootNode1)}");
static int FindGreatest(TreeNode root) {
	
	while (root != null && root.RightChild != null) {
		root = root.RightChild;
	}
	return root.Value;
}

// Ex 15.4
var rootNode2 = new TreeNode(15);
var values2 = new List<int>{10, 17, 2, 12, 16, 20};
values2.ForEach(v => Insert(v, rootNode2));
Console.WriteLine("Pre Order =>");
TraverseAndPrintPreOrder(rootNode2);

static void TraverseAndPrintPreOrder(TreeNode node) {
	if (node == null) {
		return;
	}
	Console.WriteLine(node.Value);
	TraverseAndPrintPreOrder(node.LeftChild);
	TraverseAndPrintPreOrder(node.RightChild);
}

// Ex 15.5
Console.WriteLine("Post order => ");
TraverseAndPrintPostOrder(rootNode2);
static void TraverseAndPrintPostOrder(TreeNode node) {
	if (node == null) {
		return;
	}
	TraverseAndPrintPostOrder(node.LeftChild);
	TraverseAndPrintPostOrder(node.RightChild);
	Console.WriteLine(node.Value);
}



static TreeNode Delete(int value, TreeNode node) {
	if (node == null) {
		return null;
	}
	else if (value > node.Value) {
		node.RightChild = Delete(value, node.RightChild);
	}
	else if (value < node.Value) {
		node.LeftChild = Delete(value, node.LeftChild);
	}
	else {
		// value == node.Value
		if (node.LeftChild == null) {
			return node.RightChild;
		}
		else if (node.RightChild == null) {
			return node.LeftChild;
		}
		else {
			// node has both children, so need to replace it with successor node
			var minNode = FindMin(node.RightChild);
			var minValue = minNode.Value;
			node.Value = minValue;
			node.RightChild = Delete(minValue, node.RightChild);
		}
	
	}

	return node;
}

static TreeNode FindMin(TreeNode node) {
	while (node.LeftChild != null) {
		node = node.LeftChild;
	}
	return node;
}


static void Insert(int value, TreeNode node) {
	if (value == node.Value) {
		throw new ArgumentException("Value already exists.");
	}
	else if (value < node.Value) {
		if (node.LeftChild == null) {
			node.LeftChild = new TreeNode(value);
		}
		else {
			Insert(value, node.LeftChild);
		}
	}
	else { // value > node.Value
		if (node.RightChild == null) {
			node.RightChild = new TreeNode(value);
		}
		else {
			Insert(value, node.RightChild);
		}
	}
}
	
static TreeNode Search(int value, TreeNode node) {
	if (node == null || node.Value == value) {
		return node;
	}
	else if (value < node.Value) {
		return Search(value, node.LeftChild);
	}
	else {
		return Search(value, node.RightChild);
	}
}

public class TreeNode {
	public int Value { get; set; }
	public TreeNode LeftChild { get; set; }
	public TreeNode RightChild { get; set; }

	public TreeNode(int value, TreeNode leftChild = null, TreeNode rightChild = null) {
		Value = value;
		LeftChild = leftChild;
		RightChild = rightChild;
	}
}