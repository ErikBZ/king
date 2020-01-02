using System.IO;
using UnityEngine;
using System.Linq;

namespace King.Utilities
{
    public static class LevelSelectHelper
    {
        public const string MapDirectory = "Level/Maps";

        // checks the "maps" sub directory for maps
        public static string[] GetAllMaps()
        {
            DirectoryInfo dir = new DirectoryInfo(Path.Combine(Application.dataPath, MapDirectory));
            FileInfo[] files = dir.GetFiles("*.json");
            return files.Select(f => f.Name).ToArray();
        }

        public static string[] GetAllFiles(string directory, string pattern, bool isFullPath)
        {
            DirectoryInfo dir = new DirectoryInfo(directory);
            FileInfo[] files = dir.GetFiles(pattern);
            return files.Select(f => isFullPath ? f.FullName : f.Name).ToArray();
        }
    }
}
