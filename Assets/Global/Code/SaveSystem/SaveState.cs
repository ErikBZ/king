using System;
using UnityEngine;

namespace King.Loader
{
    [Serializable]
    public class SaveState
    {
        public string PlayerName;

        public SaveState() {
            this.PlayerName = "";
        }
    }
}
