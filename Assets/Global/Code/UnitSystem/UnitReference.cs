using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace King.Pieces
{

    [CreateAssetMenu(fileName = "UnitReference", menuName = "king/UnitReference", order = 0)]
    public class UnitReference : ScriptableObject
    {
        public Unit Unit;
    }
}
