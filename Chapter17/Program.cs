using Common;

Console.WriteLine("Hello, World!");

var trie = new Trie();
trie.Insert("a");
trie.Insert("ab");
var words = trie.CollectAllWords();
words.PrintElements();

Console.WriteLine();

class TrieNode
{
    public Dictionary<char, TrieNode> Children { get; set; } = new();
}

class Trie
{
    TrieNode Root { get; set; } = new();

    public TrieNode Search(string word)
    {
        var currentNode = Root;
        foreach (var c in word)
        {
            if (!currentNode.Children.TryGetValue(c, out var next))
                return null;

            currentNode = next;
        }

        // return part of word match
        // return currentNode;
        
        // return exact word match
        return currentNode.Children.ContainsKey('*') ? currentNode : null;
    }

    public void Insert(string word)
    {
        var currentNode = Root;

        foreach (var c in word)
        {
            if (!currentNode.Children.TryGetValue(c, out var next))
            {
                next = new TrieNode();
                currentNode.Children[c] = next;
            }

            currentNode = next;
        }
        
        if (!currentNode.Children.ContainsKey('*'))
            currentNode.Children['*'] = new TrieNode();
    }

    public List<string> CollectAllWords(TrieNode node = null, string word = "", List<string> words = null)
    {
        var currentNode = node ?? Root;
        words = words ?? [];

        foreach (var keyValue in currentNode.Children)
        {
            if (keyValue.Key == '*')
            {
                words.Add(word);
                //Console.WriteLine(word);
            }
            else
            {
                //Console.WriteLine(keyValue.Key);
                CollectAllWords(keyValue.Value, word + keyValue.Key, words);
            }
        }

        Console.WriteLine($"Hitting return > {words.Count}");
        return words;
    }
}