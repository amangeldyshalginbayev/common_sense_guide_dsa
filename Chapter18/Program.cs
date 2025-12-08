
var alice = new Vertex("alice");
var bob = new Vertex("bob");
var synthia = new Vertex("synthia");

alice.AddAdjacentVertex(bob);
alice.AddAdjacentVertex(synthia);
bob.AddAdjacentVertex(synthia);
//synthia.AddAdjacentVertex(bob);


class Vertex {
	public string Value { get; set; }
	public List<Vertex> AdjacentVertices { get; set; }

	public Vertex(string value) {
		Value = value;
		AdjacentVertices = new();
	}

	public void AddAdjacentVertex(Vertex vertex, isRecipient = true) {
		if (AdjacentVertices.Contains(vertex)) {
			Console.WriteLine($"{Value} is already friend with {vertex.Value}");
			return;
		}
			 
		AdjacentVertices.Add(vertex);
		vertex.AddAdjacentVertex(this);
	}

}


//bob.AdjacentVertices = [synthia]
//synthia.AdjacentVerticies = [bob]