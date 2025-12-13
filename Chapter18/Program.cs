

var alice = new Vertex("alice");
var bob = new Vertex("bob");
var synthia = new Vertex("synthia");
var tanya = new Vertex("tanya");

alice.AddAdjacentVertex(bob);
alice.AddAdjacentVertex(synthia);
bob.AddAdjacentVertex(tanya);
bob.AddAdjacentVertex(synthia);
//synthia.AddAdjacentVertex(bob);


DFStraverse(alice);
var foundVertex = DFS(alice, "tanyak");
Console.WriteLine($"Found vertex => {foundVertex?.Value ?? string.Empty}");


var a = new Vertex("a");
var b = new Vertex("b");
var c = new Vertex("c");
a.AddAdjacentVertex(b);
a.AddAdjacentVertex(c);
foundVertex = DFS(a, "c");
Console.WriteLine($"Found vertex => {foundVertex?.Value ?? string.Empty}");

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

Vertex DFS(Vertex vertex, string searchValue, Dictionary<string, bool> visitedVertices = null) {
	visitedVertices ??= new();

	if (vertex.Value == searchValue) {
		return vertex;
	}

	visitedVertices.Add(vertex.Value, true);

	foreach (var v in vertex.AdjacentVertices) {
		if (visitedVertices.ContainsKey(v.Value))
			continue;

		var vertexSearched = DFS(v, searchValue, visitedVertices);
		
		if (vertexSearched != null) 
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


