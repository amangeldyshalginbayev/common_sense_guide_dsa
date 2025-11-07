def delete(valueToDelete, node):
	
	if node is None:
		return None
	
	elif valueToDelete < node.value:
		node.leftChild = delete(valueToDelete, node.leftChild)
		return node
	
	elif valueToDelete > node.value:
		node.rightChild = delete(valueToDelete, node.rightChild)
		return node
	
	elif valueToDelete == node.value:
		
		if node.leftChild is None:
			return node.rightChild
		
		elif node.rightChild is None:
			return node.leftChild

		else:
			node.rightChild = lift(node.rightChild, node)
			return node

def lift(node, nodeToDelete):
	
	if node.leftChild:
		node.leftChild = lift(node.leftChild, nodeToDelete)
		return node
	
	else:
		nodeToDelete.value = node.value
		return node.rightChild


def delete(value, node):
    if node is None:
        return None

    # search left or right
    if value < node.value:
        node.leftChild = delete(value, node.leftChild)
    elif value > node.value:
        node.rightChild = delete(value, node.rightChild)
    else:
        # value == node.value → found node to delete

        # case 1: no left child
        if node.leftChild is None:
            return node.rightChild

        # case 2: no right child
        if node.rightChild is None:
            return node.leftChild

        # case 3: two children → find smallest in right subtree
        min_node = find_min(node.rightChild)
        node.value = min_node.value
        node.rightChild = delete(min_node.value, node.rightChild)

    return node


def find_min(node):
    """Return the node with the smallest value in a subtree."""
    while node.leftChild:
        node = node.leftChild
    return node


	


