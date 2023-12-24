using System.Text;

namespace DataStructures.Trie;

public class Trie
{
    private readonly TrieNode _root;

    public Trie()
    {
        _root = new TrieNode();
    }

    public string LongestCommonPrefix(string[]? words)
    {
        if (words == null || words.Length == 0)
            return string.Empty;

        var trie = new Trie();
        foreach(var word in words)
            trie.Insert(word);
        
        var shortest = GetShortestWord(words);
        var prefix = new StringBuilder();
        var current = trie._root;
        while (prefix.Length < shortest.Length)
        {
            var children = current?.GetChildren();
            if (children?.Count is 0 or > 1)
                break;
                
            var child = children?.FirstOrDefault();
            prefix.Append(child?.Character);
            current = child;
        }

        return prefix.ToString();
    }

    // Using Recursion
    // This solution fails for input [can, canada] => returns canada as the common prefix 
    // public string LongestCommonPrefix(string[] words)
    // {
    //     var longestCommonPrefix = LongestCommonPrefix(_root);
    //     return longestCommonPrefix.Trim();
    // }
    
    // private string LongestCommonPrefix(TrieNode node)
    // {
    //     if (node.Children.Count != 1) 
    //         return node.Character.ToString();
    //     
    //     var child = node.Children.FirstOrDefault();
    //     return node.Character + LongestCommonPrefix(child.Value);
    // }

    private static string GetShortestWord(IReadOnlyList<string>? words)
    {
        if (words == null || words.Count == 0)
            return string.Empty;
        
        var shortest = words[0];

        foreach (var word in words)
        {
            if (word.Length < shortest.Length)
                shortest = word;
        }
        
        return shortest;
    }
    
    public int CountWords()
    {
        return CountWords(_root);
    }

    private int CountWords(TrieNode node)
    {
        var count = 0;
        
        if (node.IsEndOfWord)
            count++;

        foreach (var child in node.Children.Values)
            count += CountWords(child);
        
        return count;
    }
    
    public IEnumerable<string> FindWords(string prefix)
    {
        if (string.IsNullOrEmpty(prefix))
            return new List<string>();
        
        var list = new List<string>();
        var node = GetLastNodeOf(prefix);

        if (node == null)
            return new List<string>();
            
        FindWords(node, prefix, list);
        
        return list;
    }

    private TrieNode? GetLastNodeOf(string prefix)
    {
        var node = _root;

        foreach (var ch in prefix)
        {
            if (!node.HasChild(ch))
                return null;
            node = node.GetChild(ch);
        }

        return node;
    }
    
    private void FindWords(TrieNode node, string prefix, ICollection<string> list)
    {
        if(node.IsEndOfWord)
            list.Add(prefix);

        foreach (var child in node.Children.Values)
            FindWords(child, prefix + child.Character, list);
    }

    public void Remove(string word)
    {
        if (string.IsNullOrEmpty(word))
            return;
        
        Remove(_root, word, 0);
    }

    private void Remove(TrieNode root, string word, int index)
    {
        if (index >= word.Length)
        {
            root.IsEndOfWord = false;
            return;
        }

        var child = root.GetChild(word[index]);
        if (child == null)
            return;

        Remove(child, word, index + 1);

        if (!child.HasChildren() && !child.IsEndOfWord)
            root.RemoveChild(child.Character);
    }
    
    public void PreOrderTraversal() => PreOrderTraversal(_root);

    public void PostOrderTraversal() => PostOrderTraversal(_root);
    
    public void Insert(string word)
    {
        // Insert(_root, prefix, 0);
        InsertUsingLoop(word);
    }

    public bool Contains(string word)
    {
        if (string.IsNullOrEmpty(word.Trim()))
            throw new InvalidOperationException("The argument must contain a value");
        
        var node = _root;
        
        foreach (var ch in word)
        {
            if (!node.HasChild(ch))
                return false;
            node = node.GetChild(ch);
        }

        return node.IsEndOfWord;
    }

    public bool ContainsRecursive(string word)
    {
        if (string.IsNullOrEmpty(word))
            return false;
        
        return ContainsRecursive(_root, word, 0);
    }

    private bool ContainsRecursive(TrieNode node, string word, int index)
    {
        if (index >= word.Length)
            return node.IsEndOfWord;

        if (node == null)
            return false;

        return node.HasChild(word[index]) && ContainsRecursive(node.GetChild(word[index]), word, index + 1);
    }

    private void PreOrderTraversal(TrieNode root)
    {
        Console.WriteLine(root.Character);
        
        foreach(var node in root.Children.Values)
            PreOrderTraversal(node);
    }
    
    private void PostOrderTraversal(TrieNode root)
    {
        foreach(var node in root.Children.Values)
            PostOrderTraversal(node);
        
        Console.WriteLine(root.Character);
    }
    
    private void Insert(TrieNode node, string word, int index)
    {
        if (index >= word.Length)
            return;

        if (!node.HasChild(word[index]))
            node.AddChild(word[index]);
 
        var nextNode = node.GetChild(word[index]); 

        Insert(nextNode, word, ++index);
    }
    
    private void InsertUsingLoop(string word)
    {
        var node = _root;

        foreach (var ch in word)
        {
            // var index = ch - 'a';
            // node.Children[index] ??= new TrieNode(ch);
            // node = node.Children[index];
            
            // After implementing abstraction principle/iterator pattern
            if (!node.HasChild(ch))
                node.AddChild(ch);
            node = node.GetChild(ch);
        }
        node.IsEndOfWord = true;
    }
    
}