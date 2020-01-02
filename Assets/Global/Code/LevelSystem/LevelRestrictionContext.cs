using System.Collections.Generic;
using UnityEngine;
using King.UnitSystem;


namespace King.LevelSystem {
    [CreateAssetMenu(fileName = "LevelRestrictionContext", menuName = "king/LevelRestrictionContext", order = 0)]
    public class LevelRestrictionContext : ScriptableObject
    {
        public List<Vector3Int> AvailableTiles;
        // Maybe add Needed/Restricted units ETC
        public List<Unit> UnitsNeeded;
        public List<Unit> UnitsRestricted;
    }
}
