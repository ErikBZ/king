using UnityEngine;
using UnityEngine.Tilemaps;
using King.LevelSystem;

public class GetAvailableTiles : MonoBehaviour
{
    public Tilemap AvailablePositions;
    public LevelRestrictionContext Context;

    void Awake()
    {
        // Make sure nothing weird happens
        Context.AvailableTiles.Clear();
        foreach(Vector3Int pos in AvailablePositions.cellBounds.allPositionsWithin)
        {
            // May change this up a bit
            var local = new Vector3Int(pos.x, pos.y, pos.z);
            if(AvailablePositions.HasTile(local))
            {
                Context.AvailableTiles.Add(local);
            }
        }
    }
}
