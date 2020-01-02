using UnityEngine;

namespace King.UnitSystem
{

    [CreateAssetMenu(fileName = "UnitReference", menuName = "king/UnitReference", order = 0)]
    public class UnitReference : ScriptableObject
    {
        public Unit Unit;
    }
}
