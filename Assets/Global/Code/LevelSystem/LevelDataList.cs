using System.Collections.Generic;
using UnityEngine;

namespace King.LevelSystem
{
    [CreateAssetMenu(fileName = "LevelDataList", menuName = "Level/List", order = 0)]
    public class LevelDataList : ScriptableObject
    {
        public List<LevelData> Levels;
    }
}
