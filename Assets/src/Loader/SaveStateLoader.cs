using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace King.Loader
{
    // Loads and Saves the state
    // Must load before this class can be used
    class SaveStateLoader
    {
        private const String SAVEBINARYPATH = "savedGames.gd";

        public static void Save(List<SaveState> saves)
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Create(Path.Combine(Application.persistentDataPath, SAVEBINARYPATH));

            bf.Serialize(file, saves);
            file.Close();
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
    }
}
