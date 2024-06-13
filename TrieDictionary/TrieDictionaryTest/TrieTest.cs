namespace TrieDictionaryTest;

[TestClass]
public class TrieTest
{
    // Test that a word is inserted in the trie
    [TestMethod]
    public void InsertWord()
    {
        // Arrange
        Trie trie = new Trie();
        string word = "hello";

        // Act
        trie.Insert(word);

        // Assert
        Assert.IsTrue(trie.Search(word));
    }

    // Test that a word is deleted from the trie
    [TestMethod]
    public void DeleteWord()
    {
        // Arrange
        Trie trie = new Trie();
        string word = "hello";
        trie.Insert(word);

        // Act
        trie.Delete(word);

        // Assert
        Assert.IsFalse(trie.Search(word));
    }

    // Test that a word is not inserted twice in the trie
    [TestMethod]
    public void InsertWordTwice()
    {
        // Arrange
        Trie trie = new Trie();
        string word = "hello";

        // Act
        trie.Insert(word);
        bool insertedTwice = trie.Insert(word);

        // Assert
        Assert.IsFalse(insertedTwice);
    }

    // Test that a word is not deleted from the trie if it is not present
    [TestMethod]
    public void DeleteWordNotPresent()
    {
        // Arrange
        Trie trie = new Trie();
        string word = "hello";

        // Act
        bool deleted = trie.Delete(word);

        // Assert
        Assert.IsFalse(deleted);
    }

    // Test that a word is deleted from the trie if it is a prefix of another word
    [TestMethod]
    public void DeleteWordPrefix()
    {
        // Arrange
        Trie trie = new();
        trie.Insert("hello");
        trie.Insert("hell");

        // Act
        trie.Delete("hell");

        // Assert
        Assert.IsTrue(trie.Search("hello"));
        Assert.IsFalse(trie.Search("hell"));
    }

    // Test AutoSuggest for the prefix "cat" not present in the 
    // trie containing "catastrophe", "catatonic", and "caterpillar"
    [TestMethod]
    public void AutoSuggestPrefixNotPresent()
    {
        // Arrange
        Trie dictionary = new Trie();
        dictionary.Insert("catastrophe");
        dictionary.Insert("catatonic");
        dictionary.Insert("caterpillar");

        // Act
        List<string> suggestions = dictionary.AutoSuggest("cat");

        // Assert
        Assert.AreEqual(3, suggestions.Count);
        Assert.AreEqual("catastrophe", suggestions[0]);
        Assert.AreEqual("catatonic", suggestions[1]);
        Assert.AreEqual("caterpillar", suggestions[2]);
    }

    // Test GetSpellingSuggestions for a word not present in the trie
    [TestMethod]
    public void GetSpellingSuggestionsWordNotPresent()
    {
        // Arrange
        Trie trie = new Trie();
        trie.Insert("hello");

        // Act
        List<string> suggestions = trie.GetSpellingSuggestions("hell");

        // Assert
        Assert.AreEqual(1, suggestions.Count);
        Assert.AreEqual("hello", suggestions[0]);
    }
    
}