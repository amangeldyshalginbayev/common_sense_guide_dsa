
Console.WriteLine("");

var node1 = new TreeNode(25);
var node2 = new TreeNode(75);
var root = new TreeNode(50, node1, node2);

static TreeNode Delete(int value, TreeNode node) {
	
}

static Node FindMind(TreeNode node) {
	while (node.LeftChild != null) {
		node = node.LeftChild;
	}
	return node;
}


static TreeNode Insert(value, node) {
	if (value == node.Value) {
		throw new IllegalArgumentException("Value already exists.");
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