
using System.IO;
using UnityEngine;
using System.Linq;

public static class LevelSelectHelper
{
    // checks the "maps" sub directory for maps
    public static string[] GetAllMaps()
    {
        DirectoryInfo dir = new DirectoryInfo(Path.Combine(Application.dataPath, "Level", "Maps"));
        FileInfo[] files = dir.GetFiles("*.json");
        return files.Select(f => f.Name).ToArray();
    }
}
