using System;
using System.Collections.Generic;

namespace Script.SaveLoad
{
    [Serializable]
    public class Table
    {
        public string[] input = new string[0];
        public bool[] available = new bool[0];

        public void Fill(Dictionary<string, bool> table)
        {
            int i = 0;
            input = new string[table.Count];
            available = new bool[table.Count];
            foreach (var entity in table)
            {
                input[i] = entity.Key;
                available[i] = entity.Value;
                i++;
            }
        }
    }
}