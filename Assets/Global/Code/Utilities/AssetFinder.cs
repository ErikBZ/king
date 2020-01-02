using UnityEditor;
using System.Collections.Generic;

namespace King.Utilities
{
    public static class AssetFinder
    {
        public static T[] GetAllInstances<T>() where T : UnityEngine.Object
        {
            string[] guids = AssetDatabase.FindAssets("t:" + typeof(T).Name);
            T[] instances = new T[guids.Length];

            for(int i = 0;i < guids.Length; i++)
            {
                string path = AssetDatabase.GUIDToAssetPath(guids[i]);
                instances[i] = AssetDatabase.LoadAssetAtPath<T>(path);
            }

            return instances;
        }

        public static T GetInstance<T>(string guid) where T : UnityEngine.Object
        {
            string path = AssetDatabase.GUIDToAssetPath(guid);
            return AssetDatabase.LoadAssetAtPath<T>(path);
        }

        public static Dictionary<string, T> GetMappedInstances<T>() where T : UnityEngine.Object
        {
            Dictionary<string, T> instances = new Dictionary<string, T>();
            string[] guids = AssetDatabase.FindAssets("t:" + typeof(T).Name);

            foreach(string guid in guids)
            {
                string path = AssetDatabase.GUIDToAssetPath(guid);
                instances.Add(guid, AssetDatabase.LoadAssetAtPath<T>(path));
            }

            return instances; 
        }

        public static string GetGUID(UnityEngine.Object obj)
        {
            string path = AssetDatabase.GetAssetPath(obj);
            return AssetDatabase.AssetPathToGUID(path);
        } 
    }
}
