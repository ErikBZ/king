using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using King.MapSystem;
using King.Utilities.Scriptable;

public class Highlighter : MonoBehaviour
{
    [SerializeField]
    Color hightlightColor;
    [SerializeField]
    ObjectReference tilesToHighlight;
    [SerializeField]
    ObjectReference TilePositionsInMap;
    [SerializeField]
    Sprite highlightTexture;

    TileHighlighter highlighter;

    void Awake()
    {
        var map = GetComponent<Tilemap>();
        highlighter = new TileHighlighter(map);
    }

    public void InitHighlightMap()
    {
        var map = GetComponent<Tilemap>();
        if (ObjectReference.NotEmpty(TilePositionsInMap, out List<Vector3Int> tilePositions))
        {
            foreach (Vector3Int tilePos in tilePositions)
            {
                if (!map.HasTile(tilePos))
                {
                    Tile tile = ScriptableObject.CreateInstance<Tile>();
                    tile.sprite = highlightTexture;
                    map.SetTile(tilePos, tile);
                }
            }
            // Make sure that the highlights are cleared
            highlighter.ResetHighlight(tilePositions);
        }
    }

    public void HighlightTiles()
    {
        highlighter.ClearAllInBag();
        if (ObjectReference.NotEmpty(tilesToHighlight, out List<Vector3Int> tiles))
        {
            highlighter.Add(tiles, hightlightColor);
        }
    }
}
