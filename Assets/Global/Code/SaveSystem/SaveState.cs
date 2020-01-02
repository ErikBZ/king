using System;

namespace King.SaveSystem
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
