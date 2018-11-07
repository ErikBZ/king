using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu (menuName ="Tile Action/Deal Damage")]
public class TileDealDamage : ScriptableObject {

    public void DealDamage(int x, int y)
    {
        int z = x + y;
    }
}
