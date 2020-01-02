using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using Newtonsoft.Json;

namespace King.Loader
{
    // Loads and Saves the state
    // Must load before this class can be used
    class SaveStateLoader
    {
        private const String SAVEBINARYPATH = "savedGames.json";

        public static void Save(List<SaveState> saves)
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Create(Path.Combine(Application.persistentDataPath, SAVEBINARYPATH));

            bf.Serialize(file, saves);
            file.Close();
        }

        public static void SaveToJson(List<SaveState> saves)
        {
            string json = JsonConvert.SerializeObject(saves);
            File.WriteAllText(Path.Combine(Application.persistentDataPath, SAVEBINARYPATH), json);
        }

        public static List<SaveState> Load()
        {
            List<SaveState> saves;
            if (File.Exists(Path.Combine(Application.persistentDataPath, SAVEBINARYPATH)))
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream file = File.Open(Path.Combine(Application.persistentDataPath, SAVEBINARYPATH),
                                            FileMode.Open);

                saves = (List<SaveState>)bf.Deserialize(file);
                file.Close();
            } 
            else
            {
                saves = new List<SaveState>();
            }

            return saves;
        }

        public static List<SaveState> LoadFromJson()
        {
            List<SaveState> saves = new List<SaveState>();
            Debug.Log(Application.persistentDataPath);

            if (File.Exists(Path.Combine(Application.persistentDataPath, SAVEBINARYPATH)))
            {
                string json = File.ReadAllText(Path.Combine(Application.persistentDataPath, SAVEBINARYPATH));
                saves = JsonConvert.DeserializeObject<List<SaveState>>(json);
            }
            return saves;
        }
    }
}
