

var alice = new Vertex("alice");
var bob = new Vertex("bob");
var synthia = new Vertex("synthia");

alice.AddAdjacentVertex(bob);
alice.AddAdjacentVertex(synthia);
bob.AddAdjacentVertex(synthia);
synthia.AddAdjacentVertex(bob);


void DFStraverse(Vertex vertex, Dictionary<string> visitedVertices = null) {
	visitedVertices ??= new();

	visitedVertices.Add(vertex.Value, true);

	Console.WriteLine(vertex.Value);

	foreach(var v in vertex.AdjacentVertices) {
		if (visitedVertices.HasKey(v.Value))
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


