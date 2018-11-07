using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileMapTester : MonoBehaviour {

    public Tilemap tilemap;

	// Use this for initialization
	void Start () {
        TileBase tile = tilemap.GetTile(new Vector3Int(0, 0, 0));
        if (tile is MapTile)
        {
            Debug.Log("Yay");
            MapTile mapTile = tile as MapTile;
        }
	}

    public void doThing()
    {
        Debug.Log("HI");
    }

    // Update is called once per frame
    void Update () {
		
	}
}
