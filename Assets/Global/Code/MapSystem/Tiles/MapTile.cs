using System;
using UnityEngine;
using UnityEngine.Tilemaps;
using King.MapSystem.Events;

namespace King.MapSystem.Tiles
{

    [Serializable]
    [CreateAssetMenu(fileName = "New Map Tile", menuName = "Tiles/Map Tile")]
    public class MapTile : Tile
    {
        public TileType TileType;
        public int BaseDefBoost;
        public int BaseAvoidBoost;
        public byte MoveConstraints;
        // All moves cost 1 by default
        public byte AdditionalMoveCost = 1;
        public TileUnityEvent TileEvent;

        public MapTile()
        {
            // Might not need this if i'm using the MoveConstraints
            TileType = TileType.Normal;
            BaseDefBoost = 0;
            BaseAvoidBoost = 0;
            MoveConstraints = TileValues.STANDARD;
            TileEvent = null;
        }
    }
}
