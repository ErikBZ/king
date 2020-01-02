namespace King.MapSystem.Tiles
{
    public static class TileValues
    {
        // General rule, if a block is swimable it shouldn't be walkable
        // If it's none of these then the tile is a mega wall
        public const byte WALK = 0x01;
        public const byte FLY= 0x02;
        public const byte SWIM = 0x04;
        public const byte CLIMB = 0x08;
        public const byte HORSE = 0x10;

        // pre baked items
        public const byte STANDARD = WALK & FLY;
        public const byte WALL = FLY;
        public const byte MOUNTAIN = CLIMB & FLY;
        public const byte SEA = SWIM & FLY;
        public const byte CLIFF = FLY;
        public const byte NONE = 0x0;
    }
}
