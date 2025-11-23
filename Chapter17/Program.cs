

Console.WriteLine("Hello, World!");

class TrieNode
{
    public Dictionary<char, TrieNode> Children { get; set; } = new();
}

class Trie
{
    TrieNode Root { get; set; } = new();

    TrieNode Search(string word)
    {
        var currentNode = Root;
        foreach (var c in word)
        {
            if (currentNode.Children.TryGetValue(c, out var val))
            {
                currentNode = val;
            }
            else
            {
                return null;
            }
        }

        return currentNode;
    }

    void Insert(string word) {
        var currentNode = Root;
        var index = 0;
        var lastIndex = word.Length - 1;

        foreach(var c in word) {
            index++;
            if (currentNode.Children.TryGetValue(c, out var val)) {
                currentNode = val;
            }
            else {
                var newNode = new TrieNode();
                currentNode.Children.Add(c, newNode);
                currentNode = newNode;
                if (index == lastIndex) {
                    currentNode.Children.Add('*', null);
                }
            
            }
        }
    }

    


}