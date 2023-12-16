namespace DataStructures.Trie;

public class TrieNode
{
    public TrieNode()
    {
        Character = ' ';
        Children = new Dictionary<char, TrieNode>();
    }
    
    public TrieNode(char character)
    {
        Character = character;
        Children = new Dictionary<char, TrieNode>();
    }

    public char Character { get; set; }

    public bool IsEndOfWord { get; set; }
    
    // Using Array
    // public TrieNode?[] Children { get; set; } = new TrieNode?[26];
    
    public Dictionary<char, TrieNode> Children { get; set; }

    public override string ToString() => $"Value = {Character}";

    // #region Array Methods
    //
    // public bool HasChild(char ch)
    // {
    //     var index = ch - 'a';
    //     return Children[index] != null;
    // }
    //
    // public void AddChild(char ch)
    // {
    //     var index = ch - 'a';
    //     Children[index] = new TrieNode(ch);
    // }
    //
    // public TrieNode? GetChild(char ch)
    // {
    //     return Children[ch-'a'];
    // }
    //
    // #endregion

    #region Hash Table Methods

    public bool HasChild(char ch)
    {
        return Children.ContainsKey(ch);
    }
    
    public void AddChild(char ch)
    {
        Children.Add(ch, new TrieNode(ch));
    }
    
    public TrieNode GetChild(char ch)
    {
        return HasChild(ch) ? Children[ch] : new TrieNode();
    }

    #endregion

}