using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeSLN.Design
{
    public class Logger
    {

        /** Initialize your data structure here. */
        private Dictionary<string, int> _logDictionary;
        public Logger()
        {
            _logDictionary = new Dictionary<string, int>();
        }

        /** Returns true if the message should be printed in the given timestamp, otherwise returns false.
            If this method returns false, the message will not be printed.
            The timestamp is in seconds granularity. */
        public bool ShouldPrintMessage(int timestamp, string message)
        {
            ClearTimeoutMessage(timestamp, message);
            if (!_logDictionary.ContainsKey(message))
            {
                _logDictionary.Add(message, timestamp);
                return true;
            }else
            {
                if (_logDictionary[message] - timestamp >= 10)
                {
                    _logDictionary[message] = timestamp;
                    return true;
                }else
                {
                    return false;
                }
            }
        }

        private void ClearTimeoutMessage(int timestamp, string message)
        {
            var tmp = new List<string>();
            foreach(var pair in _logDictionary)
            {
                if (pair.Value - timestamp >= 10 && pair.Key!=message)
                {
                    tmp.Add(pair.Key);
                }
            }
            foreach(var s in tmp)
            {
                _logDictionary.Remove(s);
            }
        }
    }

    /**
     * Your Logger object will be instantiated and called as such:
     * Logger obj = new Logger();
     * bool param_1 = obj.ShouldPrintMessage(timestamp,message);
     */
}
