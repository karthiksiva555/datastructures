using System.Diagnostics;

namespace DataStructures.Trie;

public class TrieHashTable
{
    private readonly TrieNodeHashTable _root;

    public TrieHashTable()
    {
        _root = new TrieNodeHashTable();
    }

    public void Insert(string word)
    {
        var node = _root;

        foreach (var ch in word)
        {
            if(!node.Children.ContainsKey(ch))
                node.Children.Add(ch, new TrieNodeHashTable(ch));
            node = node.Children[ch];
        }

        node.IsEndOfWord = true;
    }
}