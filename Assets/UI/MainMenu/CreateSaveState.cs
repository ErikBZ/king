using UnityEngine;
using UnityEngine.UI;
using King.Loader;

public class CreateSaveState : MonoBehaviour
{
    public InputField Input;
    public SaveStateList SaveStateList;
    public ObjectReference SaveStateReference;
    public CustomEvent SaveSelectedEvent;
    
    public void CreateAndSaveNewState()
    {
        Debug.Log("CreateAndSave is called first");
        SaveState state = new SaveState();
        state.PlayerName = Input.text;
        SaveStateList.Saves.Add(state);
        SaveStateLoader.Save(SaveStateList.Saves);

        SetSaveStateReference(state);
    }

    public void SetSaveStateReference(SaveState save)
    {
        SaveStateReference.Reference = save;
    }

    public void LoadNewSave()
    {
        Debug.Log("LoadNewSave is called first");
        SaveSelectedEvent.Raise();
    }
}
