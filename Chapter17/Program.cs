// See https://aka.ms/new-console-template for more information

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
}