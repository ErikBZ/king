using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Saves how the players units start in a given level
public class PlayerStartContext
{
    public HashSet<string> Units;
    public PlayerStartContext()
    {
        Units = new HashSet<string>();
    }
}
