using UnityEngine;
using King.MapSystem;
using King.MapSystem.Tiles;
using King.Utilities;
using King.Utilities.Scriptable;
using King.Events;
using System.Collections.Generic;

public class MouseActions : MonoBehaviour
{
    // Put UI manager here
    public TileManager TileManager;
    public DetailUIManager UIManager;

    public ObjectReference tilesToHighlight;
    public CustomEvent cursorMovedEvent;

    private Vector3Int oldCursorPos;

    void Update()
    {
        var mousePos = Input.mousePosition;
        var point = Camera.main.ScreenToWorldPoint(mousePos);
        // z should be zeroed to avoid any weirdness later on
        point.z = 0;
        var currCursorPos = ConvertUtil.ToVector3Int(point);

        if (!currCursorPos.Equals(oldCursorPos))
        {
            tilesToHighlight.Reference = new List<Vector3Int>() { currCursorPos };
            cursorMovedEvent.Raise();
            oldCursorPos = currCursorPos;
        }
    }
}
