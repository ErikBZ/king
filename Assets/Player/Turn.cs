using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.EventSystems;
using King.Map;

public class Turn : MonoBehaviour
{

    // Put UI manager here

    public TileManager TileManager;
    public DetailUIManager UIManager;

    private TileHighlighter Highlighter;

    private void Awake()
    {
        Highlighter = new TileHighlighter(TileManager.tilemap);
    }

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        //        ShowLandInfoOnHover();
    }

    // when nothing is select this is what the player is allowed to do
    private void ShowLandInfoOnHover()
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

    public void OnMouseDown()
    {
        Debug.Log("Hello world");
    }

    // This won't work since it can't receive the event
    //public void OnPointerDown(PointerEventData eventData)
    //{
    //    Debug.Log("Event handler works");
    //    // IDK what the middle button might do
    //    // this pushes events on the stack
    //    if (eventData.button == PointerEventData.InputButton.Left)
    //    {
    //        Debug.Log("Trace");
    //        var point = new Vector3Int(0, 0, 0);
    //        if(TileManager.TryGetTilePoint(eventData.pressPosition, out point))
    //        {
    //            UIManager.UpdateDetailePanel(TileManager.tilemap.GetTile<MapTile>(point), TileManager.GetTileState(point));
    //        }
    //        else
    //        {

    //        }
    //    }
    //    // High level this pops the stack
    //    else if (eventData.button == PointerEventData.InputButton.Right)
    //    {

    //    }
    //}
}
