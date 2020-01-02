using UnityEngine;
using King.Editor;

namespace King.Level
{
    [CreateAssetMenu(fileName = "LevelData", menuName = "Level/Data", order = 0)]
    public class LevelData : ScriptableObject
    {
        public string Name;
        [StringInList(typeof(LevelSelectHelper), "GetAllMaps")]
        public string MapDataJsonPath;
    }
}
