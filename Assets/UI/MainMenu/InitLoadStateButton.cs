using UnityEngine;
using UnityEngine.UI;
using King.Loader;

[RequireComponent(typeof(Button))]
public class InitLoadStateButton : MonoBehaviour
{
    SaveState Save;

    public void InitButton(SaveState save)
    {
        Save = save;
        GetComponentInChildren<Text>().text = save.PlayerName;
    }
}
