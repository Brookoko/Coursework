using System;
using UnityEngine;

namespace Script.SaveLoad
{
    public class Savable : MonoBehaviour
    {
        private void OnDestroy()
        {
            Init();
        }

        public Data Init()
        {
            Data data = new Data();
            data.id = name;
            Vector3 pos = transform.position;
            data.position[0] = pos.x;
            data.position[1] = pos.y;
            data.position[2] = pos.z;
            return data;
        }
    }

    [Serializable]
    public class Data
    {
        public string id = "";
        public float[] position = new float[3];
 
    }
}