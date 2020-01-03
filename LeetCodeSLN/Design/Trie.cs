using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeSLN.Design
{
    public class Trie
    {
        class Node
        {
            public Dictionary<char,bool> set;
            public Node Next;

            public Node()
            {
                set = new Dictionary<char,bool>();
                Next = null;
            }
        }
        private Node _root;
        /** Initialize your data structure here. */
        public Trie()
        {
            _root = new Node();
        }

        /** Inserts a word into the trie. */
        public void Insert(string word)
        {
            Node node = _root;
            for(int i = 0;i<word.Length;i++)
            {
                var ch = word[i];
                if (!node.set.ContainsKey(ch))
                {
                    node.set.Add(ch,false);
                }
                if (i < word.Length - 1)
                {
                    if (node.Next == null)
                        node.Next = new Node();
                    node = node.Next;
                }else
                {
                    node.set[ch] = true;
                }
            }
        }

        /** Returns if the word is in the trie. */
        public bool Search(string word)
        {
            Node node = _root;
            for(int i = 0;i<word.Length;i++)
            {
                var ch = word[i];
                if (!node.set.ContainsKey(ch))
                    return false;
                if (i < word.Length - 1)
                {
                    if (node.Next == null)
                        return false;
                    node = node.Next;
                }else 
                {
                    return node.set.ContainsKey(ch) && node.set[ch];
                }
            }
            return true;
        }

        /** Returns if there is any word in the trie that starts with the given prefix. */
        public bool StartsWith(string prefix)
        {
            Node node = _root;
            for(int i = 0; i<prefix.Length;i++)
            {
                var ch = prefix[i];
                if (!node.set.ContainsKey(ch))
                    return false;
                if (i < prefix.Length - 1)
                {
                    if (node.Next == null)
                        return false;
                    node = node.Next;
                }else
                {
                    return true;
                }
            }
            return true;
        }
    }
}
