using King.UnitSystem;

namespace King.MapSystem
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
