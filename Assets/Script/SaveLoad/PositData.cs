using System;
using UnityEngine;

namespace Script.SaveLoad
{
    [Serializable]
    public class PositData
    {
        public string Name { get; set; }
        public Vector3 position { get; set; }

        public PositData(GameObject obj)
        {
            Name = obj.name;
            position = obj.transform.position;
        }

        public virtual void Restore(GameObject entity)
        {
            entity.transform.position = position;
        }
    }
}