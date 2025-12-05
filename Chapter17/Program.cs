using Common;

Console.WriteLine("Hello, World!");

var trie = new Trie();
trie.Insert("a");
trie.Insert("ab");
var words = trie.CollectAllWords();
words.PrintElements();

Console.WriteLine();


// Ex17.1
/*
 * tag, tan, tank, tap, today, total, we, well, went
 */

// Ex17.2
// Console.WriteLine("Ex 17.2");
// trie = new Trie();
// trie.Insert("get");
// trie.Insert("go");
// trie.Insert("got");
// trie.Insert("gotten");
// trie.Insert("hall");
// trie.Insert("ham");
// trie.Insert("hammer");
// trie.Insert("hill");
// trie.Insert("zebra");
// trie.CollectAllWords().PrintElements();

//Ex 17.3
// Console.WriteLine("Ex 17.3");
// trie = new Trie();
// trie.Insert("a");
// trie.Insert("ab");
// trie.Insert("f");
// trie.PrintKeys();

//Ex 17.4
Console.WriteLine("Ex 17.4");


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

        //return part of word/prefix match
        return currentNode;

        // return exact word match
        //return currentNode.Children.ContainsKey('*') ? currentNode : null;
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

    /// <summary>
    /// When user types a prefix, return all words that start with that prefix
    /// </summary>
    /// <param name="prefix"></param>
    /// <returns></returns>
    public List<string> AutoComplete(string prefix)
    {
        var currentNode = Search(prefix);
        var words = new List<string>();
        if (currentNode != null)
        {
            words = CollectAllWords(currentNode);
        }

        return words;
    }

    public void PrintKeys(TrieNode node = null)
    {
        var currentNode = node ?? Root;

        foreach (var keyNode in currentNode.Children)
        {
            Console.Write($" {keyNode.Key}");
            if (keyNode.Key != '*')
            {
                PrintKeys(keyNode.Value);
            }
        }
    }
}

