
Console.WriteLine("");

var node1 = new TreeNode(25);
var node2 = new TreeNode(75);
var root = new TreeNode(50, node1, node2);

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