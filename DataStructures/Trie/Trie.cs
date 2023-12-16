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

        var chIndex = word[index] - 'a';
        var nextNode = node;
        if (node.Children[chIndex] == null)
        {
            nextNode = new TrieNode(word[index]);
            node.Children[chIndex] = nextNode;
        }

        Insert(nextNode, word, ++index);
    }
    
    private void InsertUsingLoop(string word)
    {
        var node = _root;

        foreach (var ch in word)
        {
            var index = ch - 'a';
            node.Children[index] ??= new TrieNode(ch);
            node = node.Children[index];
        }
        node.IsEndOfWord = true;
    }
    
}