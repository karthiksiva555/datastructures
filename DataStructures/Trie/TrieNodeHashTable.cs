namespace DataStructures.Trie;

public class TrieNodeHashTable
{
    public char Character { get; set; }

    public Dictionary<char, TrieNodeHashTable>? Children { get; set; }

    public bool IsEndOfWord { get; set; }

    public TrieNodeHashTable(char ch = ' ')
    {
        Character = ch;
        Children = new Dictionary<char, TrieNodeHashTable>();
    }

    public override string ToString() => $"Value: {Character}";

}