namespace King
{
    public static class TileValues
    {
        // General rule, if a block is swimable it shouldn't be walkable
        // If it's none of these then the tile is a mega wall
        public const byte WALKABLE = 0x01;
        public const byte FLYABLE = 0x02;
        public const byte SWIMABLE = 0x04;
        public const byte CLIMBABLE = 0x08;
        public const byte HORSEABLE = 0x10;

        // pre baked items
        public const byte STANDARD = WALKABLE & FLYABLE;
        public const byte WALL = FLYABLE;
        public const byte MOUNTAIN = CLIMBABLE & FLYABLE;
        public const byte SEA = SWIMABLE & FLYABLE;
        public const byte CLIFF = FLYABLE;
        public const byte NONE = 0x0;

        public static void DoesSomething()
        {
            byte thing = SWIMABLE & STANDARD;
        }
    }
}
