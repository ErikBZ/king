using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using King.Map;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace UnityEngine.Tilemaps
{

    [Serializable]
    [CreateAssetMenu(fileName = "New Map Tile", menuName = "Tiles/Map Tile")]
    public class MapTile : Tile
    {
        public TileType TileType;
        public byte MoveContraints;
        public TileUnityEvent tileEvent;
    }
}
