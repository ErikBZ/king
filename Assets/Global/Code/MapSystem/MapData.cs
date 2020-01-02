using System;
using System.Collections.Generic;
using UnityEngine;

namespace King.MapSystem
{
    [Serializable]
    public class MapData
    {
        public string Name;
        public Dictionary<Vector3Int, string> Tiles;

        public MapData()
        {
            Name = string.Empty;
            Tiles = new Dictionary<Vector3Int, string>();
        }
    }
}
