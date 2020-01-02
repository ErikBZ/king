using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

// this is a single instance of a tile in the game
// this wraps the tiles to make it easier to select and run methods on
namespace King.Map
{
    public class GameTile
    {
        public Vector3Int LocalPosition;
        public Vector3 WorldPosition;
        public TileBase TileBase;
    }
}
