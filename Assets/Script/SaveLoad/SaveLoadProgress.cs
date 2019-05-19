using System;
using System.Collections.Generic;
using BayatGames.SaveGameFree;
using BayatGames.SaveGameFree.Serializers;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace Script.SaveLoad
{
    public static class SaveLoadProgress
    {
        public static IntEvent OnLoad = new IntEvent();
        private static Progress progress;
        private static int level;
        private static float[] pos = new float[3];

        public static void Save(bool saveToFile)
        {
            Load();
            if (progress == null) progress = new Progress();
            progress.table.Fill(Input.tableOfAvailability);
            Data[] sceneData = LoadScene();
            progress.data = ConcatArray(progress.data, sceneData);
            progress.level = level;
            progress.pos = pos;
            if (saveToFile)
            {
                SaveGame.Serializer = new SaveGameBinarySerializer();
                SaveGame.Encode = true;
                SaveGame.Save("data", progress);     
            }
        }

        private static Data[] ConcatArray(Data[] x, Data[] y)
        {
            Data[] z = new Data[x.Length + y.Length];
            x.CopyTo(z, 0);
            y.CopyTo(z, x.Length);
            return z;
        }

        private static Data[] LoadScene()
        {
            List<Data> list = new List<Data>();
            foreach (GameObject obj in SceneManager.GetActiveScene().GetRootGameObjects())
            {
                LoadFromTo(LoadObjectData(obj), list);
            }
            return list.ToArray();
        }
        
        private static List<Data> LoadObjectData(GameObject obj)
        {
            List<Data> list = new List<Data>();
            Savable data = obj.GetComponent<Savable>();
            if (data) list.Add(data.Init());
            int index = Array.FindIndex(progress.data, el => el.id.Equals(obj.name));
            if (index != -1)
            {
                if (index == progress.data.Length - 1)
                {
                    Array.Resize(ref progress.data, progress.data.Length - 1);
                }
                else
                {
                    Array.Copy(progress.data, index + 1, progress.data, index, progress.data.Length - index - 1);
                    Array.Resize(ref progress.data, progress.data.Length - 1);
                }
            }
            foreach (Transform child in obj.transform)
            {
                LoadFromTo(LoadObjectData(child.gameObject), list);
            }
            return list;
        }

        private static void LoadFromTo(List<Data> from, List<Data> to)
        {
            foreach (var data in from)
            {
                to.Add(data);
            }
        }

        public static void SetPos(int index, Vector3 position)
        {
            level = index;
            pos[0] = position.x;
            pos[0] = position.y;
            pos[0] = position.z;
        }
        
        public static void Load()
        {
            if (!SaveGame.Exists("data"))
            {
                OnLoad.Invoke(1);
                return;
            }
            if (progress == null)
            {
                SaveGame.Serializer = new SaveGameBinarySerializer();
                SaveGame.Encode = true;
                progress = SaveGame.Load<Progress>("data");
            }
            OnLoad.Invoke(progress.level);
        }

        public static Table LoadTable()
        {
            return progress?.table;
        }

        public static Data[] LoadData()
        {
            return progress?.data;
        }
    }
    
    [Serializable]
    internal class Progress
    {
        public Data[] data = new Data[0];
        public Table table = new Table();
        public int level;
        public float[] pos = new float[3];
    }
    
    [Serializable]
    public class IntEvent : UnityEvent<int> { }
}