using System;
using System.Collections.Generic;

namespace Script.SaveLoad
{
    [Serializable]
    public class LevelData
    {
        public int timeEnter;
        public List<PositData> objects = new List<PositData>();

        public LevelData() { }
        
        public void Add(PositData item)
        {
            objects.Add(item);
        }

        public PositData GetPositData(string name)
        {
            return objects.Find(data => data.Name == name);
        }
    }
}