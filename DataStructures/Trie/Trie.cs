namespace DataStructures.Trie;

public class Trie
{
    private readonly TrieNode _root;

    public Trie()
    {
        _root = new TrieNode();
    }

    public void Insert(string word)
    {
        // Insert(_root, word, 0);
        InsertUsingLoop(word);
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