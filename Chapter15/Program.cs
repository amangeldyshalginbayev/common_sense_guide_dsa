
Console.WriteLine("");

var node1 = new TreeNode(25);
var node2 = new TreeNode(75);
var root = new TreeNode(50, node1, node2);
Delete(50, root);
Console.WriteLine("stop here");

static void TraverseAndPrint(TreeNode node) {
	if (node == null) {
		return;
	}
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