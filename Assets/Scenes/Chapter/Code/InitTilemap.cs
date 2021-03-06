﻿using System.IO;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;
using King.LevelSystem;
using King.Utilities;
using King.Utilities.Scriptable;
using King.MapSystem;
using King.MapSystem.Tiles;
using King.Events;
using Newtonsoft.Json;

[RequireComponent(typeof(TileManager))]
public class InitTilemap : MonoBehaviour
{
    public ObjectReference LevelDataReference;

    [SerializeField]
    CustomEvent onMapLoaded;
    [SerializeField]
    ObjectReference TilePositionsInMap;

    Tilemap MainMap;
    TileManager TileManager;

    void Start()
    {
        TileManager = GetComponent<TileManager>();
        TileManager.enabled = false;

        if (ObjectReference.NotEmpty(LevelDataReference, out LevelData levelData))
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

            TilePositionsInMap.Reference = MapData.Tiles.Keys.ToList();
            onMapLoaded.Raise();
        }

        TileManager.enabled = true;
    }

    MapData LoadMapData(string path)
    {
        string fullPath = Path.Combine(LevelSelectHelper.MapsDirectory, path);

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
