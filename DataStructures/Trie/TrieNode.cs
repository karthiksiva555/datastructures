namespace DataStructures.Trie;

public class TrieNode
{
    public TrieNode()
    {
        Character = ' ';
    }
    
    public TrieNode(char character)
    {
        Character = character;
    }

    public char Character { get; set; }

    public TrieNode?[] Children { get; set; } = new TrieNode?[26];

    public bool IsEndOfWord { get; set; }

    public override string ToString() => $"Value = {Character}";

}