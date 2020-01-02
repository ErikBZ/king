using UnityEngine;
using UnityEngine.UI;
using King.Loader;

[RequireComponent(typeof(Button))]
public class InitLoadStateButton : MonoBehaviour
{
    SaveState Save;
    public ObjectReference SaveStateReference;
    public CustomEvent SaveSelectedEvent;

    public void InitButton(SaveState save)
    {
        Save = save;
        GetComponentInChildren<Text>().text = save.PlayerName;

        GetComponent<Button>().onClick.AddListener(SetSaveStateReference);
        GetComponent<Button>().onClick.AddListener(LoadSave);
    }

    public void SetSaveStateReference()
    {
        SaveStateReference.Reference = Save;
    }

    public void LoadSave()
    {
        SaveSelectedEvent.Raise();
    }
}
