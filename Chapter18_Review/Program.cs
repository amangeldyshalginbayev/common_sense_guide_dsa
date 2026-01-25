

var alice = new Vertex("alice");
var bob = new Vertex("bob");
var cynthia = new Vertex("cynthia");

alice.AddAdjacentVertex(bob);
alice.AddAdjacentVertex(cynthia);
bob.AddAdjacentVertex(cynthia);
cynthia.AddAdjacentVertex(bob);

var a = new Vertex("a");
var b = new Vertex("b");
var c = new Vertex("c");
var d = new Vertex("d");
var e = new Vertex("e");

a.AddAdjacentVertex(b);
b.AddAdjacentVertex(c);
a.AddAdjacentVertex(d);
a.AddAdjacentVertex(e);

DFStraverse(a);

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

class Vertex {
	public string Value { get; set; }
	public List<Vertex> AdjacentVertices { get; set; }

	public Vertex(string value) {
		Value = value;
		AdjacentVertices = new();
	}

	public void AddAdjacentVertex(Vertex vertex) {
		if (AdjacentVertices.Contains(vertex)) {
			Console.WriteLine($"{Value} is already friend with {vertex.Value}");
			return;
		}

		AdjacentVertices.Add(vertex);
		vertex.AddAdjacentVertex(this);
	}
}


