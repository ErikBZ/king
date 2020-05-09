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
                Map.SetColor(point, Color.clear);
            }
        }

        public void PointHighlight(Vector3Int tile)
        {
            if(!tileBag.Contains(tile) || tileBag.Count != 1)
            {
                ClearAllInBag();
                Add(new List<Vector3Int>() { tile }, Color.yellow);
            }
        }

        public void ClearAllInBag()
        {
            foreach(Vector3Int point in tileBag)
            {
                Map.SetColor(point, Color.clear);
            }

            tileBag.Clear();
        }

        public void Highlight(List<Vector3Int> tilePositions, Color color)
        {
            foreach(Vector3Int tilePos in tilePositions)
            {
                Map.SetTileFlags(tilePos, TileFlags.None);
                Map.SetColor(tilePos, color);
            }
        }

        public void ResetHighlight(List<Vector3Int> tilePoints)
        {
            Highlight(tilePoints, Color.clear);
        }
    }
}
