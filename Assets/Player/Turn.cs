using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using King.Map;

public class Turn : MonoBehaviour {

    // Put UI manager here

    public TileManager TileManager;
    public DetailUIManager UIManager;

    private TileHighlighter Highlighter;

    private void Awake()
    {
        Highlighter = new TileHighlighter(TileManager.tilemap);
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        PlayerTurnIdle();
	}

    // when nothing is select this is what the player is allowed to do
    private void PlayerTurnIdle()
    {
        var point = new Vector3Int(0, 0, 0);

        if (TileManager.TryGetTilePoint(Input.mousePosition, out point))
        {
            Highlighter.PointHighlight(point);

            // ui manager show board point
            UIManager.UpdateDetailePanel(TileManager.tilemap.GetTile<MapTile>(point), TileManager.GetTileState(point));
        }
        else
        {
            // clear UI Manager
        }
    }
}
