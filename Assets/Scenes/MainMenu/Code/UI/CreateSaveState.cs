using UnityEngine;
using UnityEngine.UI;
using King.SaveSystem;
using King.Events;
using King.Utilities.Scriptable;

public class CreateSaveState : MonoBehaviour
{
    public InputField Input;
    public SaveStateList SaveStateList;
    public ObjectReference SaveStateReference;
    public CustomEvent SaveSelectedEvent;
    
    public void CreateAndSaveNewState()
    {
        SaveState state = new SaveState();
        state.PlayerName = Input.text;
        SaveStateList.Saves.Add(state);
        SaveStateLoader.SaveToJson(SaveStateList.Saves);

        SetSaveStateReference(state);
    }

    public void SetSaveStateReference(SaveState save)
    {
        SaveStateReference.Reference = save;
    }

    public void LoadNewSave()
    {
        SaveSelectedEvent.Raise();
    }
}
