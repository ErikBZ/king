using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace King.Pieces
{
    // Use this class to keep track of active units and ETC
    [CreateAssetMenu(fileName = "UnitList", menuName = "king/UnistList", order = 0)]
    public class UnitList : ScriptableObject
    {
        public List<Unit> Units;
    }
}