using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using King.UnitSystem;
using King.MapSystem.Tiles;

public class UnitPositionManager : MonoBehaviour
{
    public Tilemap StartingPositions;
    public Tilemap UnitMap;

    [SerializeField] List<Vector3Int> AvailablePositions;

    [SerializeField] UnitList ActiveUnits;

    List<Unit> Units => ActiveUnits.Units;

    // Start is called before the first frame update
    void Start()
    {
        if (StartingPositions != null)
        {
            foreach(Vector3Int pos in StartingPositions.cellBounds.allPositionsWithin)
            {

                var tileBase = StartingPositions.GetTile(pos);
                if(tileBase is MapTile)
                {
                    AvailablePositions.Add(pos);
                }
            }
        }
    }

    public void UpdateUnitPositions()
    {
        for(int i=0; i < AvailablePositions.Count; i++)
        {
            var pos = AvailablePositions[i];
            if(i < Units.Count)
            {
                Tile tile = new Tile();
                tile.sprite = Units[i].PortraitSprite;
                UnitMap.SetTile(pos, tile);
            }
            else
            {
                UnitMap.SetTile(pos, new Tile());
            }
        }
    }

    public void InitEnemyUnitPositions()
    {

    }
}
