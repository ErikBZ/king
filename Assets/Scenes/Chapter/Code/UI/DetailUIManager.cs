using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;
using King.Pieces;
using King.Map;

public class DetailUIManager : MonoBehaviour {

    public Text Info;


	// Use this for initialization
	void Start () {
		
	}


    public void UpdateDetailePanel(MapTile tile, TileState state)
    {
        StringBuilder sb = new StringBuilder();

        sb.Append(string.Format("{0}\n", tile.TileType.ToString()));
        sb.Append(string.Format("Defense: {0}\n", tile.BaseDefBoost));
        sb.Append(string.Format("Avoid: {0}\n", tile.BaseAvoidBoost));
        sb.Append(string.Format("Additional Cost: {0}\n", tile.AdditionalMoveCost));

        Info.text = sb.ToString();
    }
}
