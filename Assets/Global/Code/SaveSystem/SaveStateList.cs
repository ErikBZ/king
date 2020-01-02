using System.Collections.Generic;
using UnityEngine;

namespace King.SaveSystem
{
    [CreateAssetMenu(fileName = "SaveStateList", menuName = "Saves/List", order = 0)]
    public class SaveStateList : ScriptableObject
    {
        public List<SaveState> Saves;
    }
}
