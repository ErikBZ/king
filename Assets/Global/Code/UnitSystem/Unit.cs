using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using King.Map;

namespace King.Pieces
{
    [CreateAssetMenu(fileName = "Unit", menuName = "king/Unit", order = 0)]
    public class Unit : ScriptableObject
    {
        // Some extra shit
        public string Name;
        public Sprite PortraitSprite;
        public int Team;
        public int MaxMove;
        public byte MoveType;
        public UnitClass Class;

        // Stats
        public Stats stats;
        public Unit()
        {
            Team = 0;
            MaxMove = 4;
            MoveType = TileValues.WALK;
        }
    }
}
