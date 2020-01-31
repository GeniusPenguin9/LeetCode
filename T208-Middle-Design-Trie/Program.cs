using System;
using System.Collections.Generic;

namespace T208_Middle_Design_Trie
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
    class Trie
    {
        class TrieNode
        {
            public bool IsFullWord;
            public TrieNode[] subNode;
            public TrieNode()
            {
                this.IsFullWord = false;
                this.subNode = new TrieNode[26];
            }
        }

        private TrieNode root;
        public Trie()
        {
            root = new TrieNode();
        }

        /** Inserts a word into the trie. */
        public void Insert(string word)
        {
            var head = root;
            for(var i = 0; i < word.Length; i++)
            {  
                if(head.subNode[word[i]-'a'] == null)
                    head.subNode[word[i] - 'a'] = new TrieNode();

                head = head.subNode[word[i] - 'a'];
                if (i == word.Length - 1)
                    head.IsFullWord = true;
            }
        }

        /** Returns if the word is in the trie. */
        public bool Search(string word)
        {
            var head = root;
            for (var i = 0; i < word.Length; i++)
            {
                if (head.subNode[word[i] - 'a'] == null)
                    return false;

                head = head.subNode[word[i] - 'a'];
            }
            return head.IsFullWord;
        }

        /** Returns if there is any word in the trie that starts with the given prefix. */
        public bool StartsWith(string prefix)
        {
            var head = root;
            for (var i = 0; i < prefix.Length; i++)
            {
                if (head.subNode[prefix[i] - 'a'] == null)
                    return false;
                
                head = head.subNode[prefix[i] - 'a'];
            }
            return true;
        }
    }

}
