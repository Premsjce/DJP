using System;
using System.Collections.Generic;

namespace DataStructures
{
    public class TrieDS
    {
        public static void Driver()
        {
            Trie trieTree = new Trie();

            trieTree.Add("Bumfuzzle");
            trieTree.Add("Lollygag");
            trieTree.Add("Nudiustertian");
            trieTree.Add("Brouhaha");
            trieTree.Add("Batrachomyomachy");
            trieTree.Add("Flibbertigibbet");
            trieTree.Add("gibbet");
            trieTree.Add("Batra");

            Console.WriteLine(trieTree.Search("Lollygag"));
        }
    }
    
    public class TrieNode
    {
        public Dictionary<char, TrieNode> Children { get; set; } = new Dictionary<char, TrieNode>();
        public bool IsEndOfWord { get; set; }
    }

    public class Trie
    {
        
        public Trie() => Root = new TrieNode();

        public TrieNode Root { get; }

        public void Add(string str) => RecursiveInsert(str, 0, Root);

        public bool Search(string str) => RecursiveSearch(str, 0, Root);

        private bool RecursiveSearch(string str, int index, TrieNode currentNode)
        {
            if(str.Length == index)
                return currentNode.IsEndOfWord;

            if (!currentNode.Children.ContainsKey(str[index]))
                return false;

            return RecursiveSearch(str, index + 1, currentNode.Children[str[index]]);
        }

        private TrieNode RecursiveInsert(string str, int index, TrieNode currentNode)
        {
            if (index == str.Length)
            {
                currentNode.IsEndOfWord = true;
                return currentNode;
            }
            
            if(currentNode.Children.ContainsKey(str[index]))            
                return RecursiveInsert(str, index + 1, currentNode.Children[str[index]]);
            else
            {
                var newChildNode = new TrieNode();
                currentNode.Children.Add(str[index], newChildNode);
                return RecursiveInsert(str, index + 1, newChildNode);
            }
        }
    }
}
