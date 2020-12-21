using System.Text;
using UnityEngine;
using UnityEngine.UI;
using King.Utilities.Scriptable;
using King.MapSystem;
using King.MapSystem.Tiles;
using System.Collections.Generic;

// TODO Find better name
public class DetailUIManager : MonoBehaviour {

    [SerializeField]
    ObjectReference CursorPosition;

    [SerializeField]
    GameObject ImageGO;
    [SerializeField]
    GameObject InfoGO;

    public void UpdatePanel()
    {
        Image image = ImageGO.GetComponent<Image>();
        Text text = InfoGO.GetComponent<Text>();

        if(ObjectReference.NotEmpty(CursorPosition, out Vector3Int cursorPos))
        {
            // get tile
        }
    }

    string FormatStats(Dictionary<string, string> stats)
    {
        StringBuilder sb = new StringBuilder();

        foreach(KeyValuePair<string, string> kvb in stats)
        {
            sb.Append(kvb.Key);
            sb.Append("\t\t");
            sb.Append(kvb.Value);
        }

        return sb.ToString();
    }
}
