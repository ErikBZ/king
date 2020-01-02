using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace King.Level
{
    [CreateAssetMenu(fileName = "LevelDataList", menuName = "Level/List", order = 0)]
    public class LevelDataList : ScriptableObject
    {
        public List<LevelData> Levels;
    }
}
