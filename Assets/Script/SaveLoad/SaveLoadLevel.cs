using BayatGames.SaveGameFree;
using BayatGames.SaveGameFree.Serializers;
using Script.Scene;
using UnityEngine;

namespace Script.SaveLoad
{
    public class SaveLoadLevel
    {        
        public static void Save(UnityEngine.SceneManagement.Scene scene)
        {
            LevelData level = new LevelData();
            foreach (GameObject obj in scene.GetRootGameObjects())
            {
                level.Add(new PositData(obj));
            }
            level.timeEnter = SceneTransition.TimeEnter(scene.buildIndex);
            SaveGame.Serializer = new SaveGameJsonSerializer();
            SaveGame.Save(scene.name, level);
        }

        public static LevelData Load(string name)
        {
            SaveGame.Serializer = new SaveGameJsonSerializer();
            return SaveGame.Exists(name) ? SaveGame.Load<LevelData>(name) : null;
        }
    }
}