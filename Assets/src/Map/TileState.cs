using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using King.Pieces;

namespace King.Map
{
    public class TileState
    {
        public bool Occupied { get; set; }
        public Unit Unit { get; set; }

        public TileState()
        {
            Occupied = false;
            Unit = null;
        }
    }
}
