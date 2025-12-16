

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
var d = new Vertex("d");
a.AddAdjacentVertex(b);
a.AddAdjacentVertex(c);
c.AddAdjacentVertex(d);
b.AddAdjacentVertex(d);
foundVertex = DFS(a, "c");
Console.WriteLine($"Found vertex => {foundVertex?.Value ?? string.Empty}");

Console.WriteLine("DFS experiments");
DFStraverse(a);
Console.WriteLine("BFS");
BFStraverse(a);
// Complexity of DFS/DFS O(V+2E) = O(V+E)


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

void BFStraverse(Vertex startVertex) {
	var queue = new Queue<Vertex>();
	var visitedVertices = new Dictionary<string, bool>();
	visitedVertices.Add(startVertex.Value, true);
	queue.Enqueue(startVertex);
	var visitCount = 0;

	while (queue.Count != 0) {
		var currentVertex = queue.Dequeue();
		Console.WriteLine($"Visiting => {currentVertex.Value}");

		foreach (var v in currentVertex.AdjacentVertices) {
			visitCount++;
			if (!visitedVertices.ContainsKey(v.Value)) {
				visitedVertices.Add(v.Value, true);
				queue.Enqueue(v);
			}
		}
	}

	Console.WriteLine($"Visit count => {visitCount}");
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


