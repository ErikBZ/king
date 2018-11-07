using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace UnityEngine.Tilemaps
{

    [Serializable]
    public class WallTile : Tile
    {
        // Each tile has to be a seperate script
        public const byte HINDERANCE = 0xFF;
        Vector3Int position;

#if UNITY_EDITOR
        [MenuItem("Assets/Create/WallTile")]
        public static void CreateWallTile()
        {
            string path = EditorUtility.SaveFilePanelInProject("Save Wall Tile", "New Wall Tile", "Asset", "Save Wall Tile", "Assets");
            if (path == "")
            {
                return;
            }
            AssetDatabase.CreateAsset(ScriptableObject.CreateInstance<WallTile>(), path);
        }
#endif 

    }
}
