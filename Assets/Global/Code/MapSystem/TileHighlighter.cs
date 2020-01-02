using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace King.MapSystem
{
    public class TileHighlighter
    {
        Tilemap Map;
        // Contains any Vector3Ints that are highlighted by some non-white color
        HashSet<Vector3Int> tileBag;

        public TileHighlighter()
        {
            Map = null;
            tileBag = new HashSet<Vector3Int>();
        }

        public TileHighlighter(Tilemap map)
        {
            Map = map;
            tileBag = new HashSet<Vector3Int>();
        }

        public void Add(List<Vector3Int> tiles, Color color)
        {
            foreach(Vector3Int point in tiles)
            {
                tileBag.Add(point);
                Map.SetTileFlags(point, TileFlags.None);
                Map.SetColor(point, color);
            }
        }

        public void Remove(List<Vector3Int> tiles)
        {
            foreach(Vector3Int point in tiles)
            {
                tileBag.Remove(point);
                Map.SetColor(point, Color.white);
            }
        }

        public void PointHighlight(Vector3Int tile)
        {
            if(!tileBag.Contains(tile) || tileBag.Count != 1)
            {
                Clear();
                Add(new List<Vector3Int>() { tile }, Color.yellow);
            }
        }

        public void Clear()
        {
            foreach(Vector3Int point in tileBag)
            {
                Map.SetColor(point, Color.white);
            }

            tileBag.Clear();
        }

        public void Highlight(List<Vector3Int> tilePoints, Color color)
        {
            foreach(Vector3Int tile in tilePoints)
            {
                Map.SetTileFlags(tile, TileFlags.None);
                Map.SetColor(tile, color);
            }
        }

        public void ResetHighlight(List<Vector3Int> tilePoints)
        {
            Highlight(tilePoints, Color.white);
        }

        // sets all tile highlight to none
        public void ClearHighlight()
        {
        }

    }
}
