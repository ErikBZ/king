using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using King.Map;

namespace King.Pieces
{
    public class Unit
    {
        public int Team { get; set; }
        public int MaxMove { get; set; }
        public byte MoveType { get; set; }

        public Unit()
        {
            Team = 0;
            MaxMove = 4;
            MoveType = TileValues.WALK;
        }
    }
}
