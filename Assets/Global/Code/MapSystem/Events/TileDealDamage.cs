using UnityEngine;

namespace King.MapSystem.Events
{
    [CreateAssetMenu(menuName = "Tile Action/Deal Damage")]
    public class TileDealDamage : ScriptableObject
    {

        public void DealDamage(int x, int y)
        {
            int z = x + y;
        }
    }
}
