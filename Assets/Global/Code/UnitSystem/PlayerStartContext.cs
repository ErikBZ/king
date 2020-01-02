using System.Collections.Generic;

namespace King.UnitSystem
{
    // Saves how the players units start in a given level
    public class PlayerStartContext
    {
        public HashSet<string> Units;
        public PlayerStartContext()
        {
            Units = new HashSet<string>();
        }
    }
}
