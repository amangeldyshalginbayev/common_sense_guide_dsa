

using System.IO.Compression;



Console.WriteLine("Hello, World!");

var trie = new Trie();
trie.Insert("abc");
trie.Insert("bde");
Console.WriteLine("tst");
var words = trie.CollectAllWords();
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

    public void Insert(string word) {
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

    public List<string> CollectAllWords(TrieNode node=null, string word="", List<string> words = null) {
        var currentNode = node ?? Root;
        words = words ?? [];
        
        foreach (var keyValue in currentNode.Children) {
            Console.WriteLine(keyValue.Key);
            if (keyValue.Key == '*') {
                words.Add(word);
            }
            else {
                CollectAllWords(keyValue.Value, word+keyValue.Key, words);
            }
        }
        
        return words;

    }
    
    




}
