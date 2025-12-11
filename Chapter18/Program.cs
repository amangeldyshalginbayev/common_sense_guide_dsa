

var alice = new Vertex("alice");
var bob = new Vertex("bob");
var synthia = new Vertex("synthia");

alice.AddAdjacentVertex(bob);
alice.AddAdjacentVertex(synthia);
bob.AddAdjacentVertex(synthia);
synthia.AddAdjacentVertex(bob);

DFStraverse(alice);

void DFStraverse(Vertex vertex, Dictionary<string, bool> visitedVertices = null) {
	visitedVertices ??= new();

	visitedVertices.Add(vertex.Value, true);

	Console.WriteLine(vertex.Value);

	foreach(var v in vertex.AdjacentVertices) {
		if (visitedVertices.ContainsKey(v.Value))
			continue;
		DFStraverse(v, visitedVertices);
	}
}

Vertex DFS(Vertex vertex, string searchValue, Dictionary<string, bool> visitedVertices) {
	visitedVertices ??= new();

	if (vertex.Value == searchValue) {
		return vertex;
	}

	visitedVertices.Add(vertex.Value, true);

	foreach (var v in vertex.AdjacentVertices) {
		if (visitedVertices.ContainsKey(v.Value))
			continue;

		var vertexSearched = DFS(v, searchValue, visitedVertices);
		return vertexSearched;
	}

	return null;
}

class Vertex {
	public string Value { get; set; }
	public List<Vertex> AdjacentVertices { get; set; }

	public Vertex(string value) {
		Value = value;
		AdjacentVertices = new();
	}

	public void AddAdjacentVertex(Vertex vertex, bool isRecipient = true) {
		if (AdjacentVertices.Contains(vertex)) {
			Console.WriteLine($"{Value} is already friend with {vertex.Value}");
			return;
		}
			 
		AdjacentVertices.Add(vertex);
		if (isRecipient)
			vertex.AddAdjacentVertex(this, false);
	}

}


