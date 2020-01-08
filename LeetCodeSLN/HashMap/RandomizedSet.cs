using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeSLN.HashMap
{
    public class RandomizedSet
    {
        private HashSet<int> _set;
        /** Initialize your data structure here. */
        public RandomizedSet()
        {
            _set = new HashSet<int>();
        }

        /** Inserts a value to the set. Returns true if the set did not already contain the specified element. */
        public bool Insert(int val)
        {
            return _set.Add(val);
        }

        /** Removes a value from the set. Returns true if the set contained the specified element. */
        public bool Remove(int val)
        {
            return _set.Remove(val);
        }

        /** Get a random element from the set. */
        public int GetRandom()
        {
            //TODO:待完成
            return 0;
        }
    }

    /**
     * Your RandomizedSet object will be instantiated and called as such:
     * RandomizedSet obj = new RandomizedSet();
     * bool param_1 = obj.Insert(val);
     * bool param_2 = obj.Remove(val);
     * int param_3 = obj.GetRandom();
     */
}
