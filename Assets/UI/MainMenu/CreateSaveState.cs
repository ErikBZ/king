using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using King.Loader;

public class CreateSaveState : MonoBehaviour
{
    public InputField Input;
    public SaveStateList SaveStateList;
    
    public void CreateAndSaveNewState()
    {
        SaveState state = new SaveState();
        state.PlayerName = Input.text;
        SaveStateList.Saves.Add(state);
        SaveStateLoader.Save(SaveStateList.Saves);
    }
}
