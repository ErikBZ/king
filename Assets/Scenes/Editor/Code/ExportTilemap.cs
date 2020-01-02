using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using King.Utilities;
using King.MapSystem;
using King.MapSystem.Tiles;
using Newtonsoft.Json;

public class ExportTilemap : MonoBehaviour
{
    public Tilemap Tilemap;
    public MapData MapData;
    string ProjectLocation;
    // Should use MapData.Name for prod
    string MapName = "test.json";

    public void Start()
    {
        ProjectLocation = Application.dataPath;
    }
    public void Export()
    {
        MapData = new MapData();

        foreach(Vector3Int pos in Tilemap.cellBounds.allPositionsWithin)
        {
            TileBase tileBase = Tilemap.GetTile(pos);
            if(!(tileBase is MapTile))
            {
                Debug.Log("Tile at " + pos + " is not a MapTile. Skipping");
                continue;
            }

            MapTile tile = (MapTile)tileBase;
        }
    }
    public void ExportToJson()
    {
        MapData = new MapData();

        foreach(Vector3Int pos in Tilemap.cellBounds.allPositionsWithin)
        {
            TileBase tileBase = Tilemap.GetTile(pos);
            if(!(tileBase is MapTile))
            {
                Debug.Log("Tile at " + pos + " is not a MapTile. Skipping");
                continue;
            }

            MapTile tile = (MapTile)tileBase;
            string tileGuid = AssetFinder.GetGUID(tile);

            // Should be able to dump this to a file and then reload it.
            MapData.Tiles.Add(pos, tileGuid);
        }

        string json = JsonConvert.SerializeObject(MapData);
        Debug.Log("Writing to json file in " + Path.Combine(ProjectLocation, MapName));
        File.WriteAllText(Path.Combine(ProjectLocation, MapName), json);
    }

    public void Import()
    {
        Dictionary<string, MapTile> mapTiles = AssetFinder.GetMappedInstances<MapTile>();
        string path = Path.Combine(ProjectLocation, MapName);
        string data = File.ReadAllText(path);
        MapData = JsonConvert.DeserializeObject<MapData>(data, new DictVec3IntStringConverter());

        foreach(KeyValuePair<Vector3Int, string> kvp in MapData.Tiles)
        {
            Tilemap.SetTile(kvp.Key, mapTiles[kvp.Value]);
        }

        Debug.Log("Hello world");
    }
}
