using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using King.Map;

namespace King.Level
{
    [CreateAssetMenu(fileName = "LevelData", menuName = "Level/Data", order = 0)]
    public class LevelData : ScriptableObject
    {
        public string Name;
        public MapData Map;
    }
}
