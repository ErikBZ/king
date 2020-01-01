﻿using System.IO;
using System.Collections.Generic;
using System.Linq;
using King.Level;
using King.Map;
using UnityEngine;
using UnityEngine.Tilemaps;
using Newtonsoft.Json;
using King.Utils;
using King.Editor;

[RequireComponent(typeof(TileManager))]
public class InitTilemap : MonoBehaviour
{
    public ObjectReference LevelDataReference;
    Tilemap MainMap;
    TileManager TileManager;

    void Start()
    {
        TileManager = GetComponent<TileManager>();
        TileManager.enabled = false;

        if (!ObjectReference.NotEmpty(LevelDataReference, out LevelData levelData))
        {
            string path = levelData.MapDataJsonPath;
            MapData MapData = LoadMapData(path);

            // lol this is so unnecessary  
            Tilemap tilemap = GetComponentsInChildren<TilemapRenderer>()
                .Where(tr => tr.sortingLayerName == "Map")
                .Select(tr => tr.GetComponent<Tilemap>())
                .First();

            tilemap.ClearAllTiles(); 

            ImportMap(MapData, tilemap);
        }

        TileManager.enabled = true;
    }

    MapData LoadMapData(string path)
    {
        string fullPath = Path.Combine(Application.dataPath, LevelSelectHelper.MapDirectory, path);
        if (File.Exists(fullPath))
        {
            string data = File.ReadAllText(fullPath);
            return JsonConvert.DeserializeObject<MapData>(data, new DictVec3IntStringConverter());
        }
        return new MapData();
    }
    void ImportMap(MapData data, Tilemap tilemap)
    {
        Dictionary<string, MapTile> mapTiles = AssetFinder.GetMappedInstances<MapTile>();
        foreach(KeyValuePair<Vector3Int, string> kvp in data.Tiles)
        {
            tilemap.SetTile(kvp.Key, mapTiles[kvp.Value]);
        }
    }
}
