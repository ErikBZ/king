using UnityEngine;
using UnityEngine.UI;
using King.Loader;
using King.Level;

[RequireComponent(typeof(Button))]
public class SelectLevelButton : MonoBehaviour
{
    LevelData Level;
    public ObjectReference LevelDataReference;
    public CustomEvent LevelSelectedEvent;

    public void InitButton(LevelData level)
    {
        Level = level;
        GetComponentInChildren<Text>().text = level.Name;

        GetComponent<Button>().onClick.AddListener(SetLevelSelectedReference);
        GetComponent<Button>().onClick.AddListener(LoadSave);
    }

    public void SetLevelSelectedReference()
    {
        LevelDataReference.Reference = Level;
    }

    public void LoadSave()
    {
        LevelSelectedEvent.Raise();
    }
}
