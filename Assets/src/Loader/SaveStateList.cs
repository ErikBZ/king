using System;
using System.Collections.Generic;
using UnityEngine;
using King.Loader;

namespace King.Loader
{
    [CreateAssetMenu(fileName = "SaveStateList", menuName = "Saves/List", order = 0)]
    public class SaveStateList : ScriptableObject
    {
        public List<SaveState> Saves;
    }
}
